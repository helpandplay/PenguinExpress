using System;
using System.Collections.Generic;
using PenguinExpress.entity;
using PenguinExpress.config;
using System.Diagnostics;

namespace PenguinExpress.service
{
  class EmployeeService
  {
    
    private readonly EmployeeEntity entity = EmployeeEntity.getEmployee();
    public EmployeeService() { }
    public List<Dictionary<string, string>> findAll() {
      List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
      string sql = string.Format(
        "SELECT * " +
        "FROM {0};"
        , MyDatabase.employeeTbl);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        MyDatabase.reader =  MyDatabase.cmd.ExecuteReader();

        while (MyDatabase.reader.Read())
        {
          Dictionary<string, string> dataSet = new Dictionary<string, string>();

          dataSet.Add(entity.id, MyDatabase.reader[entity.id].ToString());
          dataSet.Add(entity.userid, MyDatabase.reader[entity.userid].ToString());
          dataSet.Add(entity.pwd, MyDatabase.reader[entity.pwd].ToString());
          dataSet.Add(entity.name, MyDatabase.reader[entity.name].ToString());
          dataSet.Add(entity.phone, MyDatabase.reader[entity.phone].ToString());
          dataSet.Add(entity.regionCode, MyDatabase.reader[entity.regionCode].ToString());
          dataSet.Add(entity.cpCount, MyDatabase.reader[entity.cpCount].ToString());
          dataSet.Add(entity.isAdmin, MyDatabase.reader[entity.isAdmin].ToString());
          dataSet.Add(entity.isEmployee, MyDatabase.reader[entity.isEmployee].ToString());
          dataSet.Add(entity.salt, MyDatabase.reader[entity.salt].ToString());

          result.Add(dataSet);
        }
      }catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Employee findAll");
      }
      finally
      {
        MyDatabase.reader.Close();
      }
      return result; 
    }
    public Dictionary<string, string> findOne(string userid) {
      Dictionary<string, string> result = new Dictionary<string, string>();
      string sql = string.Format(
        "SELECT * " +
        "FROM {0} " +
        "WHERE {1} = '{2}';"
        , MyDatabase.employeeTbl, entity.userid, userid);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        MyDatabase.reader = MyDatabase.cmd.ExecuteReader();

        if (!MyDatabase.reader.Read()) return result;

        result.Add(entity.id, MyDatabase.reader[entity.id].ToString());
        result.Add(entity.userid, MyDatabase.reader[entity.userid].ToString());
        result.Add(entity.pwd, MyDatabase.reader[entity.pwd].ToString());
        result.Add(entity.name, MyDatabase.reader[entity.name].ToString());
        result.Add(entity.phone, MyDatabase.reader[entity.phone].ToString());
        result.Add(entity.regionCode, MyDatabase.reader[entity.regionCode].ToString());
        result.Add(entity.cpCount, MyDatabase.reader[entity.cpCount].ToString());
        result.Add(entity.isAdmin, MyDatabase.reader[entity.isAdmin].ToString());
        result.Add(entity.isEmployee, MyDatabase.reader[entity.isEmployee].ToString());
        result.Add(entity.salt, MyDatabase.reader[entity.salt].ToString());
      }
      catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Employee findOne");
        Debug.WriteLine(error.Message);
      }
      finally
      {
        MyDatabase.reader.Close();
      }
      return result;
    }
    public bool addEmployee(Dictionary<string, string> employee) {
      //여기 insert 버그 있음
      bool isSuccess = false;
      string sql = string.Format(
        "INSERT INTO {0} VALUES (" +
        "NULL, '{1}', '{2}', '{3}', '{4}', {5}, 0, false, false, '{6}' " +
        ");"
        ,
        MyDatabase.employeeTbl,
        employee[entity.userid],
        employee[entity.pwd],
        employee[entity.name],
        employee[entity.phone],
        employee[entity.regionCode],
        employee[entity.salt]
        );
      try
      {
        MyDatabase.cmd.CommandText = sql;
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if (result != -1) isSuccess = true;
      }catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Employee addEmployee");
        Debug.WriteLine(error.InnerException);
      }
      return isSuccess;
     
    }
    public bool updateEmployee(string userid, string target, string data) {
      bool isSuccess = false;
      string sql = string.Format(
        "UPDATE {0} " +
        "SET {1} = {2} " +
        "WHERE userid = {3};"
        ,MyDatabase.employeeTbl, target, data, userid);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if (result != -1) isSuccess = true;
      }catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Employee update");
      }
      finally
      {

      }
      return isSuccess;
    }
    
    //delete

  }
}
