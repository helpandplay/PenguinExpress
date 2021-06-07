using System;

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
        case 0:
          return "의류";
        case 1:
          return "전자제품류";
        case 2:
          return "식품류";
        case 3:
          return "식기류";
        case 4:
          return "가구류";
        case 5:
          return "의약품";
        case 6:
          return "기타";
        default:
          throw new Exception("알 수 없는 품목번호입니다. 품목번호 : " + key);
      }
    }
    public string getRegionName(int key)
    {
      switch (key)
      {
        case 0:
          return "서울";
        case 1:
          return "경기";
        case 2:
          return "인천";
        case 3:
          return "충북";
        case 4:
          return "충남";
        case 5:
          return "대전";
        case 6:
          return "전북";
        case 7:
          return "전남";
        case 8:
          return "광주";
        case 9:
          return "경상";
        case 10:
          return "경남";
        case 11:
          return "대구";
        case 12:
          return "부산";
        default:
          throw new Exception("알 수 없는 품목번호입니다. 품목번호 : " + key);
      }
    }
  }
}
