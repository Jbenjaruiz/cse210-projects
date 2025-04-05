// Exceeding requirement: "BodyScanActivity" added

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Current Date (Simulated): {DateTime.Now:dddd, MMMM d, yyyy}");
        Console.WriteLine("Welcome to the Mindfulness App!");
        Console.WriteLine();


        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Mindfulness Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflecting Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Start Body Scan Activity"); 
            Console.WriteLine("  5. Quit");                    
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine() ?? ""; 

            Activity currentActivity = null; 
            switch (choice)
            {
                case "1":
                    currentActivity = new BreathingActivity();
                    break;
                case "2":
                    currentActivity = new ReflectingActivity();
                    break;
                case "3":
                    currentActivity = new ListingActivity();
                    break;
                case "4": 
                    currentActivity = new BodyScanActivity();
                    break;
                case "5": 
                    Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                    System.Threading.Thread.Sleep(1500);
                    break; 
                default:
                    Console.WriteLine("Invalid choice. Please select 1, 2, 3, 4, or 5.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine(); 
                    break;
            }

            
            if (currentActivity != null)
            {
                currentActivity.Run();

            }
        }
    }
}