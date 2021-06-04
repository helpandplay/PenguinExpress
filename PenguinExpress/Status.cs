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
    public string getItemName(int key)
    {
      switch (key)
      {
        case 1:
          return "의류";
        case 2:
          return "전자제품류";
        case 3:
          return "식품류";
        case 4:
          return "식기류";
        case 5:
          return "가구류";
        case 6:
          return "의약품";
        case 7:
          return "기타";
        default:
          throw new Exception("알 수 없는 품목번호입니다. 품목번호 : " + key);
      }
    }
  }
}
