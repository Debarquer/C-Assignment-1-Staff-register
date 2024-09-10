namespace StaffRegister;

public class EmployeeManager
{
    List<Employee> employees = new List<Employee>();
    public int NrOfEmployees => employees.Count;
    private string saveFilePath = "employees.txt";

    public string SaveFilePath { get => saveFilePath; set => saveFilePath = value; }

    public void PrintEmployees()
    {
        if (employees == null || employees.Count == 0)
        {
            Console.WriteLine("No employees");
            return;
        }

        Console.WriteLine("Employees:");
        for (int i = 0; i < employees.Count; i++)
        {
            Employee employee = employees[i];
            Console.WriteLine($"{i + 1} Name: {employee.Name} Salary: {employee.Salary}");
        }
    }

    public void AddEmployee()
    {
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter salary: ");
        string salary = Console.ReadLine();

        int salaryInt = 0;
        if (!int.TryParse(salary, out salaryInt))
        {
            Console.WriteLine("Invalid number format!");
            return;
        }
        else
        {
            AddEmployee(name, salaryInt);
            Console.WriteLine($"Added new employee {name} with salary = {salaryInt}");
        }
    }
    public void AddEmployee(string name, int salary)
    {
        employees.Add(new Employee(name, salary));
    }

    public void SaveFile()
    {
        List<string> lines = [];
        foreach (Employee employee in employees)
        {
            lines.Add($"{employee.Name}:{employee.Salary}");
        }

        File.WriteAllLines(SaveFilePath, lines);
    }

    public void LoadFile()
    {
        employees.Clear();

        string[] lines = File.ReadAllLines(SaveFilePath);
        foreach (string line in lines)
        {
            string[] split = line.Split(":");
            string name = split[0];
            int salary = int.Parse(split[1]);

            employees.Add(new Employee(name, salary));
        }

        Console.WriteLine($"Loaded {lines.Length} employee(s)");
    }
}
