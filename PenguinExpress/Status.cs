using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenguinExpress
{
  public class Status
  {
    public Status() { }
    public string getReservationCode(int status)
    {
      switch (status)
      {
        case 1:
          return "예약 완료";
        case 2:
          return "배송 중";
        case 3:
          return "배송 완료";
        case -1:
          return "예약 취소";
        default:
          throw new Exception("unknown status code : " + status);
      }
    }
  }
}
