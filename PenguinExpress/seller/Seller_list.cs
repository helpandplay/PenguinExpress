using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace PenguinExpress.seller
{
  public partial class Seller_list : Form
  {
    string userid;
    MySqlCommand cmd;
    Status stus;
    public Seller_list(MySqlCommand cmd, string userid)
    {
      this.cmd = cmd;
      this.userid = userid;
      stus = new Status();
      InitializeComponent();
    }

    private void List_Load(object sender, EventArgs e)
    {
      getAllRegList();
    }
    private void getAllRegList()
    {
      string sql = string.Format("SELECT tracking_id, p_name, p_qty, b_phone, b_addr, rv_time, rv_status FROM reservation_list;");
      cmd.CommandText = sql;

      MySqlDataReader reader = cmd.ExecuteReader();

      lv_reg.Items.Clear();
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
      }
    }

    private void btn_reg_refresh_Click(object sender, EventArgs e)
    {
      getAllRegList();
    }
  }
}
