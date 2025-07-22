using System.ComponentModel.DataAnnotations;

namespace groceryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create instance of the menu
            Menu menu = new Menu();

            //Display menu to the user
            menu.DisplayMenu();

            //Gets users input to which menu options they selected
            string input = Console.ReadLine();

            //Convert input to enum
            if (int.TryParse(input, out int selectedOption) &&
                    Enum.IsDefined(typeof(Menu.Option), selectedOption))
            {
                Menu.Option userOption = (Menu.Option)selectedOption;

                switch (userOption)
                {
                    case Menu.Option.Purchasing:
                        Console.WriteLine("Purchased");
                        break;
                    case Menu.Option.Recieving:
                        Console.WriteLine("Recieved");
                        break;
                    case Menu.Option.Inventory:
                        Console.WriteLine("Inventory?");
                        break;
                    case Menu.Option.exit:
                        Console.WriteLine("Bye bye");
                        break;
                }
            }
        }

        class Menu
        {
            //options
            public enum Option
            {
                None,
                Purchasing = 1,
                Recieving = 2,
                Inventory = 3,
                exit = 4,

            }

            public void DisplayMenu()
            {
                Console.WriteLine($"\nGrocery Mangement");
                Console.WriteLine($"1 - Purchasing");
                Console.WriteLine($"2 - Recieving");
                Console.WriteLine($"3 - Inventory");
                Console.WriteLine($"4 - Exit");
                Console.Write("Selected: ");

            }
        }

        class Purchasing
        {
            public void PurchasingMenu()
            {
                Console.WriteLine();
            }
        }

        class Recieving
        {

        }

        class Inventory
        {

        }
    }
}
