using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PenguinExpress.employee
{
  public partial class ShowGraph : Form
  {
    Dictionary<int, int> data;
    Status stus;
    int total;
    public ShowGraph(Dictionary<int, int>data, int total)
    {
      this.data = data;
      this.total = total;
      stus = new Status();
      InitializeComponent();
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
      chart.Series[0].ChartType = SeriesChartType.Doughnut;
      foreach(KeyValuePair<int, int> item in data)
      {
        int percent = item.Value * 100 / total;
        string itemName = stus.getItemName(item.Key);
        chart.Series[0].Points.AddXY(string.Format("{0} {1}%", itemName, percent), item.Value);
      }

    }
  }
}
