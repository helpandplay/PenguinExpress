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
using PenguinExpress.config;
using MySql.Data.MySqlClient;

namespace PenguinExpress.employee
{
  public partial class Admin : Form
  {
    string id;
    public Admin(string id)
    {
      this.id = id;
      InitializeComponent();
    }

    private void Admin_Load(object sender, EventArgs e)
    {
      getDeliveryList();
    }

    private void listTab_Selected(object sender, TabControlEventArgs e)
    {
      Debug.WriteLine(e.TabPageIndex);
    }
    private void getDeliveryList()
    {
      string sql = string.Format(
        "SELECT tracking_id, se.userid, p_name, p_qty, p_code, b_region_code, rv_time, rv_status " +
        "FROM {0} rv, {1} se " +
        "WHERE rv.s_id = se.id;"
        , MyDatabase.reservationListTbl, MyDatabase.sellerTbl);
      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();
      try
      {
        lv_delivery.Items.Clear();
        while (reader.Read())
        {
          string rvStatus = reader["rv_status"].ToString();

          if (rvStatus == "-1" || rvStatus == "3") continue;
          string trackingId = reader["tracking_id"].ToString();
          string sellerId = reader["userid"].ToString();
          string prodName = reader["p_name"].ToString();
          string prodQty = reader["p_qty"].ToString();
          string prodCode = reader["p_code"].ToString();
          string regionCode = reader["b_region_code"].ToString();
          string rvTime = reader["rv_time"].ToString();
          

          string[] row = new string[] { trackingId, sellerId, prodName, prodQty, prodCode, regionCode, rvTime, rvStatus };
          ListViewItem lvi = new ListViewItem(row);
          lv_delivery.Items.Add(lvi);
        }
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        reader.Close();
      }
    }
  }
}
