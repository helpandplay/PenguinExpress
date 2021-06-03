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
          rvStatus = getDeliveryStatus(rvStatus);
          string regionCode = reader["b_region_code"].ToString();
          //regionCode = getRegionName(regionCode);
          string trackingId = reader["tracking_id"].ToString();
          string sellerId = reader["userid"].ToString();
          string prodName = reader["p_name"].ToString();
          string prodQty = reader["p_qty"].ToString();
          string prodCode = reader["p_code"].ToString();
          
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
    private string getDeliveryStatus(string status)
    {
      switch (status)
      {
        case "-1":
          return "예약 취소";
        case "1":
          return "배정 대기중";
        case "2":
          return "배송 중";
        case "3":
          return "배송 완료";
        default:
          Debug.WriteLine("알수 없는 status : " + status);
          return "Error";
      }
    }
    /*
private string getRegionName(string code)
{
 * 강원도
경기도
경상남도
경상북도
광주광역시
대구광역시
대전광역시
부산광역시
서울특별시
인천광역시
전라남도
전라북도
충청남도
충청북도
  }
     */
  }
}
