using CAssignment_1Staff_register;

internal class Program
{
    static List<Employee> employees = new List<Employee>();
    private static string saveFilePath = "employees.txt";

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        if(args.Length > 0)
        {
            saveFilePath = args[0];
        }

        string input = "";
        do
        {
            Console.WriteLine("Menu options:");
            Console.WriteLine("1. Print employees");
            Console.WriteLine("2. Add employee");
            Console.WriteLine("3. Load from file");
            Console.WriteLine("4. Save to file");
            Console.WriteLine("5. Quit");

            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    PrintEmployees();
                    break;
                case "2":
                    AddEmployee();
                    break;
                case "3":
                    LoadFile(); 
                    break;
                case "4":
                    SaveFile(); 
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    continue;
            }
        } while (input != "quit" || input == "5");
    }

    static void PrintEmployees()
    {
        if(employees == null || employees.Count == 0) 
        {
            Console.WriteLine("No employees");
            return;
        }

        Console.WriteLine("Employees:");
        for (int i = 0; i < employees.Count; i++)
        {
            Employee employee = employees[i];
            Console.WriteLine($"{i+1} Name: {employee.Name} Salary: {employee.Salary}");
        }
    }

    static void AddEmployee()
    {
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter salary: ");
        string salary = Console.ReadLine();

        int salaryInt = 0;
        if(!int.TryParse(salary, out salaryInt))
        {
            Console.WriteLine("Invalid number format!");
            return;
        }
        else
        {
            employees.Add(new Employee(name, salaryInt));
            Console.WriteLine($"Added new employee {name} with salary = {salaryInt}");
        }
    }

    static void SaveFile()
    {
        if (employees == null || employees.Count == 0) return;

        List<string> lines = [];
        foreach(Employee employee in employees ) 
        {
            lines.Add($"{employee.Name}:{employee.Salary}");
        }

        File.WriteAllLines(saveFilePath, lines);
    }

    static void LoadFile()
    {
        employees.Clear();

        string[] lines = File.ReadAllLines(saveFilePath);
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