namespace groceryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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
                Console.WriteLine($"\n");
            }
        }

        class Purchasing
        {

        }

        class Recieving
        {

        }

        class Inventory
        {

        }
    }
}
