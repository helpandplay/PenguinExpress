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


namespace PenguinExpress.main
{
  public partial class Login : Form
  {
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
      bool isVaild = checkLoginVaildate(tb_id, tb_pwd);
      if (!isVaild) return;

      string userid = tb_id.Text;
      string pwd = tb_pwd.Text;

      string sql = string.Format(
        "SELECT id, pwd, salt " +
        "FROM {0} " +
        "WHERE userid = '{1}';"
        ,MyDatabase.sellerTbl, userid);

      int id = checkExistUser(sql, pwd);
      if (id == -1) return;
      onSellerLogin((int)id);
    }
    private void btn_e_login_Click(object sender, EventArgs e)
    {
      bool isVaild = checkLoginVaildate(tb_e_id, tb_e_pwd);
      if (!isVaild) return;

      string userid = tb_e_id.Text;
      string pwd = tb_e_pwd.Text;

      string sql = string.Format(
        "SELECT id, pwd, salt " +
        "FROM {0} " +
        "WHERE userid = '{1}';"
        , MyDatabase.employeeTbl, userid);

      int id = checkExistUser(sql, pwd);
      if (id == -1) return;
      bool isAdmin = checkIsAdmin(id);
      bool isEmployee = checkIsEmployee(id);
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
    private bool checkIsEmployee(int id)
    {
      bool isEmployee = false;
      string sql = string.Format(
        "SELECT isEmployee " +
        "FROM {0} " +
        "WHERE id = {1};"
        , MyDatabase.employeeTbl, id);

      MyDatabase.cmd.CommandText = sql;
      try
      {
        var result = MyDatabase.cmd.ExecuteScalar();
        isEmployee = (bool)result;
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      return isEmployee;
    }
    private bool checkIsAdmin(int id)
    {
      bool isAdmin = false;
      string sql = string.Format(
        "SELECT isAdmin " +
        "FROM {0} " +
        "WHERE id = {1};"
        ,MyDatabase.employeeTbl, id);

      MyDatabase.cmd.CommandText = sql;
      try
      {
        var result = MyDatabase.cmd.ExecuteScalar();
        isAdmin = (bool)result;
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      return isAdmin;
    }
    private int checkExistUser(string sql, string pwd)
    {
      string dbPwd = null;
      string salt = string.Empty;
      int? id = null;

      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();

      try
      {
        if (!reader.Read())
        {
          MessageBox.Show("존재하지 않는 아이디이거나 비밀번호가 다릅니다.", "info",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
          return -1;
        }

        dbPwd = reader["pwd"].ToString();
        salt = reader["salt"].ToString();

        bool isEqual = SHA256Hash.isEqualPwd(pwd, dbPwd, salt);
        if (!isEqual)
        {
          MessageBox.Show("존재하지 않는 아이디이거나 비밀번호가 다릅니다.", "info",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
          return -1;
        }

        id = int.Parse(reader["id"].ToString());
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        reader.Close();
      }

      return (int)id;
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
