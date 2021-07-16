using MySql.Data.MySqlClient;
using PenguinExpress.config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PenguinExpress.service;
using PenguinExpress.entity;

namespace PenguinExpress.employee
{
  public partial class Admin : Form
  {
    CompleteService complete = new CompleteService();
    CompleteEntity completeEntity = CompleteEntity.getComplete();
    Reservation reservation = new Reservation();
    ReservationEntity reservationEntity = ReservationEntity.getReservationEntity();

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
      this.BackColor = ColorTranslator.FromHtml(Styles.light);
      this.ForeColor = ColorTranslator.FromHtml(Styles.light);
      this.Font = Styles.font;

      tabPage1.BackColor = ColorTranslator.FromHtml(Styles.primary);
      tabPage2.BackColor = ColorTranslator.FromHtml(Styles.primary);

      lv_complete.BackColor = ColorTranslator.FromHtml(Styles.blueGray);
      lv_delivery.BackColor = ColorTranslator.FromHtml(Styles.blueGray);
      lv_complete.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      lv_delivery.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      //btn
      btn_getItemGraph.BackColor = ColorTranslator.FromHtml(Styles.success);
      btn_getRegionGraph.BackColor = ColorTranslator.FromHtml(Styles.success);
      btn_refresh.BackColor = ColorTranslator.FromHtml(Styles.success);

      btn_getItemGraph.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_getRegionGraph.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_refresh.ForeColor = ColorTranslator.FromHtml(Styles.light);

      btn_getItemGraph.FlatStyle = FlatStyle.Flat;
      btn_getRegionGraph.FlatStyle = FlatStyle.Flat;
      btn_refresh.FlatStyle = FlatStyle.Flat;

      btn_getItemGraph.Font = Styles.boldFont;
      btn_getRegionGraph.Font = Styles.boldFont;
      btn_refresh.Font = Styles.boldFont;

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
      List<Dictionary<string, string>> list = complete.findAll();

      try
      {
        lv_complete.Items.Clear();

        foreach(Dictionary<string, string> data in list)
        {
          string trackingId = data[completeEntity.trackingID].ToString();
          string sellerId = data[completeEntity.sellerID].ToString();
          string sellerPhone = data[completeEntity.sellerPhone].ToString();
          string buyerPhone = data[completeEntity.buyPhone].ToString();
          string delieverId = data[completeEntity.employeeID].ToString();
          string rvTime = data[completeEntity.rvTime].ToString();
          string cpTime = data[completeEntity.cpTime].ToString();

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
    }
    private void getDeliveryList()
    {
      List<Dictionary<string, string>> list = reservation.findAll();

      try
      {
        lv_delivery.Items.Clear();

        foreach (Dictionary<string, string> data in list)
        {
          string rvStatus = data[reservationEntity.rvStatus].ToString();

          if (rvStatus == "-1" || rvStatus == "3") continue;
          rvStatus = getDeliveryStatus(rvStatus);
          string regionCode = data[reservationEntity.buyRegionCode].ToString();
          string trackingId = data[reservationEntity.trackingID].ToString();
          string sellerId = data[reservationEntity.sellerID].ToString();
          string prodName = data[reservationEntity.prodName].ToString();
          string prodQty = data[reservationEntity.prodQty].ToString();
          string prodCode = data[reservationEntity.prodCode].ToString();

          string rvTime = data[reservationEntity.rvTime].ToString();
          string eId = data[reservationEntity.employeeID].ToString();


          string[] row = new string[] { trackingId, sellerId, prodName, prodQty, prodCode, regionCode, rvTime, eId, rvStatus };
          ListViewItem lvi = new ListViewItem(row);
          lv_delivery.Items.Add(lvi);
        }
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
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
      // 기사가 배정이 안된다.
      Dictionary<string, string> rowData;
      var lvi = sender as ListView;
      string status = lvi.SelectedItems[0].SubItems[8].Text;

      if (status != "배정 대기중") return;
      string trackingId = lvi.SelectedItems[0].SubItems[0].Text;

      rowData = reservation.findOne(trackingId);
      new SetWorker(rowData, this).ShowDialog();
      getDeliveryList();
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
      new ShowGraph(data, total, "item").ShowDialog();
    }
    private int getItemTotal()
    {
      int total;

      List<Dictionary<string,string>> list = complete.findAll();
      total = list.Count;

      return total;
    }
    private void btn_getRegionGraph_Click(object sender, EventArgs e)
    {
      Dictionary<int, int> data = getRegionGraphData();
      int total = getItemTotal();
      if (total == -1)
      {
        MessageBox.Show("총 개수 불러오는 오류 발생");
        return;
      }
      new ShowGraph(data, total, "region").ShowDialog();
    }
    private Dictionary<int, int> getItemGraphData()
    {
      Dictionary<int, int> data = new Dictionary<int, int>();
      data = complete.GroupingData(completeEntity.prodCode);

      return data;
    }
    private Dictionary<int, int> getRegionGraphData()
    {
      Dictionary<int, int> data = new Dictionary<int, int>();
      data = complete.GroupingData(completeEntity.buyRegionCode);

      return data;
    }
    private void btn_refresh_Click(object sender, EventArgs e)
    {
      if (listTab.SelectedIndex == 0) getDeliveryList();
      else getCompleteList();
    }
  }
}
