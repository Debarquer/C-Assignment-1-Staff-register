using StaffRegister;
using StaffRegister.Helper;

public class Program
{
    static EmployeeManager employeeManager = new();
    static Menu menu = new();

    private static string[] menuOptions = [
        "Print employees",
        "Add employee",
        "Load from file",
        "Save to file",
        "Quit"
    ];

    private static Dictionary<string, Action> menuActions = new Dictionary<string, Action>()
    {
        {"1", employeeManager.PrintEmployees},
        { "2", employeeManager.AddEmployee },
        { "3", employeeManager.LoadFile },
        { "4", employeeManager.SaveFile },
    };

    private static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            employeeManager.SaveFilePath = args[0];
        }

        if (File.Exists(employeeManager.SaveFilePath))
        {
            employeeManager.LoadFile();
        }

        menu.ShowMenu(menuOptions, menuActions);
    }
}