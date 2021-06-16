namespace PenguinExpress.entity
{
  public class SellerEntity
  {
    private static SellerEntity instance = null;

    public readonly string id = "id";
    public readonly string userid = "userid";
    public readonly string pwd = "pwd";
    public readonly string name = "name";
    public readonly string addr = "addr";
    public readonly string phone = "phone";
    public readonly string salt = "salt";

    public static SellerEntity getSellerEntity()
    {
      if(instance == null)
      {
        instance = new SellerEntity();
      }
      return instance;
    }
  }
}
