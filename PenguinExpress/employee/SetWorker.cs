using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenguinExpress.employee
{
  public partial class SetWorker : Form
  {
    Dictionary<string, string> data;
    public SetWorker(Dictionary<string, string> data)
    {
      this.data = data;
      InitializeComponent();
    }

    private void SetWorker_Load(object sender, EventArgs e)
    {
      label1.Text = string.Format("{0} {1} {2}", data["trackingId"], data["regionCode"], data["buyerAddr"]);
    }
  }
}
