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
    public SetWorker(Dictionary<string, string> data)
    {
      this.data = data;
      InitializeComponent();
    }

    private void SetWorker_Load(object sender, EventArgs e)
    {
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
      setDelivery(worker);
    }
    private void setDelivery(workerInfo worker)
    {
      string dv_id = worker.id;
      string trackingId = data["trackingId"];
      string name = worker.name;
      string regionCode = data["regionCode"];
      string buyerAddr = data["buyerAddr"];

      string sql = string.Format(
        "INSERT INTO {0} VALUES (NULL, {1}, {2}, '{3}', {4}, '{5}');"
        , MyDatabase.deliverList, dv_id, trackingId, name, regionCode, buyerAddr);
      MyDatabase.cmd.CommandText = sql;
      try
      {
        MyDatabase.cmd.ExecuteNonQuery();
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
    }
  }
}
