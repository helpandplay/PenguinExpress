using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PenguinExpress.employee
{
  public partial class Deliever : Form
  {
    string id;
    public Deliever(string id)
    {
      this.id = id;
      InitializeComponent();
    }

    private void Deliever_Load(object sender, EventArgs e)
    {
      label1.Text = id;
    }

    private void Deliever_FormClosed(object sender, FormClosedEventArgs e)
    {
      
    }
  }
}
