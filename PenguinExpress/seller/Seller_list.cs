using MySql.Data.MySqlClient;
using PenguinExpress.config;
using PenguinExpress.main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PenguinExpress.service;
using PenguinExpress.entity;

namespace PenguinExpress.seller
{
  public partial class Seller_list : Form
  {
    CompleteService complete = new CompleteService();
    CompleteEntity completeEntity = CompleteEntity.getComplete();
    int userid;
    Status stus;
    public Seller_list(int userid)
    {
      InitializeComponent();
      this.userid = userid;
      stus = new Status();
    }
    private void setColor()
    {
      this.BackColor = ColorTranslator.FromHtml(Styles.light);
      this.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      this.Font = Styles.font;

      btn_add_rv.FlatStyle = FlatStyle.Flat;
      btn_cp_refresh.FlatStyle = FlatStyle.Flat;
      btn_reg_refresh.FlatStyle = FlatStyle.Flat;
      btn_rv_cancel.FlatStyle = FlatStyle.Flat;

      btn_cp_refresh.BackColor = ColorTranslator.FromHtml(Styles.primary);
      btn_add_rv.BackColor = ColorTranslator.FromHtml(Styles.primary);
      btn_reg_refresh.BackColor = ColorTranslator.FromHtml(Styles.primary);
      btn_rv_cancel.BackColor = ColorTranslator.FromHtml(Styles.warning);

      btn_cp_refresh.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_add_rv.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_reg_refresh.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_rv_cancel.ForeColor = ColorTranslator.FromHtml(Styles.light);

      btn_cp_refresh.Font = Styles.boldFont;
      btn_add_rv.Font = Styles.boldFont;
      btn_reg_refresh.Font = Styles.boldFont;
      btn_rv_cancel.Font = Styles.boldFont;

      lv_cp.BackColor = ColorTranslator.FromHtml(Styles.blueGray);
      lv_reg.BackColor = ColorTranslator.FromHtml(Styles.blueGray);
      lv_cp.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      lv_reg.ForeColor = ColorTranslator.FromHtml(Styles.dark);

      lv_cp.BorderStyle = BorderStyle.FixedSingle;
      lv_reg.BorderStyle = BorderStyle.FixedSingle;

      label1.BackColor = ColorTranslator.FromHtml(Styles.info);
      label2.BackColor = ColorTranslator.FromHtml(Styles.info);
      label1.ForeColor = ColorTranslator.FromHtml(Styles.light);
      label2.ForeColor = ColorTranslator.FromHtml(Styles.light);
    }
    private List<Dictionary<string,string>> getCompleteData()
    {
      return complete.findAllTarget(userid.ToString(), completeEntity.sellerID);
    }
    private void displayCompleteData(List<Dictionary<string, string>> datas)
    {
      lv_reg.Items.Clear();
      try
      {
        foreach(Dictionary<string, string> data in datas)
        {
          ListViewItem lvi = new ListViewItem();
          lvi.Text = data[completeEntity.trackingID].ToString();
          lvi.SubItems.Add(data[completeEntity.prodName].ToString());
          lvi.SubItems.Add(data[completeEntity.prodQty].ToString());
          lvi.SubItems.Add(data[completeEntity.buyPhone].ToString());
          lvi.SubItems.Add(data[completeEntity.buyAddr].ToString());
          lvi.SubItems.Add(data[completeEntity.rvTime].ToString());
          lvi.SubItems.Add(stus.getReservationCode(3));

          lv_reg.Items.Add(lvi);
        }
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
    }
    private void getAllCompleteList(string orderName=null)
    {
      List<Dictionary<string, string>> data;

      data = orderName == null ? complete.findAll() : complete.findAll(orderName);

      lv_cp.Items.Clear();
      try
      {
        foreach(Dictionary<string, string> column in data)
        {
          ListViewItem lvi = new ListViewItem();
          lvi.Text = column["tracking_id"];
          lvi.SubItems.Add(column["p_name"]);
          lvi.SubItems.Add(column["p_qty"]);
          lvi.SubItems.Add(column["b_phone"].);
          lvi.SubItems.Add(column["b_addr"]);
          lvi.SubItems.Add(column["cp_time"]);

          lv_cp.Items.Add(lvi);
        }
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
      // 데이터 가져오기
      List<Dictionary<string, string>> data = getCompleteData();
      // 보여주기
      displayCompleteData(data);
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
      getAllCompleteList(columnName);
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
      if (result == DialogResult.No) return;

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
