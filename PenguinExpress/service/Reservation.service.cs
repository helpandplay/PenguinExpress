using System;
using System.Collections.Generic;
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

    public List<Dictionary<string, string>> findAll() { }
    public Dictionary<string, string> findOne(string trackingID) { }
    public bool addReservation(Dictionary<string, string> reservation) { }
    public bool removeOne(string trackingID) { }
    public bool updateReservation(string trackingID, string target, string data) { }
  }
}
