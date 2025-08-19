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
                        Purchasing purchase = new Purchasing();
                        purchase.PurchasingM();
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
                Console.WriteLine($"\n*--------------------------------*");
                Console.WriteLine($"Grocery Mangement");
                Console.WriteLine($"1 - Purchasing");
                Console.WriteLine($"2 - Recieving");
                Console.WriteLine($"3 - Inventory");
                Console.WriteLine($"4 - Vendor");
                Console.WriteLine($"5 - Product");
                Console.WriteLine($"6 - Exit");
                Console.WriteLine($"*--------------------------------*");
                Console.Write("Selected: ");

            }
        }

        class Purchasing
        {
            public void PurchasingM()
            {
                Console.WriteLine("\nPurchasing:");
                Console.Write("Vendor ID: ");

                //Exception
                try
                {
                    //Get vendor Id from user
                    int Vinput = int.Parse(Console.ReadLine());
                    Vendor vendor = new Vendor();
                    if (vendor.getVendor(Vinput) != null)
                    {
                        //Get product using Vendor ID and Product ID
                        Console.Write("Product ID: ");
                        try
                        {
                            int Pinput = int.Parse(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Vendor not found.");
                    }

                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
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
