namespace PenguinExpress.entity
{
  public class Employee
  {
    private static Employee instance = null;

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

    public Employee getEmployee()
    {
      if(instance == null)
      {
        instance = new Employee();
      }
      return instance;
    }
  }
}
