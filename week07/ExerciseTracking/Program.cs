using System;

public class Program
{
    public static void Main(string[] args)
    {

        List<Activity> activities = new ();


        DateTime activityDate = new (2022, 11, 3); 

        Running runningActivity = new (activityDate, 30, 3.0); 
        Cycling cyclingActivity = new (activityDate, 45, 15.0); 
        Swimming swimmingActivity = new (activityDate, 60, 40);


        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);


        Console.WriteLine("Fitness Activity Summaries:");
        Console.WriteLine("--------------------------");
        foreach (Activity activity in activities)
        {

            Console.WriteLine(activity.GetSummary());
        }
        Console.WriteLine("--------------------------");
    }
}