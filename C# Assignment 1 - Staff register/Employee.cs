namespace StaffRegister;

/// <summary>
/// Stores data for an employee.
/// </summary>
/// <param name="name">Employee name</param>
/// <param name="salary">Employee salary</param>
public class Employee(string name, int salary)
{
    public string Name { get; private set; } = name;
    public int Salary { get; private set; } = salary;
}
