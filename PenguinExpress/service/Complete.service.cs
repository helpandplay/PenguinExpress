using System;
using System.Collections.Generic;
using PenguinExpress.entity;
using PenguinExpress.config;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace PenguinExpress.service
{
  class CompleteService
  {
    private readonly CompleteEntity entity = CompleteEntity.getComplete();
    public CompleteService(){}
    public List<Dictionary<string, string>> findAll(string orderBy = null)
    {
      List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

      string sql = orderBy == null ? string.Format("SELECT * FROM {0};", MyDatabase.completeListTbl) :
        string.Format("SELECT * FROM {0} ORDER BY {1} DESC;", MyDatabase.completeListTbl, orderBy);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        MyDatabase.reader = MyDatabase.cmd.ExecuteReader();

        while (MyDatabase.reader.Read())
        {
          Dictionary<string, string> dataSet = new Dictionary<string, string>();
          dataSet.Add(entity.id, MyDatabase.reader[entity.id].ToString());
          dataSet.Add(entity.trackingID, MyDatabase.reader[entity.trackingID].ToString());
          dataSet.Add(entity.employeeID, MyDatabase.reader[entity.employeeID].ToString());
          dataSet.Add(entity.sellerID, MyDatabase.reader[entity.sellerID].ToString());
          dataSet.Add(entity.sellerAddr, MyDatabase.reader[entity.sellerAddr].ToString());
          dataSet.Add(entity.sellerPhone, MyDatabase.reader[entity.sellerPhone].ToString());
          dataSet.Add(entity.prodName, MyDatabase.reader[entity.prodName].ToString());
          dataSet.Add(entity.prodQty, MyDatabase.reader[entity.prodQty].ToString());
          dataSet.Add(entity.prodCode, MyDatabase.reader[entity.prodCode].ToString());
          dataSet.Add(entity.buyAddr, MyDatabase.reader[entity.buyAddr].ToString());
          dataSet.Add(entity.buyPhone, MyDatabase.reader[entity.buyPhone].ToString());
          dataSet.Add(entity.buyRegionCode, MyDatabase.reader[entity.buyRegionCode].ToString());
          dataSet.Add(entity.rvTime, MyDatabase.reader[entity.rvTime].ToString());
          dataSet.Add(entity.cpTime, MyDatabase.reader[entity.cpTime].ToString());

          result.Add(dataSet);
        }
      }catch(Exception error)
      {
        Debug.WriteLine("Complete findAll Error");
      }
      finally
      {
        MyDatabase.reader.Close();
      }
      return result;
    }
    public List<Dictionary<string, string>> findAllTarget(string userid, string field)
    {
      List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

      string sql = string.Format(
        "SELECT * " +
        "FROM {0}" +
        "WHERE {1} = {2};"
        , MyDatabase.completeListTbl, field, userid);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        MyDatabase.reader = MyDatabase.cmd.ExecuteReader();

        while (MyDatabase.reader.Read())
        {
          Dictionary<string, string> dataSet = new Dictionary<string, string>();
          dataSet.Add(entity.id, MyDatabase.reader[entity.id].ToString());
          dataSet.Add(entity.trackingID, MyDatabase.reader[entity.trackingID].ToString());
          dataSet.Add(entity.employeeID, MyDatabase.reader[entity.employeeID].ToString());
          dataSet.Add(entity.sellerID, MyDatabase.reader[entity.sellerID].ToString());
          dataSet.Add(entity.sellerAddr, MyDatabase.reader[entity.sellerAddr].ToString());
          dataSet.Add(entity.sellerPhone, MyDatabase.reader[entity.sellerPhone].ToString());
          dataSet.Add(entity.prodName, MyDatabase.reader[entity.prodName].ToString());
          dataSet.Add(entity.prodQty, MyDatabase.reader[entity.prodQty].ToString());
          dataSet.Add(entity.prodCode, MyDatabase.reader[entity.prodCode].ToString());
          dataSet.Add(entity.buyAddr, MyDatabase.reader[entity.buyAddr].ToString());
          dataSet.Add(entity.buyPhone, MyDatabase.reader[entity.buyPhone].ToString());
          dataSet.Add(entity.buyRegionCode, MyDatabase.reader[entity.buyRegionCode].ToString());
          dataSet.Add(entity.rvTime, MyDatabase.reader[entity.rvTime].ToString());
          dataSet.Add(entity.cpTime, MyDatabase.reader[entity.cpTime].ToString());

          result.Add(dataSet);
        }
      }
      catch (Exception error)
      {
        Debug.WriteLine("Complete findAll Error");
      }
      finally
      {
        MyDatabase.reader.Close();
      }
      return result;
    }
    public Dictionary<string, string> findOne(string trackingID)
    {
      Dictionary<string, string> result = new Dictionary<string, string>();

      string sql = string.Format(
        "SELECT * " +
        "FROM {0} " +
        "WHERE {1} = {2};"
        , MyDatabase.completeListTbl, entity.trackingID, trackingID);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        MyDatabase.reader = MyDatabase.cmd.ExecuteReader();

        while (MyDatabase.reader.Read())
        {
          result.Add(entity.id, MyDatabase.reader[entity.id].ToString()); //1
          result.Add(entity.trackingID, MyDatabase.reader[entity.trackingID].ToString()); //2
          result.Add(entity.employeeID, MyDatabase.reader[entity.employeeID].ToString()); //3
          result.Add(entity.sellerID, MyDatabase.reader[entity.sellerID].ToString()); //4
          result.Add(entity.sellerAddr, MyDatabase.reader[entity.sellerAddr].ToString());//5
          result.Add(entity.sellerPhone, MyDatabase.reader[entity.sellerPhone].ToString());//6
          result.Add(entity.prodName, MyDatabase.reader[entity.prodName].ToString());//7
          result.Add(entity.prodQty, MyDatabase.reader[entity.prodQty].ToString());//8
          result.Add(entity.prodCode, MyDatabase.reader[entity.prodCode].ToString());//9
          result.Add(entity.buyAddr, MyDatabase.reader[entity.buyAddr].ToString());//10
          result.Add(entity.buyPhone, MyDatabase.reader[entity.buyPhone].ToString());//11
          result.Add(entity.buyRegionCode, MyDatabase.reader[entity.buyRegionCode].ToString());//12
          result.Add(entity.rvTime, MyDatabase.reader[entity.rvTime].ToString());//13
          result.Add(entity.cpTime, MyDatabase.reader[entity.cpTime].ToString());//14

        }
      }
      catch (Exception error)
      {
        Debug.WriteLine("Error : Failed Complete findAll");
      }
      finally
      {
        MyDatabase.reader.Close();
      }
      return result;
    }
    public bool addComplete(Dictionary<string, string> data)
    {
      bool isSuccess = false;
      string sql = string.Format(
        "INSERT {0} INTO VALUES(" +
        "NULL, {1}, {2}, {3}, '{4}', '{5}', '{6}', {7}, {8}, '{9}', {10}, '{11}', '{12}', NOW()" +
        ");"
        , MyDatabase.completeListTbl,
        data[entity.trackingID],
        data[entity.employeeID],
        data[entity.sellerID],
        data[entity.sellerAddr],
        data[entity.sellerPhone],
        data[entity.prodName],
        data[entity.prodQty],
        data[entity.prodCode],
        data[entity.buyAddr],
        data[entity.buyPhone],
        data[entity.buyRegionCode],
        data[entity.rvTime]);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if (result != -1) isSuccess = true;
      }catch(Exception error)
      {
        Debug.WriteLine("Error : failed addComplete");
      }
      finally
      {

      }
      return isSuccess;
    }
    public Dictionary<int, int> GroupingData(string baseData)
    {
      Dictionary<int, int> result = new Dictionary<int, int>();
      string sql = string.Format(
        "SELECT {0}, COUNT(*) AS 'cnt' " +
        "FROM {1} " +
        "GROUP BY {2};",
        baseData,
        MyDatabase.completeListTbl,
        baseData
        );

      MyDatabase.cmd.CommandText = sql;
      MySqlDataReader reader = MyDatabase.cmd.ExecuteReader();

      try
      {
        while (reader.Read())
        {
          result.Add(int.Parse(reader[baseData].ToString()), int.Parse(reader["cnt"].ToString()));
        }
      }
      catch (Exception error)
      {
        Debug.WriteLine(error.StackTrace);
        Debug.WriteLine(error.Message);
      }
      finally
      {
        reader.Close();
      }
      return result;
    }

    //delete
    //update
  }
}
