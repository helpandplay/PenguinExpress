using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using PenguinExpress.seller;

namespace PenguinExpress
{
  public partial class Main : Form
  {
    MySqlCommand cmd;
    MySqlConnection connection;
    public Main()
    {
      InitializeComponent();
      onConnect();
      onLoadSellerDashBoard();
    }
    private void onLoadSellerDashBoard()
    {
      Seller_list list = new Seller_list(cmd, 1);
      list.ShowDialog();
    }
    private void onConnect()
    {
      string server = Env.SERVER;
      string port = Env.PORT;
      string uid = Env.ADMIN_UID;
      string pwd = Env.ADMIN_PWD;
      string db = Env.DBNAME;

      string conn = string.Format("Server={0};Port={1};Uid={2};Pwd={3};Database={4};CHARSET=UTF8", server, port, uid, pwd, db);
      connection = new MySqlConnection(conn);
      try
      {
        connection.Open();
        cmd = new MySqlCommand("", connection);
      }catch(Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      finally
      {
        Debug.Close();
      }
    }
  }
}
