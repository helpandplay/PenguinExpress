﻿using System;
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
      catch(Exception error)
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
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      return false;
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