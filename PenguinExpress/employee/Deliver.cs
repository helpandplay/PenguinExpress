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

namespace PenguinExpress.employee
{
  public partial class Deliver : Form
  {
    string id;
    EmployeeEntity employeeEntity = EmployeeEntity.getEmployee();
    ReservationEntity reservationEntity = ReservationEntity.getReservationEntity();
    EmployeeService employee = new EmployeeService();
    Reservation reservation = new Reservation();
    CompleteService complete = new CompleteService();
    public Deliver(string id)
    {
      this.id = id;
      InitializeComponent();
    }
    private void setColor()
    {
      //base
      this.BackColor = ColorTranslator.FromHtml( Styles.light);
      this.ForeColor = ColorTranslator.FromHtml(Styles.light);
      this.Font = Styles.font;

      lv_delivery_list.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      lv_delivery_list.BackColor = ColorTranslator.FromHtml(Styles.light);
      lv_delivery_list.BorderStyle = BorderStyle.FixedSingle;
      lv_delivery_list.Font = Styles.font;
      //btn
      btn_completeDelivery.Font = Styles.boldFont;
      btn_refresh.Font = Styles.boldFont;
      button2.Font = Styles.boldFont;

      btn_completeDelivery.FlatStyle = FlatStyle.Flat;
      btn_refresh.FlatStyle = FlatStyle.Flat;
      button2.FlatStyle = FlatStyle.Flat;

      btn_completeDelivery.BackColor = ColorTranslator.FromHtml(Styles.info);
      btn_refresh.BackColor = ColorTranslator.FromHtml(Styles.success);
      button2.BackColor = ColorTranslator.FromHtml(Styles.info);

      btn_completeDelivery.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_refresh.ForeColor = ColorTranslator.FromHtml(Styles.light);
      button2.ForeColor = ColorTranslator.FromHtml(Styles.light);

      lb_count.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      lb_salary.ForeColor = ColorTranslator.FromHtml(Styles.dark);
    }
    private void getDeliveryList()
    {
      List<Dictionary<string, string>> list = reservation.findAll();
      try
      {
        lv_delivery_list.Items.Clear();
        foreach (Dictionary<string, string> data in list)
        {
          string eID = data[reservationEntity.employeeID].ToString();
          string rvStatus = data[reservationEntity.rvStatus].ToString();

          if (eID != id || rvStatus != "2") continue;

          ListViewItem lvi;

          string trackingId = data[reservationEntity.trackingID].ToString();
          string pName = data[reservationEntity.prodName].ToString();
          string pQty = data[reservationEntity.prodQty].ToString();
          string bAddr = data[reservationEntity.buyAddr].ToString();
          string bPhone = data[reservationEntity.buyPhone].ToString();
          string sPhone = data[reservationEntity.sellerPhone].ToString();

          lvi = new ListViewItem(new string[] { trackingId, pName, pQty, bAddr, bPhone, sPhone });
          lv_delivery_list.Items.Add(lvi);
        }
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
    }
    private int getDelieveryCount()
    {
      int count;
      Dictionary<string, string> delivery = employee.findOne(id);
      count = int.Parse(delivery[employeeEntity.cpCount].ToString());

      return count;
    }
    private void completeDelivery(string trackingId)
    {
      bool result = reservation.updateReservation(trackingId, reservationEntity.rvStatus, "3");
      if (!result)
      {
        Debug.WriteLine("상태 업데이트 실패");
        return;
      }

      Dictionary<string, string> completeDeliveryData = reservation.findOne(trackingId);
      if (completeDeliveryData == null)
      {
        Debug.WriteLine("데이터 가져오기 실패");
        return;
      }

      result = complete.addComplete(completeDeliveryData);
      if (!result)
      {
        Debug.WriteLine("삽입 실패!");
        return;
      }

      getDeliveryList();
    }
    private void updateCount()
    {
      int count = getDelieveryCount();
      if (count == -1)
      {
        Debug.WriteLine("배송 횟수 가져오는 데 실패");
        return;
      }
      bool result = employee.updateEmployee(id, employeeEntity.cpCount, (count+1).ToString());
      if (!result)
      {
        Debug.WriteLine("배송 횟수 업데이트 하는 데 실패");
        return;
      }

    }
    private void btn_refresh_Click(object sender, EventArgs e)
    {
      getDeliveryList();
    }
    private void deleteReservationItem(string trackingId)
    {
      bool result = reservation.removeOne(trackingId);
      if (!result)
      {
        Debug.WriteLine("배송 삭제 실패");
        return;
      }
    }
    private void lv_delivery_list_DoubleClick(object sender, EventArgs e)
    {
      DialogResult result = MessageBox.Show("배송 완료하셨습니까?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == DialogResult.No) return;

      ListView lv = sender as ListView;
      string trackingId = lv.SelectedItems[0].SubItems[0].Text;

      completeDelivery(trackingId);
      updateCount();
      deleteReservationItem(trackingId);
    }
    private void btn_completeDelivery_Click(object sender, EventArgs e)
    {
      if (lv_delivery_list.SelectedItems.Count == 0) return;
      DialogResult result = MessageBox.Show("배송 완료하셨습니까?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (result == DialogResult.No) return;

      string trackingId = lv_delivery_list.SelectedItems[0].SubItems[0].Text;

      completeDelivery(trackingId);
      updateCount();
      deleteReservationItem(trackingId);
    }
    private void Deliver_Load(object sender, EventArgs e)
    {
      setColor();
      //자기 지역번호 가져오기
      lb_dv_id.Text = lb_dv_id.Text + id;

      getDeliveryList();
    }
    private void salaryClick(object sender, EventArgs e)
    {
      int count = getDelieveryCount();
      Debug.WriteLine(count);
      lb_count.Text = "배송 건수 : " + count;
      int salary = 1000000 + count * 10000;
      lb_salary.Text = String.Format("급여 : {0:#,0}", salary);
    }
  }
}
