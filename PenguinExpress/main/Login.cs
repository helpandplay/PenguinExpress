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
using PenguinExpress.seller;
using PenguinExpress.employee;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using PenguinExpress.service;


namespace PenguinExpress.main
{
  public partial class Login : Form
  {
    Auth auth = new Auth();
    public Login()
    {
      InitializeComponent();
    }
    private void setColor()
    {

      this.BackColor = ColorTranslator.FromHtml(Styles.light);
      this.ForeColor = ColorTranslator.FromHtml(Styles.dark);

      tab_login.Padding = new Point(0, 0);
      tab_login.Margin = new Padding(0, 0, 0, 0);

      tab_login.Font = Styles.font;
      tab_page1.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      tab_page2.ForeColor = ColorTranslator.FromHtml(Styles.dark);
      tab_page1.BackColor = ColorTranslator.FromHtml(Styles.light);
      tab_page2.BackColor = ColorTranslator.FromHtml(Styles.light);

      btn_e_login.Font = Styles.font;
      btn_join.Font = Styles.font;
      btn_login.Font = Styles.font;
      btn_join.FlatStyle = FlatStyle.Flat;
      btn_login.FlatStyle = FlatStyle.Flat;
      btn_e_login.FlatStyle = FlatStyle.Flat;
      btn_e_login.BackColor = ColorTranslator.FromHtml(Styles.primary);
      btn_join.BackColor = ColorTranslator.FromHtml(Styles.success);
      btn_login.BackColor = ColorTranslator.FromHtml(Styles.primary);
      btn_e_login.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_join.ForeColor = ColorTranslator.FromHtml(Styles.light);
      btn_login.ForeColor = ColorTranslator.FromHtml(Styles.light);

      
      

    }
    private void btn_login_Click(object sender, EventArgs e)
    {
      const string seller = "Seller";
      bool isVaild = checkLoginVaildate(tb_id, tb_pwd);
      if (!isVaild) return;

      string userid = tb_id.Text;
      string pwd = tb_pwd.Text;

      int id = auth.checkExistUser(userid, pwd, seller);
      if (id == -1)
      {
        MessageBox.Show("존재하지 않는 아이디이거나 비밀번호가 다릅니다.", "info",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      onSellerLogin((int)id);
    }
    private void btn_e_login_Click(object sender, EventArgs e)
    {
      const string employee = "Employee";
      bool isVaild = checkLoginVaildate(tb_e_id, tb_e_pwd);
      if (!isVaild) return;

      string userid = tb_e_id.Text;
      string pwd = tb_e_pwd.Text;

      int id = auth.checkExistUser(userid, pwd, employee);
      if (id == -1)
      {
        MessageBox.Show("존재하지 않는 아이디이거나 비밀번호가 다릅니다.", "info",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
      }
      bool isAdmin = auth.checkIsAdmin(id);
      bool isEmployee = auth.checkIsEmployee(id);
      onEmployeeLogin(id, isAdmin, isEmployee);
    }
    private void onSellerLogin(int id)
    {
      SetVisibleCore(false);
      this.Close();
      new Seller_list(id).ShowDialog();
      
    }
    private void onEmployeeLogin(int id, bool isAdmin, bool isEmployee)
    {
      
      if (isAdmin)
      {
        SetVisibleCore(false);
        new Admin(id.ToString()).ShowDialog();
      }
      else
      {
        if (isEmployee) {
          SetVisibleCore(false);
          new Deliver(id.ToString()).ShowDialog();
        } 
        else
        {
          MessageBox.Show("승인이 나지 않았습니다. 관리자에게 문의하세요");
          return;
        }
      }
      this.Close();
    }
    private bool checkLoginVaildate(TextBox id, TextBox pw)
    {
      string name = id.Text;
      string pwd = pw.Text;

      if(name == "")
      {
        MessageBox.Show("아이디를 입력해주세요.", "Info", MessageBoxButtons.OK);
        return false;
      }
      if(pwd == "")
      {
        MessageBox.Show("비밀번호를 입력해주세요.", "info", MessageBoxButtons.OK);
        return false;
      }
      return true;
    }
    private void btn_join_Click(object sender, EventArgs e)
    {
      new Join().ShowDialog();
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
    private void Login_Load(object sender, EventArgs e)
    {
      setColor();
    }
  }
}
