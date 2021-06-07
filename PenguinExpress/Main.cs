using PenguinExpress.config;
using PenguinExpress.main;
using System;
using System.Windows.Forms;

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
      start();
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
