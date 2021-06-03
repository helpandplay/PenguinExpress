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
      lb_id.Text = id;
    }
  }
}
