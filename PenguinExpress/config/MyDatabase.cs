using System;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace PenguinExpress.config
{
  public static class MyDatabase
  {
    public static MySqlCommand cmd;
    public static MySqlConnection connection;

    public static string reservationListTbl = "reservation_list";
    public static string sellerTbl = "seller";
    public static string deliverWorkerTbl = "deliver_worker";
    public static string deliverListTbl = "deliver_list";
    public static string completeListTbl = "complete_list";

    public static void onConnect()
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
      }
      catch (Exception error)
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
