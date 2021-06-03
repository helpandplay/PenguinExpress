using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PenguinExpress.seller;
using PenguinExpress.config;
using PenguinExpress.main;
using System.Diagnostics;

namespace PenguinExpress
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
      MyDatabase.onConnect();
      start();
    }
    private void start()
    {
      new Login().ShowDialog();
    }
    protected override void SetVisibleCore(bool value)
    {
      if (!this.IsHandleCreated)
      {
        this.CreateHandle();
        value = false;
      }
      base.SetVisibleCore(value);
    }

    private void Main_Load(object sender, EventArgs e)
    {
      SetVisibleCore(false);
    }
  }
}
