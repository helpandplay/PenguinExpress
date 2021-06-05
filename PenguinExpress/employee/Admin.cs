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
using PenguinExpress.main;
using System.Drawing;

namespace PenguinExpress.employee
{
  public partial class Admin : Form
  {
    string id;
    Status stus;
    public Admin(string id)
    {
      this.id = id;
      stus = new Status();
      InitializeComponent();
    }
    private void setColor()
    {
      this.BackColor = ColorTranslator.FromHtml(Env.baseColor);
      this.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      this.Font = Env.font;

      //btn
      btn_getItemGraph.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
      btn_getRegionGraph.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
      button1.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);

      btn_getItemGraph.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      btn_getRegionGraph.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      button1.ForeColor = ColorTranslator.FromHtml(Env.textColor);

      btn_getItemGraph.FlatStyle = FlatStyle.Flat;
      btn_getRegionGraph.FlatStyle = FlatStyle.Flat;
      button1.FlatStyle = FlatStyle.Flat;

      btn_getItemGraph.Font = Env.boldFont;
      btn_getRegionGraph.Font = Env.boldFont;
      button1.FlatStyle = FlatStyle.Flat;

    }
    private void Admin_Load(object sender, EventArgs e)
    {
      setColor();
      getDeliveryList();
    }

    private void listTab_Selected(object sender, TabControlEventArgs e)
    {
      if (e.TabPageIndex == 0) getDeliveryList();
      else getCompleteList();
    }
    private void getCompleteList()
    {
      string sql = string.Format(
        "SELECT tracking_id, s_id, s_phone, b_phone, e_id, rv_time, cp_time " +
        "FROM {0} rv;"
        , MyDatabase.completeListTbl);
      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();
      try
      {
        lv_complete.Items.Clear();
        while (reader.Read())
        {
          string trackingId = reader["tracking_id"].ToString();
          string sellerId = reader["s_id"].ToString();
          string sellerPhone = reader["s_phone"].ToString();
          string buyerPhone = reader["b_phone"].ToString();
          string delieverId = reader["e_id"].ToString();
          string rvTime = reader["rv_time"].ToString();
          string cpTime = reader["cp_time"].ToString();

          string[] row = new string[]
          { trackingId, sellerId, sellerPhone, buyerPhone, delieverId, rvTime, cpTime };
          ListViewItem lvi = new ListViewItem(row);
          lv_complete.Items.Add(lvi);
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
    private void getDeliveryList()
    {
      string sql = string.Format(
        "SELECT tracking_id, se.userid, p_name, p_qty, p_code, b_region_code, rv_time, rv.e_id, rv_status " +
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
          string eId = reader["e_id"].ToString();


          string[] row = new string[] { trackingId, sellerId, prodName, prodQty, prodCode, regionCode, rvTime, eId, rvStatus };
          ListViewItem lvi = new ListViewItem(row);
          lv_delivery.Items.Add(lvi);
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

    private void lv_delivery_DoubleClick(object sender, EventArgs e)
    {
      Dictionary<string, string> rowData = new Dictionary<string, string>();
      var lvi = sender as ListView;
      string status = lvi.SelectedItems[0].SubItems[8].Text;

      if (status != "배정 대기중") return;
      string trackingId = lvi.SelectedItems[0].SubItems[0].Text;

      string sql = string.Format(
        "SELECT b_region_code, b_addr " +
        "FROM {0} " +
        "WHERE tracking_id = {1};"
        , MyDatabase.reservationListTbl, trackingId);
      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();
      try
      {
        if (!reader.Read())
        {
          throw new Exception("불러온 값이 없습니다.");
        }
        rowData.Add("trackingId", trackingId);
        rowData.Add("regionCode", reader["b_region_code"].ToString());
        rowData.Add("buyerAddr", reader["b_addr"].ToString());

      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        reader.Close();
      }
      new SetWorker(rowData, this).ShowDialog();
      getDeliveryList();
    }
    public bool updateWorker(string id, string trackingId)
    {
      string sql = string.Format(
        "UPDATE {0} " +
        "SET e_id = {1}, rv_status = 2 " +
        "WHERE tracking_id = '{2}';"
        , MyDatabase.reservationListTbl, id, trackingId);

      MyDatabase.cmd.CommandText = sql;
      try
      {
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if (result == 1) return true;
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      return false;
    }

    private void btn_logout_Click(object sender, EventArgs e)
    {
      this.Close();
      new Login().Show();
    }

    private void btn_getItemGraph_Click(object sender, EventArgs e)
    {
      Dictionary<int, int> data = getItemGraphData();
      int total = getItemTotal();
      if (total == -1)
      {
        MessageBox.Show("총 개수 불러오는 오류 발생");
        return;
      }
      new ShowGraph(data, total).ShowDialog();
    }
    private int getItemTotal()
    {
      int total = -1;
      string sql = string.Format(
        "SELECT COUNT(id) " +
        "FROM {0}; ",
        MyDatabase.completeListTbl
        );
      MyDatabase.cmd.CommandText = sql;
      try
      {
        object result = MyDatabase.cmd.ExecuteScalar();
        total = int.Parse(result.ToString());
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.StackTrace);
        Debug.WriteLine(error.Message);
      }
      return total;
    }
    private Dictionary<int, int> getItemGraphData()
    {
      Dictionary<int, int> data = new Dictionary<int, int>();
      string sql = string.Format(
        "SELECT p_code, COUNT(*) AS 'cnt' " +
        "FROM {0} " +
        "GROUP BY p_code;",
        MyDatabase.completeListTbl
        );
      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();
      try
      {
        while (reader.Read())
        {
          data.Add(int.Parse(reader["p_code"].ToString()), int.Parse(reader["cnt"].ToString()));
        }
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.StackTrace);
        Debug.WriteLine(error.Message);
      }
      finally
      {
        reader.Close();
      }
      return data;
    }

    private void btn_getRegionGraph_Click(object sender, EventArgs e)
    {
      //code, count
      Dictionary<int, int> data = getRegionGraphData();
      int total = getItemTotal();
      if (total == -1)
      {
        MessageBox.Show("총 개수 불러오는 오류 발생");
        return;
      }
      new ShowGraph(data, total).ShowDialog();
    }
    private Dictionary<int, int> getRegionGraphData()
    {
      Dictionary<int, int> data = new Dictionary<int, int>();
      string sql = string.Format(
        "SELECT b_region_code, COUNT(*) AS 'cnt' " +
        "FROM {0} " +
        "GROUP BY b_region_code;",
        MyDatabase.completeListTbl
        );
      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();
      try
      {
        while (reader.Read())
        {
          data.Add(int.Parse(reader["b_region_code"].ToString()), int.Parse(reader["cnt"].ToString()));
        }
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.StackTrace);
        Debug.WriteLine(error.Message);
      }
      finally
      {
        reader.Close();
      }
      return data;
    }
  }
}
