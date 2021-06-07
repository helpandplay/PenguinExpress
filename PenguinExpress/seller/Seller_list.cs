using MySql.Data.MySqlClient;
using PenguinExpress.config;
using PenguinExpress.main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PenguinExpress.seller
{
  public partial class Seller_list : Form
  {
    int userid;
    Status stus;
    public Seller_list(int userid)
    {
      InitializeComponent();
      this.userid = userid;
      stus = new Status();
    }
    private void getAllCompleteList(string sql=null)
    {
      if (sql == null)
      {
        sql = string.Format(
          "SELECT tracking_id, p_name, p_qty, b_phone, b_addr, cp_time " +
          "FROM {0} " +
          "WHERE s_id={1};"
          , MyDatabase.completeListTbl, userid);
      }
      MyDatabase.cmd.CommandText = sql;

      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();
      lv_cp.Items.Clear();
      try
      {
        while (reader.Read())
        {
          ListViewItem lvi = new ListViewItem();
          lvi.Text = reader["tracking_id"].ToString();
          lvi.SubItems.Add(reader["p_name"].ToString());
          lvi.SubItems.Add(reader["p_qty"].ToString());
          lvi.SubItems.Add(reader["b_phone"].ToString());
          lvi.SubItems.Add(reader["b_addr"].ToString());
          lvi.SubItems.Add(reader["cp_time"].ToString());

          lv_cp.Items.Add(lvi);
        }
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        reader.Close();
        Debug.Close();
      }
    }
    private void getAllRegList(string sql=null)
    {
      if (sql == null)
      {
        sql = string.Format(
          "SELECT tracking_id, p_name, p_qty, b_phone, b_addr, rv_time, rv_status " +
          "FROM {0} " +
          "WHERE s_id={1};", MyDatabase.reservationListTbl, userid);
      }
      Debug.WriteLine(sql);
      MyDatabase.cmd.CommandText = sql;

      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();

      lv_reg.Items.Clear();
      try
      {
        while (reader.Read())
        {
          if ((int)reader["rv_status"] == 3) continue;
          if ((int)reader["rv_status"] == -1) continue;

          ListViewItem lvi = new ListViewItem();
          lvi.Text = reader["tracking_id"].ToString();
          lvi.SubItems.Add(reader["p_name"].ToString());
          lvi.SubItems.Add(reader["p_qty"].ToString());
          lvi.SubItems.Add(reader["b_phone"].ToString());
          lvi.SubItems.Add(reader["b_addr"].ToString());
          lvi.SubItems.Add(reader["rv_time"].ToString());

          string status = stus.getReservationCode((int)reader["rv_status"]);
          lvi.SubItems.Add(status);


          lv_reg.Items.Add(lvi);
        }
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        reader.Close();
        Debug.Close();
      }
    }
    private void btn_reg_refresh_Click(object sender, EventArgs e)
    {
      getAllRegList();
    }
    private void btn_cp_refresh_Click(object sender, EventArgs e)
    {
      getAllCompleteList();
    }
    private void lv_reg_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      string columnName = lv_reg.Columns[e.Column].Tag.ToString();
      string sql = string.Format(
        "SELECT tracking_id, p_name, p_qty, b_phone, b_addr, rv_time, rv_status " +
        "FROM {0} " +
        "WHERE s_id = {1} " +
        "ORDER BY {2} DESC;"
        , MyDatabase.reservationListTbl, userid, columnName);

      getAllRegList(sql);
    }
    private void lv_cp_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      string columnName = lv_cp.Columns[e.Column].Tag.ToString();
      string sql = string.Format(
        "SELECT tracking_id, p_name, p_qty, b_phone, b_addr, cp_time " +
        "FROM {0} " +
        "WHERE s_id = {1} " +
        "ORDER BY {2} DESC;"
        , MyDatabase.completeListTbl, userid, columnName);

      getAllCompleteList(sql);
    }
    private void btn_rv_cancel_Click(object sender, EventArgs e)
    {
      if (lv_reg.SelectedItems.Count == 0) return;

      string status = lv_reg.SelectedItems[0].SubItems[6].Text;
      if (status != "예약 완료")
      {
        MessageBox.Show("배송 중이므로 취소가 불가능합니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      DialogResult result = MessageBox.Show("예약을 취소하시겠어요?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
      if (result == DialogResult.Cancel) return;

      int trackingId = int.Parse(lv_reg.SelectedItems[0].Text);
      try
      {
        string sql = string.Format(
        "UPDATE {0} SET rv_status = -1 " +
        "WHERE tracking_id = {1}", MyDatabase.reservationListTbl, trackingId);
        MyDatabase.cmd.CommandText = sql;
        MyDatabase.cmd.ExecuteNonQuery();
        MessageBox.Show("취소되었습니다.", "Info", MessageBoxButtons.OK);

        getAllRegList();
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        Debug.Close();
      }

    }
    private void btn_add_rv_Click(object sender, EventArgs e)
    {
      string sql = string.Format(
        "SELECT id, name, phone, addr " +
        "FROM {0} " +
        "WHERE id = {1};", MyDatabase.sellerTbl, userid);
      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();
      Dictionary<string, string> seller = null;
      try
      {
        if (!reader.Read())
        {
          MessageBox.Show("값이 없습니다!");
          return;
        }

        string name = reader["name"].ToString();
        string phone = reader["phone"].ToString();
        string addr = reader["addr"].ToString();

        seller = new Dictionary<string, string>()
        {
          {"id", userid.ToString() },
          {"name", name },
          {"phone",phone },
          {"addr", addr }
        };
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        Debug.Close();
        reader.Close();
      }
      if (seller == null) return;
      new AddProduct(seller).ShowDialog();
      getAllRegList();
    }
    private void btn_logout_Click(object sender, EventArgs e)
    {
      SetVisibleCore(false);
      this.Close();
      new Login().ShowDialog();
    }
    private void setColor()
    {
      this.BackColor = ColorTranslator.FromHtml(Env.baseColor);
      this.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      this.Font = Env.font;

      btn_add_rv.FlatStyle = FlatStyle.Flat;
      btn_cp_refresh.FlatStyle = FlatStyle.Flat;
      btn_reg_refresh.FlatStyle = FlatStyle.Flat;
      btn_rv_cancel.FlatStyle = FlatStyle.Flat;

      btn_cp_refresh.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
      btn_add_rv.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
      btn_reg_refresh.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
      btn_rv_cancel.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);

      btn_cp_refresh.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      btn_add_rv.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      btn_reg_refresh.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      btn_rv_cancel.ForeColor = ColorTranslator.FromHtml(Env.textColor);

      btn_cp_refresh.Font = Env.boldFont;
      btn_add_rv.Font = Env.boldFont;
      btn_reg_refresh.Font = Env.boldFont;
      btn_rv_cancel.Font = Env.boldFont;
    }
    protected override void SetVisibleCore(bool value)
    {
      if (!this.IsHandleCreated)
      {
        this.CreateHandle();
        value = false;
      }
      base.SetVisibleCore(value);
    }
    private void List_Load(object sender, EventArgs e)
    {
      setColor();
      getAllRegList();
      getAllCompleteList();
    }
  }
}
