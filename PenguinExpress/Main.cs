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

namespace PenguinExpress
{
  public partial class Main : Form
  {
    public Main()
    {
      InitializeComponent();
      MyDatabase.onConnect();
      onLoadSellerDashBoard();
    }
    private void onLoadSellerDashBoard()
    {
      new Join().ShowDialog();
      //new Seller_list(1).ShowDialog();
    }
  }
}
