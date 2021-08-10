using PenguinExpress.config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PenguinExpress.entity;
using PenguinExpress.service;

namespace PenguinExpress.seller
{
  public partial class AddProduct : Form
  {
    readonly SellerEntity sellerEntity = SellerEntity.getSellerEntity();
    readonly ReservationEntity reservationEntity = ReservationEntity.getReservationEntity();
    readonly Reservation reservation = new Reservation();
    Dictionary<string, string> user;
    public AddProduct(Dictionary<string, string> user)
    {
      this.user = user;
      InitializeComponent();
      setSellerInfo();
    }
    private void setColor()
    {
      //base
      this.BackColor = ColorTranslator.FromHtml(Styles.light);
      this.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      this.Font = Styles.font;

      //btn
      btn_addProduct.BackColor = ColorTranslator.FromHtml(Styles.success);
      btn_cancel.BackColor = ColorTranslator.FromHtml(Styles.warning);

      btn_addProduct.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_cancel.ForeColor = ColorTranslator.FromHtml(Styles.light);

      btn_cancel.Font = Styles.boldFont;
      btn_addProduct.Font = Styles.boldFont;
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
/*      int sId = int.Parse(user["id"]);
      string pName = tb_p_name.Text;
      int pQty = int.Parse(tb_p_qty.Text);
      int pCode = cb_p_choice.SelectedIndex;
      string sName = tb_s_name.Text;
      string sPhone = tb_s_phone.Text;
      string sAddr = tb_s_addr.Text;
      string bName = tb_b_name.Text;
      string bPhone = string.Format("{0}-{1}-{2}", tb_b_phone.Text, tb_b_phone2.Text, tb_b_phone3.Text);
      string bAddr = string.Format("{0} {1}", cb_b_addr_captital.SelectedItem.ToString(), tb_b_addr.Text);
      int regionCode = cb_b_addr_captital.SelectedIndex;*/

      Dictionary<string, string> data = new Dictionary<string, string>();

      data.Add(sellerEntity.id, user["id"]);
      data.Add(reservationEntity.prodName, tb_p_name.Text);
      data.Add(reservationEntity.prodQty, tb_p_qty.Text);
      data.Add(sellerEntity.name, tb_s_name.Text);
      data.Add(sellerEntity.phone, tb_s_phone.Text);
      data.Add(reservationEntity.buyPhone, string.Format("{0}-{1}-{2}", tb_b_phone.Text, tb_b_phone2.Text, tb_b_phone3.Text));
      data.Add(reservationEntity.buyAddr, string.Format("{0} {1}", cb_b_addr_captital.SelectedItem.ToString(), tb_b_addr.Text));
      data.Add(reservationEntity.buyRegionCode, cb_b_addr_captital.SelectedIndex.ToString());

      result = reservation.addReservation(data);
      if (!result)
      {
        MessageBox.Show("택배 예약에 실패했습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
/*      string sql = string.Format(
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
      }*/
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
