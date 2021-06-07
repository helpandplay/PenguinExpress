using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PenguinExpress.employee
{
  public partial class ShowGraph : Form
  {
    Dictionary<int, int> data;
    Status stus;
    string type;
    int total;
    public ShowGraph(Dictionary<int, int> data, int total, string type)
    {
      this.data = data;
      this.total = total;
      this.type = type;
      stus = new Status();
      InitializeComponent();
    }
    private void showItemGraph()
    {
      chart.Series[0].ChartType = SeriesChartType.Doughnut;
      foreach (KeyValuePair<int, int> item in data)
      {
        int percent = item.Value * 100 / total;
        string itemName = stus.getItemName(item.Key);
        chart.Series[0].Points.AddXY(string.Format("{0} {1}%", itemName, percent), item.Value);
      }
    }
    private void showRegionGraph()
    {
      chart.Series[0].ChartType = SeriesChartType.Pie;
      foreach (KeyValuePair<int, int> item in data)
      {
        int percent = item.Value * 100 / total;
        string itemName = stus.getRegionName(item.Key);
        chart.Series[0].Points.AddXY(string.Format("{0} {1}%", itemName, percent), item.Value);
      }
    }
    private void getGraphType(string type)
    {
      switch (type)
      {
        case "item":
          showItemGraph();
          return;
        case "region":
          showRegionGraph();
          return;
        default:
          throw new Exception("알수 없는 타입 : " + type);
      }
    }
    private void setColor()
    {
      //base
      this.BackColor = ColorTranslator.FromHtml(Env.baseColor);
      this.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      this.Font = Env.font;
    }
    private void ShowGraph_Load(object sender, EventArgs e)
    {
      setColor();
      getGraphType(type);
    }
  }
}
