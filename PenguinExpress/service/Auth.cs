using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenguinExpress.config;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace PenguinExpress.service
{
  class Auth
  {
    EmployeeService employee = new EmployeeService();
    SellerService seller = new SellerService();
    //login
    public int checkExistUser(string userid, string pwd, string type)
    {
      string table;
      string dbPwd = null;
      string salt = string.Empty;
      int? id = null;

      switch (type) {
        case "Employee":
          table = MyDatabase.employeeTbl;
          break;
        case "Seller":
          table = MyDatabase.sellerTbl;
          break;
        default:
          throw new Exception("Unknown Login Type");
      }

      string sql = string.Format(
      "SELECT id, pwd, salt " +
      "FROM {0} " +
      "WHERE userid = '{1}';"
      , MyDatabase.employeeTbl, userid);

      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();

      try
      {
        if (!reader.Read()) return -1;

        dbPwd = reader["pwd"].ToString();
        salt = reader["salt"].ToString();

        bool isEqual = SHA256Hash.isEqualPwd(pwd, dbPwd, salt);
        if (!isEqual) return -1;

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
    public bool checkIsAdmin(int id)
    {
      bool isAdmin = false;
      string sql = string.Format(
        "SELECT isAdmin " +
        "FROM {0} " +
        "WHERE id = {1};"
        , MyDatabase.employeeTbl, id);

      MyDatabase.cmd.CommandText = sql;
      try
      {
        var result = MyDatabase.cmd.ExecuteScalar();
        isAdmin = (bool)result;
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.Message);
      }
      return isAdmin;
    }
    public bool checkIsEmployee(int id)
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
    //join
    public string checkOverlapId(string userid, bool employeeChecked)
    {
      string sql;
      if (userid == "")
        return "아이디를 입력해주세요.";
      if (userid.Length < 2 || userid.Length > 12)
        return "2~12자리만 사용할 수 있습니다.";

      Dictionary<string, string> result;

      if (employeeChecked)
        result = employee.findOne(userid);
      else
        result = seller.findOne(userid);


      if (result.Count == 0) return "사용 가능한 아이디입니다.";
      return "이미있는 아이디입니다.";
    } //완료
    public bool addUser(Dictionary<string, string> userData, bool isEmployee)
    {
      string salt = SHA256Hash.getSalt();
      string hashedPwd = SHA256Hash.hashing(userData["pwd"], salt);

      string table;
      string sql;
      if (isEmployee)
      {
        table = MyDatabase.employeeTbl;
        sql = string.Format(
        "INSERT INTO {0} VALUES( " +
        "NULL, '{1}', '{2}', '{3}', '{4}', '{5}', 0, false, false, '{6}');"
        , table, userData["userid"], hashedPwd, userData["name"], userData["phone"], userData["regionCode"], salt);
        }
      else
      {
        table = MyDatabase.sellerTbl;
        sql = string.Format(
      "INSERT INTO {0} VALUES( " +
      "NULL, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');"
      , table, userData["userid"], hashedPwd, userData["name"], userData["addr"], userData["phone"], salt);
      }
      // todo : sql, employee테이블 insert 개수 다름
      // => "NULL, '{1}', '{2}', '{3}', '{4}', {5}, 0, false, false, '{6}');"

      MyDatabase.cmd.CommandText = sql;
      try
      {
        MyDatabase.cmd.ExecuteNonQuery();
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.StackTrace);
        Debug.WriteLine(error.Message);
        return false;
      }
      return true;
    }
  }
}
