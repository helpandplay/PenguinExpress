namespace PenguinExpress.entity
{
  public class EmployeeEntity
  {
    private static EmployeeEntity instance = null;

    public readonly string id = "id";
    public readonly string userid = "userid";
    public readonly string pwd = "pwd";
    public readonly string name = "name";
    public readonly string phone = "phone";
    public readonly string regionCode = "region_code";
    public readonly string cpCount = "cp_count";
    public readonly string isAdmin = "isAdmin";
    public readonly string isEmployee = "isEmployee";
    public readonly string salt = "salt";

    public static EmployeeEntity getEmployee()
    {
      if(instance == null)
      {
        instance = new EmployeeEntity();
      }
      return instance;
    }
  }
}
