using System;
using System.Collections.Generic;
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

    public List<Dictionary<string, string>> findAll() { }
    public Dictionary<string, string> findOne(string userid) { }
    public bool addSeller(Dictionary<string, string> seller) { }

    //delete
    //update
  }
}
