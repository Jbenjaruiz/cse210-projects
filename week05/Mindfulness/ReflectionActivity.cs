
public class ReflectingActivity : Activity
{
    private readonly List<string> _prompts;
    private readonly List<string> _questions;
    private static readonly Random _random = new(); 

    public ReflectingActivity()
    {
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    private string GetRandomItem(List<string> list)
    {
        int index = _random.Next(list.Count);
        return list[index];
    }

    public override void RunActivity()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        string prompt = GetRandomItem(_prompts);
        Console.WriteLine($" --- {prompt} --- ");
        Console.WriteLine();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine(); 
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5); 
        Console.Clear(); 

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
             if (DateTime.Now >= endTime) break;

            string question = GetRandomItem(_questions);
            Console.Write($"> {question} ");
            ShowSpinner(10); 
            Console.WriteLine();
             if (DateTime.Now >= endTime) break;
           
        }
        Console.WriteLine(); 
    }
}