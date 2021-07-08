using MySql.Data.MySqlClient;
using PenguinExpress.config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PenguinExpress.entity;
using PenguinExpress.service;

namespace PenguinExpress.employee
{
  public partial class SetWorker : Form
  {
    EmployeeEntity employeeEntity = EmployeeEntity.getEmployee();
    ReservationEntity reservationEntity = ReservationEntity.getReservationEntity();
    Reservation reservation = new Reservation();

    EmployeeService employee = new EmployeeService();
    struct workerInfo{
      public string id;
      public string name;
      public string userid;
      public workerInfo(string id, string name, string userid)
      {
        this.id = id;
        this.name = name;
        this.userid = userid;
      }
    }
    Dictionary<string, string> data;
    List<workerInfo> workerList;
    Admin admin;
    public SetWorker(Dictionary<string, string> data, Admin admin)
    {
      this.admin = admin;
      this.data = data;
      InitializeComponent();
    }
    private void setColor()
    {
      //base
      this.BackColor = ColorTranslator.FromHtml(Styles.light);
      this.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      this.Font = Styles.font;
      //btn
      btn_ok.Font = Styles.boldFont;
      btn_cancel.Font = Styles.boldFont;
      btn_cancel.FlatStyle = FlatStyle.Flat;
      btn_ok.FlatStyle = FlatStyle.Flat;

      btn_cancel.BackColor = ColorTranslator.FromHtml(Styles.success);
      btn_cancel.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_ok.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_ok.BackColor = ColorTranslator.FromHtml(Styles.warning);
    }
    private List<workerInfo> getRegionWorker(string region)
    {
      List<workerInfo> workerInfo = new List<workerInfo>();

      List<Dictionary<string, string>> list = employee.findAll();
      //여기 왜 반복문이 없지?
      


      try
      {
        foreach (Dictionary<string, string> data in list)
        {
          if (data[reservationEntity.buyRegionCode].ToString() != region) continue;

          workerInfo info = new workerInfo(
            data[employeeEntity.id].ToString(),
            data[employeeEntity.name].ToString(),
            data[employeeEntity.userid].ToString()
            );
          workerInfo.Add(info);
        }
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      return workerInfo;
    }
    private bool setDelivery(workerInfo worker)
    {
      bool isSuccess;
      string dv_id = worker.id;
      string trackingId = data[reservationEntity.trackingID];

      isSuccess = reservation.updateReservation(trackingId, reservationEntity.employeeID, dv_id);
      return isSuccess;
    }
    private void btn_ok_Click(object sender, EventArgs e)
    {
      if (cb_workers.SelectedItem == null)
      {
        MessageBox.Show("기사를 배정해주세요.");
        return;
      }
      string id = cb_workers.SelectedItem.ToString().Split(':')[1];
      int idx = -1;
     
      for(int i=0; i<workerList.Count; i++)
      {
        if (workerList[i].id == id)
        {
          idx = i;
          break;
        }
      }
      workerInfo worker = new workerInfo(workerList[idx].id, workerList[idx].name, workerList[idx].userid);
      bool isSuccess = setDelivery(worker);
      if (isSuccess)
      {
        // 배정 대기중 -> 배송중으로 바꾸고 dv_id 부여
        bool result = admin.updateWorker(workerList[idx].id, data[reservationEntity.trackingID]);
        if (!result) MessageBox.Show("배정 업데이트에 실패했습니다.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        else this.Close();
      }
      else
      {
        MessageBox.Show("배정에 실패했습니다.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }
    private void btn_cancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    private void SetWorker_Load(object sender, EventArgs e)
    {
      setColor();
      lb_trackingId.Text = data[reservationEntity.trackingID];
      lb_region.Text = data[reservationEntity.buyRegionCode];

      workerList = getRegionWorker(data[reservationEntity.buyRegionCode]);
      foreach(var worker in workerList)
      {
        cb_workers.Items.Add(string.Format("{0}:{1}",worker.name, worker.id));
      }
    }
  }
}
