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
  public class SellerService
  {
    private static SellerEntity entity = SellerEntity.getSellerEntity();

    public List<Dictionary<string, string>> findAll() {
      List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
      string sql = string.Format(
        "SELECT * " +
        "FROM {0};"
        , MyDatabase.sellerTbl);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        MyDatabase.reader = MyDatabase.cmd.ExecuteReader();

        while (MyDatabase.reader.Read())
        {
          Dictionary<string, string> dataSet = new Dictionary<string, string>();

          dataSet.Add(entity.id, MyDatabase.reader[entity.id].ToString());
          dataSet.Add(entity.userid, MyDatabase.reader[entity.userid].ToString());
          dataSet.Add(entity.pwd, MyDatabase.reader[entity.pwd].ToString());
          dataSet.Add(entity.name, MyDatabase.reader[entity.name].ToString());
          dataSet.Add(entity.addr, MyDatabase.reader[entity.addr].ToString());
          dataSet.Add(entity.phone, MyDatabase.reader[entity.phone].ToString());
          dataSet.Add(entity.salt, MyDatabase.reader[entity.salt].ToString());

          result.Add(dataSet);
        }
      }catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Seller findAll");
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
        ,MyDatabase.sellerTbl, entity.userid, userid);

      try
      {
        MyDatabase.cmd.CommandText = sql;
        MyDatabase.reader = MyDatabase.cmd.ExecuteReader();

        if (!MyDatabase.reader.Read()) return result;

        result.Add(entity.id, MyDatabase.reader[entity.id].ToString());
        result.Add(entity.userid, MyDatabase.reader[entity.userid].ToString());
        result.Add(entity.pwd, MyDatabase.reader[entity.pwd].ToString());
        result.Add(entity.name, MyDatabase.reader[entity.name].ToString());
        result.Add(entity.addr, MyDatabase.reader[entity.addr].ToString());
        result.Add(entity.phone, MyDatabase.reader[entity.phone].ToString());
        result.Add(entity.salt, MyDatabase.reader[entity.salt].ToString());
      }catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Seller FindOne");
        Debug.WriteLine(error.Message);
      }
      finally
      {
        MyDatabase.reader.Close();
      }
      return result;
    } //완료
    public bool addSeller(Dictionary<string, string> seller) {
      bool isSuccess = false;

      string sql = string.Format(
        "INSERT {0} INTO VALUES(" +
        "NULL, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'" +
        ");"
        , MyDatabase.sellerTbl,
        seller[entity.userid],
        seller[entity.pwd],
        seller[entity.name],
        seller[entity.addr],
        seller[entity.phone],
        seller[entity.salt]
        );

      try
      {
        MyDatabase.cmd.CommandText = sql;
        int result = MyDatabase.cmd.ExecuteNonQuery();
        if (result != -1) isSuccess = true;

      }catch(Exception error)
      {
        Debug.WriteLine("Error : Failed Seller AddSeller");
      }
      return isSuccess;
    }

    //delete
    //update
  }
}
