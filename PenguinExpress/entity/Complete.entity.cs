namespace PenguinExpress.entity
{
  public class CompleteEntity
  {
    private static CompleteEntity instance = null;

    public readonly string id = "id";
    public readonly string trackingID = "tracking_id";
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
    public readonly string cpTime = "cp_time";

    private CompleteEntity()
    {

    }
    public static CompleteEntity getComplete()
    {
      if( instance == null)
      {
        instance = new CompleteEntity();
      }
      return instance;
    }
  }
}
