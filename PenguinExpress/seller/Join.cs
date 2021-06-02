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

    private void button1_Click(object sender, EventArgs e)
    {
      string userid = tb_id.Text;
      string sql = string.Format(
        "SELECT id " +
        "FROM {0} " +
        "WHERE userid='{1}';"
        , MyDatabase.sellerTbl, userid);
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

      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
    }
    private void addSeller()
    {
      string userid = tb_id.Text;
      string pwd = tb_pw.Text;
      string name = tb_name.Text;
      string phone = tb_phone1.Text + "-" + tb_phone2.Text + "-" + tb_phone3.Text;
      string addr = cb_addr_captital.Text + " " + tb_addr.Text;

      string sql = string.Format(
        "INSERT INTO {0} VALUES( " +
        "NULL, '{1}', '{2}', '{3}', '{4}', '{5}');"
        , MyDatabase.sellerTbl, userid, pwd, name, addr, phone);

      MyDatabase.cmd.CommandText = sql;
      try
      {
        MyDatabase.cmd.ExecuteNonQuery();
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        this.Close();
      }
    }

    private void btn_onJoin_Click(object sender, EventArgs e)
    {
      string result = validateSeller();
      if (result != "OK")
      {
        MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      addSeller();
    }
    private string validateSeller()
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


  }
}
