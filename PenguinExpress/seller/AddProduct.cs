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
using PenguinExpress.config;

namespace PenguinExpress.seller
{
  public partial class AddProduct : Form
  {
    Dictionary<string, string> seller;
    public AddProduct(Dictionary<string, string> seller)
    {
      this.seller = seller;
      InitializeComponent();
      setSellerInfo();
    }
    private void setColor()
    {
      //base
      this.BackColor = ColorTranslator.FromHtml(Env.baseColor);
      this.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      this.Font = Env.font;

      //btn
      btn_addProduct.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
      btn_cancel.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);

      btn_addProduct.ForeColor = ColorTranslator.FromHtml(Env.textBrightColor);
      btn_cancel.ForeColor = ColorTranslator.FromHtml(Env.textBrightColor);

      btn_cancel.Font = Env.boldFont;
      btn_addProduct.Font = Env.boldFont;
    }
    private void setSellerInfo()
    {
      tb_s_name.Text = seller["name"];
      tb_s_phone.Text = seller["phone"];
      tb_s_addr.Text = seller["addr"];
    }

    private void btn_cancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    private bool checkVaildate()
    {
      if (tb_p_name.Text == "") return false;
      if (tb_p_qty.Text == "") return false;
      if (cb_p_choice.SelectedItem == null) return false;
      if (tb_b_name.Text == "") return false;
      if (tb_b_phone2.Text == "") return false;
      if (tb_b_phone3.Text == "") return false;
      if (tb_b_addr.Text == "") return false;

      return true;
    }
    private void btn_addProduct_Click(object sender, EventArgs e)
    {
      bool result = checkVaildate();
      if (!result)
      {
        MessageBox.Show("빠진 양식이 있습니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      int sId = int.Parse(seller["id"]);
      string pName = tb_p_name.Text;
      int pQty = int.Parse(tb_p_qty.Text);
      int pCode = cb_p_choice.SelectedIndex + 1;
      string sName = tb_s_name.Text;
      string sPhone = tb_s_phone.Text;
      string sAddr = tb_s_addr.Text;
      string bName = tb_b_name.Text;
      string bPhone = string.Format("{0}-{1}-{2}", tb_b_phone.Text, tb_b_phone2.Text, tb_b_phone3.Text);
      string bAddr = string.Format("{0} {1}", cb_b_addr_captital.SelectedItem.ToString(), tb_b_addr.Text);
      int regionCode = cb_b_addr_captital.SelectedIndex + 1;

      string sql = string.Format(
        "INSERT INTO {0} VALUES(" +
        "NULL, {1}, NULL, '{2}', '{3}', '{4}', {5}, {6},'{7}','{8}',{9},NOW(),1);"
        , MyDatabase.reservationListTbl, sId, sAddr, sPhone, pName, pQty, pCode, bAddr, bPhone, regionCode);
      MyDatabase.cmd.CommandText = sql;

      try
      {
        MyDatabase.cmd.ExecuteNonQuery();
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
        Debug.WriteLine(error.StackTrace);
      }
      finally
      {
        Debug.Close();
        this.Close();
      }
    }
    private void tb_p_qty_KeyPress(object sender, KeyPressEventArgs e)
    {
      checkOnlyNumberKeyPress(e);
    }
    private void tb_b_phone2_KeyPress(object sender, KeyPressEventArgs e)
    {
      checkOnlyNumberKeyPress(e);
    }
    private void tb_b_phone3_KeyPress(object sender, KeyPressEventArgs e)
    {
      checkOnlyNumberKeyPress(e);
    }
    private void checkOnlyNumberKeyPress(KeyPressEventArgs e)
    {
      e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }

    private void AddProduct_Load(object sender, EventArgs e)
    {
      setColor();
    }
  }
}
