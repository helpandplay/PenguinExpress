using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using PenguinExpress.config;

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

    private void List_Load(object sender, EventArgs e)
    {
      getAllRegList();
      getAllCompleteList();
    }
    private void getAllCompleteList()
    {
      string sql = string.Format(
        "SELECT tracking_id, p_name, p_qty, b_phone, b_addr, rv_status, cp_time " +
        "FROM {0} rv, {1} cd " +
        "WHERE rv.s_id={2} AND rv.tracking_id = cd.rv_tracking_id;"
        ,MyDatabase.reservationListTbl, MyDatabase.completeListTbl, userid);
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

          string status = stus.getReservationCode((int)reader["rv_status"]);
          lvi.SubItems.Add(status);

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
    private void getAllRegList()
    {
      string sql = string.Format(
        "SELECT tracking_id, p_name, p_qty, b_phone, b_addr, rv_time, rv_status " +
        "FROM {0} " +
        "WHERE s_id={1};",MyDatabase.reservationListTbl, userid);
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
    //새로고침
    private void btn_reg_refresh_Click(object sender, EventArgs e)
    {
      getAllRegList();
    }

    private void btn_cp_refresh_Click(object sender, EventArgs e)
    {
      getAllCompleteList();
    }

    //정렬
    private void lv_reg_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      Debug.WriteLine(lv_reg.Columns[e.Column]);
    }

    private void lv_cp_ColumnClick(object sender, ColumnClickEventArgs e)
    {
      Debug.WriteLine(lv_reg.Columns[e.Column]);
    }
    //예약 취소
    private void btn_rv_cancel_Click(object sender, EventArgs e)
    {
      if (lv_reg.SelectedItems.Count == 0) return;

      string status = lv_reg.SelectedItems[0].SubItems[6].Text;
      if(status != "예약 완료")
      {
        MessageBox.Show("배송 중이므로 취소가 불가능합니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      DialogResult result =  MessageBox.Show("예약을 취소하시겠어요?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
      catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally{
        Debug.Close();
      }

    }

    private void btn_add_rv_Click(object sender, EventArgs e)
    {
     
    }
  }
}
