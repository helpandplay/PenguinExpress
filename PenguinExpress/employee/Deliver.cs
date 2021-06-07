using MySql.Data.MySqlClient;
using PenguinExpress.config;
using PenguinExpress.main;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PenguinExpress.employee
{
  public partial class Deliver : Form
  {
    string id;
    public Deliver(string id)
    {
      this.id = id;
      InitializeComponent();
    }
    private void setColor()
    {
      //base
      this.BackColor = ColorTranslator.FromHtml( Env.baseColor);
      this.ForeColor = ColorTranslator.FromHtml( Env.textColor);
      this.Font = Env.font;
      //btn
      btn_completeDelivery.Font = Env.boldFont;
      btn_refresh.Font = Env.boldFont;
      button2.Font = Env.boldFont;

      btn_completeDelivery.FlatStyle = FlatStyle.Flat;
      btn_refresh.FlatStyle = FlatStyle.Flat;
      button2.FlatStyle = FlatStyle.Flat;

      btn_completeDelivery.BackColor = ColorTranslator.FromHtml( Env.contentStrongColor);
      btn_refresh.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
      button2.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);

      btn_completeDelivery.ForeColor = ColorTranslator.FromHtml(Env.textBrightColor);
      btn_refresh.ForeColor = ColorTranslator.FromHtml(Env.textBrightColor);
      button2.ForeColor = ColorTranslator.FromHtml(Env.textBrightColor);
    }
    private void Deliver_Load(object sender, EventArgs e)
    {
      setColor();
      //자기 지역번호 가져오기
      lb_dv_id.Text = lb_dv_id.Text + id;

      getDeliveryList();
    }
    private void getDeliveryList()
    {
      string sql = string.Format(
        "SELECT tracking_id, p_name, p_qty, b_addr, b_phone, s_phone " +
        "FROM {0} " +
        "WHERE e_id = {1} AND rv_status = 2;"
        , MyDatabase.reservationListTbl, id);
      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();
      lv_delivery_list.Items.Clear();
      try
      {
        while (reader.Read())
        {
          ListViewItem lvi;

          string trackingId = reader["tracking_id"].ToString();
          string pName = reader["p_name"].ToString();
          string pQty = reader["p_qty"].ToString();
          string bAddr = reader["b_addr"].ToString();
          string bPhone = reader["b_phone"].ToString();
          string sPhone = reader["s_phone"].ToString();

          lvi = new ListViewItem(new string[] { trackingId, pName, pQty, bAddr, bPhone, sPhone });
          lv_delivery_list.Items.Add(lvi);
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

    private void btn_refresh_Click(object sender, EventArgs e)
    {
      getDeliveryList();
    }

    private void lv_delivery_list_DoubleClick(object sender, EventArgs e)
    {
      DialogResult result = MessageBox.Show("배송 완료하셨습니까?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == DialogResult.No) return;

      ListView lv = sender as ListView;
      string trackingId = lv.SelectedItems[0].SubItems[0].Text;

      completeDelivery(trackingId);
      updateCount();
    }

    private void btn_completeDelivery_Click(object sender, EventArgs e)
    {
      if (lv_delivery_list.SelectedItems.Count == 0) return;
      string trackingId = lv_delivery_list.SelectedItems[0].SubItems[0].Text;

      completeDelivery(trackingId);
      updateCount();
    }
    private void updateCount()
    {
      int count = getDelieveryCount();
      if (count == -1)
      {
        Debug.WriteLine("배송 횟수 가져오는 데 실패");
        return;
      }
      bool result = updateDeliveryCount(count + 1);
      if (!result)
      {
        Debug.WriteLine("배송 횟수 업데이트 하는 데 실패");
        return;
      }

    }
    private bool updateDeliveryCount(int count)
    {
      bool isSuccess = false;
      string sql = string.Format(
        "UPDATE {0} " +
        "SET cp_count = {1} " +
        "WHERE id = {2};"
        , MyDatabase.employeeTbl, count, id);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if (result != -1) isSuccess = true;
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.StackTrace);
        Debug.WriteLine(error.Message);
      }
      return isSuccess;
    }
    private int getDelieveryCount()
    {
      int count = -1;
      string sql = string.Format(
        "SELECT cp_count " +
        "FROM {0} " +
        "WHERE id = {1};"
        , MyDatabase.employeeTbl, id);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        object result = MyDatabase.cmd.ExecuteScalar();
        count = (int)result;
      }catch(Exception error)
      {
        Debug.WriteLine(error.StackTrace);
        Debug.WriteLine(error.Message);
      }
      return count;
    }
    private void completeDelivery(string trackingId)
    {
      //rv 테이블의 rv_status => 3
      //completeList에 insert
      // reservation table의 rv_status => 3업데이트
      string sql;
      
      sql = string.Format(
        "UPDATE {0} SET rv_status = 3 " +
        "WHERE tracking_id = {1};",
        MyDatabase.reservationListTbl, trackingId
        );
      bool result = updateStatus(sql);
      if (!result)
      {
        Debug.WriteLine("상태 업데이트 실패");
        return;
      }
      // reservation table의 값들 가져오기
      sql = string.Format(
        "SELECT *" +
        "FROM {0} " +
        "WHERE tracking_id = {1};",
        MyDatabase.reservationListTbl, trackingId
        );
      Dictionary<string, string> completeDeliveryData = getCompleteDeliveryData(sql);
      if(completeDeliveryData == null)
      {
        Debug.WriteLine("데이터 가져오기 실패");
        return;
      }
      //complete list에 데이터 넣기
      sql = string.Format(
        "INSERT INTO {0} VALUES(" +
        "NULL, {1}, {2}, {3}, '{4}', '{5}', '{6}', {7}, {8}, '{9}', '{10}', {11}, '{12}', NOW()" +
        ");",
        MyDatabase.completeListTbl,
        completeDeliveryData["trackingId"],
        completeDeliveryData["eId"],
        completeDeliveryData["sId"],
        completeDeliveryData["sAddr"],
        completeDeliveryData["sPhone"],
        completeDeliveryData["pName"],
        completeDeliveryData["pQty"],
        completeDeliveryData["pCode"],
        completeDeliveryData["bAddr"],
        completeDeliveryData["bPhone"],
        completeDeliveryData["bRegionCode"],
        completeDeliveryData["rvTime"]
        );
      result = insertCompleteData(sql);
      if (!result)
      {
        Debug.WriteLine("삽입 실패!");
        return;
      }
      getDeliveryList();
    }
    private bool insertCompleteData(string sql)
    {
      bool isSuccess = false;
      MyDatabase.cmd.CommandText = sql;
      try
      {
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if (result != -1) isSuccess = true;
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      return isSuccess;
    }
    private Dictionary<string, string> getCompleteDeliveryData(string sql)
    {
      Dictionary<string, string> data;

      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();

      try
      {
        if (!reader.Read())
        {
          Debug.WriteLine("읽기 실패");
          return null;
        }

        data = new Dictionary<string, string>()
        {
          {"trackingId", reader["tracking_id"].ToString() },
          {"sId", reader["s_id"].ToString() },
          {"eId", reader["e_id"].ToString() },
          {"sAddr", reader["s_addr"].ToString() },
          {"sPhone", reader["s_phone"].ToString() },
          {"pName", reader["p_name"].ToString() },
          {"pQty", reader["p_qty"].ToString() },
          {"pCode", reader["p_code"].ToString() },
          {"bAddr", reader["b_addr"].ToString() },
          {"bPhone", reader["b_phone"].ToString() },
          {"bRegionCode", reader["b_region_code"].ToString() },
          {"rvTime", reader["rv_time"].ToString().Replace(" 오전","").Replace(" 오후","") },
          {"rvStatus", reader["rv_status"].ToString() }
        };
        return data;
      }
      catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        reader.Close();
      }
      return null;
    }
    private bool updateStatus(string sql)
    {
      bool isSuccess = false;
      MyDatabase.cmd.CommandText = sql;
      try
      {
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if (result != -1) isSuccess = true;
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      return isSuccess;
    }

    private void btn_logout_Click(object sender, EventArgs e)
    {
      this.Close();
      new Login().Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      int count = getDelieveryCount();

      lb_count.Text = "배송 건수 : " + count;
      int salary = 1000000 + count * 10000;
      lb_salary.Text = String.Format("급여 : {0:#,0}", salary);
    }
  }
}
