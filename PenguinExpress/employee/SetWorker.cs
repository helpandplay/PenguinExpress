using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PenguinExpress.config;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace PenguinExpress.employee
{
  public partial class SetWorker : Form
  {
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
      this.BackColor = ColorTranslator.FromHtml(Env.baseColor);
      this.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      //btn
      btn_cancel.FlatStyle = FlatStyle.Flat;
      btn_ok.FlatStyle = FlatStyle.Flat;

      btn_cancel.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
      btn_cancel.ForeColor = ColorTranslator.FromHtml(Env.textBrightColor);
      btn_ok.ForeColor = ColorTranslator.FromHtml(Env.textBrightColor);
      btn_ok.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
    }
    private void SetWorker_Load(object sender, EventArgs e)
    {
      setColor();
      lb_trackingId.Text = data["trackingId"];
      lb_region.Text = data["regionCode"];

      workerList = getRegionWorker(data["regionCode"]);
      foreach(var worker in workerList)
      {
        cb_workers.Items.Add(string.Format("{0}:{1}",worker.name, worker.id));
      }

    }
    private List<workerInfo> getRegionWorker(string region)
    {
      List<workerInfo> workerInfo = new List<workerInfo>();
      string sql = string.Format(
        "SELECT id, userid, name " +
        "FROM {0} " +
        "WHERE region_code = {1};"
        , MyDatabase.employeeTbl, region);
      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();

      try
      {
        if (!reader.Read())
        {
          throw new Exception("불러온 값이 없습니다.");
        }
        workerInfo info = new workerInfo(
          reader["id"].ToString(),
          reader["name"].ToString(),
          reader["userid"].ToString()
          );
        workerInfo.Add(info);
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        reader.Close();
      }
      return workerInfo;
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
        bool result = admin.updateWorker(workerList[idx].id, data["trackingId"]);
        if (!result) MessageBox.Show("배정 업데이트에 실패했습니다.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        else this.Close();
      }
      else
      {
        MessageBox.Show("배정에 실패했습니다.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }
    private bool setDelivery(workerInfo worker)
    {
      bool isSuccess = false;
      string dv_id = worker.id;
      string trackingId = data["trackingId"];
      string name = worker.name;
      string regionCode = data["regionCode"];
      string buyerAddr = data["buyerAddr"];

      string sql = string.Format(
        "UPDATE {0} SET e_id = {1} WHERE tracking_id = {2};"
        , MyDatabase.reservationListTbl, dv_id, trackingId);
      MyDatabase.cmd.CommandText = sql;
      try
      {
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if (result != -1) return true;
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      return false;
    }

    private void btn_cancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
