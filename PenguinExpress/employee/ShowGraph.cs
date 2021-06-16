using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PenguinExpress.config;

namespace PenguinExpress.employee
{
  public partial class ShowGraph : Form
  {
    Dictionary<int, int> data;
    Status stus;
    string type;
    int total;
    public ShowGraph(Dictionary<int, int>data, int total, string type)
    {
      this.type = type;
      this.data = data;
      this.total = total;
      stus = new Status();
      InitializeComponent();
    }
    private void setColor()
    {
      //base
      this.BackColor = ColorTranslator.FromHtml(Styles.light);
      this.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      this.Font = Styles.font;

      chart.BackColor = ColorTranslator.FromHtml(Styles.light);
      chart.ForeColor = ColorTranslator.FromHtml(Styles.dark);
    }
    private void ShowGraph_Load(object sender, EventArgs e)
    {
      setColor();
      chart.Series[0].ChartType = SeriesChartType.Doughnut;
      foreach(KeyValuePair<int, int> item in data)
      {
        int percent = item.Value * 100 / total;
        string itemName = type == "item" ? stus.getItemName(item.Key) : stus.getRegionName(item.Key);
        chart.Series[0].Points.AddXY(string.Format("{0} {1}%", itemName, percent), item.Value);
      }

    }
  }
}
