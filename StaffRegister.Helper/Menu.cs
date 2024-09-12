namespace StaffRegister.Helper
{
    public class Menu
    {
        /// <summary>
        /// Shows a menu with options and prompts user for input. Call functions based on user input.
        /// </summary>
        /// <param name="menuOptions">Menu options</param>
        /// <param name="actions">Menu options functions</param>
        public void ShowMenu(string[] menuOptions, Dictionary<string, Action> actions)
        {
            string input = "";
            do
            {
                PrintMenuOptions(menuOptions);

                input = Console.ReadLine();

                foreach (string key in actions.Keys)
                {
                    if (input == key)
                    {
                        actions[key]();
                    }
                }
            } while (input != "quit" && input != "5");
        }

        private static void PrintMenuOptions(string[] menuOptions)
        {
            Console.WriteLine("Menu options:");
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1} {menuOptions[i]}");
            }
        }
    }
}
