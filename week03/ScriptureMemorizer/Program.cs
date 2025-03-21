using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = LoadScripturesFromJson();

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found in the JSON file.");
            return;
        }

        Random rand = new();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

        while (!scripture.IsCompletelyHidden())
        {
            string input = Console.ReadLine()?.Trim().ToLower();
            if (input == "quit") break;

            scripture.HideRandomWords(3);

            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
        }

        Console.WriteLine("\nAll words are hidden. Program ended.");
    }

    static List<Scripture> LoadScripturesFromJson()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "scriptures.json");

        try
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Scripture>>(jsonData) ?? new List<Scripture>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return new List<Scripture>();
        }
    }
}
