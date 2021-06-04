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

    private void btn_login_Click(object sender, EventArgs e)
    {
      bool isVaild = checkLoginVaildate(tb_id, tb_pwd);
      if (!isVaild) return;

      string userid = tb_id.Text;
      string pwd = tb_pwd.Text;

      string sql = string.Format(
        "SELECT id, pwd " +
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
        "SELECT id, pwd " +
        "FROM {0} " +
        "WHERE userid = '{1}';"
        , MyDatabase.employeeTbl, userid);

      int id = checkExistUser(sql, pwd);
      if (id == -1) return;
      bool isAdmin = checkIsAdmin(id);
      onEmployeeLogin(id, isAdmin);
    }
    private void onSellerLogin(int id)
    {
      SetVisibleCore(false);
      this.Close();
      new Seller_list(id).ShowDialog();
      
    }
    private void onEmployeeLogin(int id, bool isAdmin)
    {
      SetVisibleCore(false);
      if (isAdmin)
      {
        new Admin(id.ToString()).ShowDialog();
      }
      else
      {
        new Deliver(id.ToString()).ShowDialog();
      }
      this.Close();
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
        id = int.Parse(reader["id"].ToString());

        if (dbPwd != pwd)
        {
          MessageBox.Show("존재하지 않는 아이디이거나 비밀번호가 다릅니다.", "info",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
          return -1;
        };
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

  }
}
