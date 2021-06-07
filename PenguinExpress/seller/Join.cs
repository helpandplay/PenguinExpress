using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PenguinExpress.config;
using PenguinExpress.main;
using System.Diagnostics;

namespace PenguinExpress.seller
{
  public partial class Join : Form
  {
    bool isCorrectID = false;
    public Join()
    {
      InitializeComponent();
    }
    private void setColor()
    {
      this.BackColor = ColorTranslator.FromHtml(Env.baseColor);
      this.ForeColor = ColorTranslator.FromHtml(Env.textColor);
      this.Font = Env.font;

      //btn
      btn_cancel.ForeColor = ColorTranslator.FromHtml(Env.textBrightColor);
      btn_onJoin.ForeColor = ColorTranslator.FromHtml(Env.textBrightColor);
      button1.ForeColor = ColorTranslator.FromHtml(Env.textBrightColor);

      btn_onJoin.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
      btn_cancel.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);
      button1.BackColor = ColorTranslator.FromHtml(Env.contentStrongColor);

      btn_cancel.Font = Env.boldFont;
      btn_onJoin.Font = Env.boldFont;
      button1.Font = Env.boldFont;
    }

    private void checkOverlapId(string sql) {
      MyDatabase.cmd.CommandText = sql;

      try
      {
        object result = MyDatabase.cmd.ExecuteScalar();
        if (result != null)
        {
          MessageBox.Show("이미 존재하는 아이디입니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
          isCorrectID = false;
          return;
        }
        MessageBox.Show("사용 가능한 아이디입니다.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        isCorrectID = true;
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.StackTrace);
        Debug.WriteLine(error.Message);
      }
    }
    private void button1_Click(object sender, EventArgs e)
    {
      string userid = tb_id.Text;
      if(userid == "")
      {
        MessageBox.Show("아이디를 입력해주세요.");
        return;
      }
      if(userid.Length < 2 || userid.Length > 12)
      {
        MessageBox.Show("2~12자리만 사용할 수 있습니다.");
        return;
      }
      string sql;
      if (cb_isEmployee.Checked)
      {
        sql = string.Format("" +
          "SELECT id " +
          "FROM {0} " +
          "WHERE userid='{1}';",
          MyDatabase.employeeTbl, userid);
      }
      else
      {
            sql   = string.Format(
        "SELECT id " +
        "FROM {0} " +
        "WHERE userid='{1}';"
        , MyDatabase.sellerTbl, userid);
      }
      checkOverlapId(sql);
    }
    private void addUser(bool isEmployee)
    {
      string userid = tb_id.Text;
      string pwd = tb_pw.Text;
      string name = tb_name.Text;
      string phone = tb_phone1.Text + "-" + tb_phone2.Text + "-" + tb_phone3.Text;
      string addr = cb_addr_captital.Text + " " + tb_addr.Text;
      int regionCode = cb_addr_captital.SelectedIndex;

      string salt = SHA256Hash.getSalt();
      string hashedPwd = SHA256Hash.hashing(pwd, salt);

      string sql;
      if (isEmployee)
      {
        sql = string.Format("" +
          "INSERT INTO {0} VALUES (" +
          "NULL, '{1}', '{2}', '{3}', '{4}', {5}, 0, false, false, '{6}');"
          , MyDatabase.employeeTbl, userid, hashedPwd, name, phone, regionCode, salt); ;
      }
      else
      {
        sql = string.Format(
        "INSERT INTO {0} VALUES( " +
        "NULL, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');"
        , MyDatabase.sellerTbl, userid, hashedPwd, name, addr, phone, salt);
      }

      MyDatabase.cmd.CommandText = sql;
      try
      {
        MyDatabase.cmd.ExecuteNonQuery();
      }catch(Exception error)
      {
        Debug.WriteLine(error.StackTrace);
        Debug.WriteLine(error.Message);
      }
      finally
      {
        this.Close();
      }
    }
    private void btn_onJoin_Click(object sender, EventArgs e)
    {
      string result = validateJoin();
      bool isEmployee = cb_isEmployee.Checked;
      if (result != "OK")
      {
        MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      addUser(isEmployee);
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
    private void cb_isEmployee_CheckedChanged(object sender, EventArgs e)
    {
      isCorrectID = false;
    }
  }
}
