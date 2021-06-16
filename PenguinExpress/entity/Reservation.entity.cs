namespace PenguinExpress.entity
{
  public class Reservation
  {
    private static Reservation instance = null;

    public readonly string trackingID = "tracking_id";
    public readonly string sellerID = "s_id";
    public readonly string employeeID = "e_id";
    public readonly string sellerAddr = "s_addr";
    public readonly string sellerPhone = "s_phone";
    public readonly string prodName = "p_name";
    public readonly string prodQty = "p_qty";
    public readonly string prodCode = "p_code";
    public readonly string buyAddr = "b_addr";
    public readonly string buyPhone = "b_phone";
    public readonly string buyRegionCode = "b_region_code";
    public readonly string rvTime = "rv_time";
    public readonly string rvStatus = "rv_status";

    public Reservation getReservation()
    {
      if(instance == null)
      {
        instance = new Reservation();
      }
      return instance;
    }
  }
}
