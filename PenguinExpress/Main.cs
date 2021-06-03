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
using PenguinExpress.employee;

namespace PenguinExpress
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
      MyDatabase.onConnect();
      SetVisibleCore(false);
    }
    private void start()
    {
      new Login().ShowDialog();
    }

    private void Main_Load(object sender, EventArgs e)
    {
      //start();
      new Admin("50000").ShowDialog();
      this.Close();
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
  }
}
