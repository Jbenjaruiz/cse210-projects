
public class ListingActivity : Activity
{
    private readonly List<string> _prompts;
    private static readonly Random _random = new(); 
    private int _itemCount;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _itemCount = 0;

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public override void RunActivity()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        string prompt = GetRandomPrompt();
        Console.WriteLine($" --- {prompt} --- ");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(7);
        Console.WriteLine(); 

        _itemCount = 0; 
        List<string> itemsListed = new(); 

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine() ?? ""; 
            if (!string.IsNullOrWhiteSpace(item))
            {
                itemsListed.Add(item); 
                _itemCount++;
            }
        }

        Console.WriteLine(); 
        Console.WriteLine($"You listed {_itemCount} items!");
    }
}