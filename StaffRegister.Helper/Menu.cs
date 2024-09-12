namespace StaffRegister.Helper
{
    public class Menu
    {
        public void ShowMenu(string[] menuOptions, Dictionary<string, Action> actions)
        {
            Console.WriteLine("Menu options:");
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1} {menuOptions[i]}");
            }

            string input = "";
            do
            {
                input = Console.ReadLine();

                foreach (string key in actions.Keys)
                {
                    if (input == key)
                    {
                        actions[key] ();
                    }
                }
            } while (input != "quit" && input != "5");
        }
    }
}
