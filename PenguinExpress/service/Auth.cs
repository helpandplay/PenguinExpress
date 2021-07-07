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
    public int checkPwdVerify(Dictionary<string, string> user, string pwd)
    {
      string dbPwd = user["pwd"];
      string salt = user["salt"];
      bool isEqual = SHA256Hash.isEqualPwd(pwd, dbPwd, salt);
      if (!isEqual) return -1;

      int id = int.Parse(user["id"].ToString());
      return id;
    }
    public Dictionary<string, string> checkExistUser(string userid, string type)
    {
      Dictionary<string, string> user = null;

      switch (type) {
        case "Employee":
          user = employee.findOne(userid);
          //table = MyDatabase.employeeTbl;
          break;
        case "Seller":
          user = seller.findOne(userid);
          //table = MyDatabase.sellerTbl;
          break;
        default:
          System.Windows.Forms.MessageBox.Show("Unknown Login Type! : " + type,
            "Error" ,
            System.Windows.Forms.MessageBoxButtons.OK,
            System.Windows.Forms.MessageBoxIcon.Error);
          break;
      }
      return user;
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
    }
    public bool addUser(Dictionary<string, string> userData, bool isEmployee)
    {
      string salt = SHA256Hash.getSalt();
      string hashedPwd = SHA256Hash.hashing(userData["pwd"], salt);

      userData.Add("salt", salt);
      userData["pwd"] = hashedPwd;//폼에서 가져왔던 origin source에서 hashpwd 변경

      bool isSuceess;
      if (isEmployee)
      {
        isSuceess = employee.addEmployee(userData);
      }
      else
      {
        isSuceess = seller.addSeller(userData);
      }
      return isSuceess;
    }
  }
}
