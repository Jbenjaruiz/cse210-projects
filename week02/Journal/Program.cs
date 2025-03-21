// The program saves and load entries automatically
// It allows the user to search by dates.
// The user is able to delete a record.

class Program
{
    static void Main(string[] args)
    {
        Journal.LoadEntries();

        while (true)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Search");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Journal.AddEntry();
                    break;
                case "2":
                    Journal.DisplayAllEntries();
                    break;
                case "3":
                    Journal.SearchByDate();
                    break;
                case "4":
                    Journal.DeleteEntry();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }

    }
}