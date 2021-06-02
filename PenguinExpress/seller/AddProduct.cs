using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenguinExpress.seller
{
  public partial class AddProduct : Form
  {
    Seller_list sellerList;
    Dictionary<string, string> seller;
    public AddProduct(Dictionary<string, string>seller, Seller_list sellerList)
    {
      this.sellerList = sellerList;
      this.seller = seller;
      InitializeComponent();
    }
  }
}
