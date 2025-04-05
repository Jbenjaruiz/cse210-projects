
public class BodyScanActivity : Activity
{
    private readonly List<string> _bodyParts;

    public BodyScanActivity()
    {
        _name = "Body Scan Activity";
        _description = "This activity will help you become more aware of your physical sensations. You will slowly bring your attention to different parts of your body, noticing any feelings without judgment.";

        _bodyParts = new List<string>
        {
            "the toes on your left foot",
            "your left foot",
            "your left ankle",
            "your left lower leg",
            "your left knee",
            "your left upper leg",
            "the toes on your right foot",
            "your right foot",
            "your right ankle",
            "your right lower leg",
            "your right knee",
            "your right upper leg",
            "your hips and pelvic area",
            "your lower back",
            "your abdomen",
            "your upper back",
            "your chest",
            "the fingers on your left hand",
            "your left hand",
            "your left wrist",
            "your left forearm",
            "your left elbow",
            "your left upper arm",
            "your left shoulder",
            "the fingers on your right hand",
            "your right hand",
            "your right wrist",
            "your right forearm",
            "your right elbow",
            "your right upper arm",
            "your right shoulder",
            "your neck",
            "your jaw",
            "your face",
            "the top of your head"
        };
    }

    public override void RunActivity()
    {
        Console.WriteLine("Get comfortable, either sitting or lying down.");
        Console.WriteLine("Focus on your body and try to notice the sensations without judgment.");
        Console.WriteLine(); 
        ShowSpinner(5);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        int currentPartIndex = 0;

        while (DateTime.Now < endTime)
        {
            string part = _bodyParts[currentPartIndex % _bodyParts.Count];

            Console.Write($"Bring your attention to {part}... ");

            int pauseDurationSeconds = 8; 
            DateTime expectedPauseEnd = DateTime.Now.AddSeconds(pauseDurationSeconds);

            if (expectedPauseEnd > endTime)
            {
                TimeSpan remainingTime = endTime - DateTime.Now;
                pauseDurationSeconds = (remainingTime.TotalSeconds > 0) ? (int)Math.Ceiling(remainingTime.TotalSeconds) : 0;
            }

            if (pauseDurationSeconds > 0)
            {
                ShowSpinner(pauseDurationSeconds);
            }
            Console.WriteLine();

            currentPartIndex++; 

             if (DateTime.Now >= endTime) break;
        }
         Console.WriteLine();
    }
}