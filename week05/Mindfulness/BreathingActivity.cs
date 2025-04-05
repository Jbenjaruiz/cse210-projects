
public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void RunActivity()
    {
        Console.WriteLine("Prepare to begin breathing..."); 
        Console.WriteLine(); 

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            if (DateTime.Now >= endTime) break;

            Console.Write("Breathe in... ");
            ShowCountDown(4); 
            Console.WriteLine();

            if (DateTime.Now >= endTime) break;

            Console.Write("Now breathe out... ");
            ShowCountDown(6);
            Console.WriteLine();
            Console.WriteLine(); 
        }
    }
}