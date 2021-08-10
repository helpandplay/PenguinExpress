using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PenguinExpress.config;
using PenguinExpress.entity;

namespace PenguinExpress.service
{
  public class Reservation
  {
    private static ReservationEntity entity = ReservationEntity.getReservationEntity();

    public List<Dictionary<string, string>> findAll() {
      List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

      string sql = string.Format(
        "SELECT * " +
        "FROM {0};"
        ,MyDatabase.reservationListTbl);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        MyDatabase.reader = MyDatabase.cmd.ExecuteReader();

        while (MyDatabase.reader.Read())
        {
          Dictionary<string, string> dataSet = new Dictionary<string, string>();
          dataSet.Add(entity.trackingID, MyDatabase.reader[entity.trackingID].ToString());
          dataSet.Add(entity.sellerID, MyDatabase.reader[entity.sellerID].ToString());
          dataSet.Add(entity.employeeID, MyDatabase.reader[entity.employeeID].ToString());
          dataSet.Add(entity.sellerAddr, MyDatabase.reader[entity.sellerAddr].ToString());
          dataSet.Add(entity.sellerPhone, MyDatabase.reader[entity.sellerPhone].ToString());
          dataSet.Add(entity.prodName, MyDatabase.reader[entity.prodName].ToString());
          dataSet.Add(entity.prodQty, MyDatabase.reader[entity.prodQty].ToString());
          dataSet.Add(entity.prodCode, MyDatabase.reader[entity.prodCode].ToString());
          dataSet.Add(entity.buyAddr, MyDatabase.reader[entity.buyAddr].ToString());
          dataSet.Add(entity.buyPhone, MyDatabase.reader[entity.buyPhone].ToString());
          dataSet.Add(entity.buyRegionCode, MyDatabase.reader[entity.buyRegionCode].ToString());
          dataSet.Add(entity.rvTime, MyDatabase.reader[entity.rvTime].ToString());
          dataSet.Add(entity.rvStatus, MyDatabase.reader[entity.rvStatus].ToString());

          result.Add(dataSet);
        }
      }catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Reservation List findAll Error");
      }
      finally
      {
        MyDatabase.reader.Close();
      }
      return result;
    }
    public Dictionary<string, string> findOne(string trackingID) {
      Dictionary<string, string> result = new Dictionary<string, string>();

      string sql = string.Format(
        "SELECT * " +
        "FROM {0} " +
        "WHERE {1} = {2};"
        ,MyDatabase.reservationListTbl, entity.trackingID, trackingID);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        MyDatabase.reader = MyDatabase.cmd.ExecuteReader();

        if (!MyDatabase.reader.Read())
          throw new Exception("Error : Failed Reservation List findOne Read");

        result.Add(entity.trackingID, MyDatabase.reader[entity.trackingID].ToString());
        result.Add(entity.sellerID, MyDatabase.reader[entity.sellerID].ToString());
        result.Add(entity.employeeID, MyDatabase.reader[entity.employeeID].ToString());
        result.Add(entity.sellerAddr, MyDatabase.reader[entity.sellerAddr].ToString());
        result.Add(entity.sellerPhone, MyDatabase.reader[entity.sellerPhone].ToString());
        result.Add(entity.prodName, MyDatabase.reader[entity.prodName].ToString());
        result.Add(entity.prodQty, MyDatabase.reader[entity.prodQty].ToString());
        result.Add(entity.prodCode, MyDatabase.reader[entity.prodCode].ToString());
        result.Add(entity.buyAddr, MyDatabase.reader[entity.buyAddr].ToString());
        result.Add(entity.buyPhone, MyDatabase.reader[entity.buyPhone].ToString());
        result.Add(entity.buyRegionCode, MyDatabase.reader[entity.buyRegionCode].ToString());
        result.Add(entity.rvTime, MyDatabase.reader[entity.rvTime].ToString());
        result.Add(entity.rvStatus, MyDatabase.reader[entity.rvStatus].ToString());
      }
      catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Reservation List findOne");
      }
      finally
      {
        MyDatabase.reader.Close();
      }
      return result;
    }
    public bool addReservation(Dictionary<string, string> reservation) {
      bool isSuccess = false;
      string sql = string.Format(
        "INSERT {0} INTO VALUES(" +
        "NULL, {1}, NULL, '{2}', '{3}', '{4}', {5}, {6}, '{7}', '{8}', {9}, NOW(), 1" +
        ");"
        , MyDatabase.reservationListTbl,
        reservation[entity.sellerID],
        reservation[entity.sellerAddr],
        reservation[entity.sellerPhone],
        reservation[entity.prodName],
        reservation[entity.prodQty],
        reservation[entity.prodCode],
        reservation[entity.buyAddr],
        reservation[entity.buyPhone],
        reservation[entity.buyRegionCode]
        );

      try
      {
        MyDatabase.cmd.CommandText = sql;
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if (result != -1) isSuccess = true;
      }catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Reservation addReservation");
      }
      return isSuccess;
    }
    public bool removeOne(string trackingID) {
      bool isSuccess = false;

      string sql = string.Format(
        "DELETE " +
        "FROM {0} " +
        "WHERE {1} = {2};"
        ,MyDatabase.reservationListTbl, entity.trackingID, trackingID);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        int result =  MyDatabase.cmd.ExecuteNonQuery();
        if(result != -1) isSuccess = true;
      }
      catch(Exception error)
      {
        Debug.WriteLine("Error : Failed reservation removeOne");
      }
      return isSuccess;
    }
    public bool updateReservation(string trackingID, string target, string data) {
      bool isSuccess = false;
      string sql = string.Format(
        "UPDATE {0} " +
        "SET {1} = {2} " +
        "WHERE {3} = {4};"
        , MyDatabase.reservationListTbl, target, data, entity.trackingID, trackingID);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if(result != -1) isSuccess = true;
      }catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Reservation UpdateOne");
      }
      return isSuccess;
    }
  }
}
