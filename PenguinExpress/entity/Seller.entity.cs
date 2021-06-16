namespace PenguinExpress.entity
{
  public class Seller
  {
    private static Seller instance = null;

    public readonly string id = "id";
    public readonly string userid = "userid";
    public readonly string pwd = "pwd";
    public readonly string name = "name";
    public readonly string addr = "addr";
    public readonly string phone = "phone";
    public readonly string salt = "salt";

    public static Seller getSeller()
    {
      if(instance == null)
      {
        instance = new Seller();
      }
      return instance;
    }
  }
}
