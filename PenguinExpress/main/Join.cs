using PenguinExpress.config;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using PenguinExpress.service;
using System.Collections.Generic;
using PenguinExpress.entity;

namespace PenguinExpress.seller
{
  public partial class Join : Form
  {
    bool isCorrectID = false;
    Auth auth = new Auth();

    public Join()
    {
      InitializeComponent();
    }
    private void setColor()
    {
      this.BackColor = ColorTranslator.FromHtml(Styles.light);
      this.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      this.Font = Styles.font;

      //btn
      btn_cancel.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_onJoin.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_checkID.ForeColor = ColorTranslator.FromHtml(Styles.light);

      btn_onJoin.BackColor = ColorTranslator.FromHtml(Styles.success);
      btn_cancel.BackColor = ColorTranslator.FromHtml(Styles.warning);
      btn_checkID.BackColor = ColorTranslator.FromHtml(Styles.success);

      btn_cancel.Font = Styles.boldFont;
      btn_onJoin.Font = Styles.boldFont;
      btn_checkID.Font = Styles.boldFont;

      btn_cancel.FlatStyle = FlatStyle.Flat;
      btn_onJoin.FlatStyle = FlatStyle.Flat;
      btn_checkID.FlatStyle = FlatStyle.Flat;

    }
    private Dictionary<string, string> getJoinData(bool isEmployee)
    {
      Dictionary<string, string> userData = new Dictionary<string, string>();

      userData.Add("userid", tb_id.Text);
      userData.Add("pwd", tb_pw.Text);
      userData.Add("name", tb_name.Text);
      userData.Add("phone", tb_phone1.Text + "-" + tb_phone2.Text + "-" + tb_phone3.Text);
      userData.Add("addr", cb_addr_captital.Text + " " + tb_addr.Text);
      userData.Add("region_code", cb_addr_captital.SelectedIndex.ToString());

      return userData;
    }
    private void btn_checkID_Click(object sender, EventArgs e)
    {
      string userid = tb_id.Text;
      bool isEmployee = cb_isEmployee.Checked;
      string result = auth.checkOverlapId(userid, isEmployee);
      if (result != "사용 가능한 아이디입니다.")
        isCorrectID = false;
      else
        isCorrectID = true;
      MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
    } //완료
    private void btn_cancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    private void btn_onJoin_Click(object sender, EventArgs e)
    {
      string isVaild = validateJoin();
      bool isEmployee = cb_isEmployee.Checked;
      if (isVaild != "OK")
      {
        MessageBox.Show(isVaild, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      Dictionary<string, string> userData = getJoinData(isEmployee);
      bool result = auth.addUser(userData, isEmployee);

      if (!result){
        MessageBox.Show("회원가입에 실패했습니다");
        return;
      }
      this.Close();
    }
    private string validateJoin()
    {
      if (!isCorrectID) return "중복 확인을 해주세요.";
      if (tb_pw.Text != tb_pw_verify.Text) return "비밀번호가 일치하지 않습니다.";
      if (tb_name.Text == "" || tb_phone2.Text == "" || tb_phone3.Text == "" || tb_addr.Text == "" || cb_addr_captital.SelectedIndex == -1)
      {
        return "입력하지 않은 항목이 있습니다.";
      }
      return "OK";
    }
    private void cb_isEmployee_CheckedChanged(object sender, EventArgs e)
    {
      isCorrectID = false;
    }
    private void tb_phone2_KeyPress(object sender, KeyPressEventArgs e)
    {
      checkOnlyNumberKeyPress(e);
    }
    private void tb_phone3_KeyPress(object sender, KeyPressEventArgs e)
    {
      checkOnlyNumberKeyPress(e);
    }
    private void checkOnlyNumberKeyPress(KeyPressEventArgs e)
    {
      e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }
    private void Join_Load(object sender, EventArgs e)
    {
      setColor();
    }


  }
}
