using StaffRegister;

public class Program
{
    static EmployeeManager employeeManager = new();

    private static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            employeeManager.SaveFilePath = args[0];
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
                    employeeManager.PrintEmployees();
                    break;
                case "2":
                    employeeManager.AddEmployee();
                    break;
                case "3":
                    employeeManager.LoadFile(); 
                    break;
                case "4":
                    employeeManager.SaveFile(); 
                    break;
                default:
                    Console.WriteLine("Invalid input.");
                    continue;
            }
        } while (input != "quit" || input == "5");
    }
}