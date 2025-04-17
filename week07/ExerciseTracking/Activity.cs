
using System.Globalization; 

public abstract class Activity
{
    private DateTime _date;
    protected int _durationMinutes;
    protected string _activityName = "Activity";

    public Activity(DateTime date, int durationMinutes)
    {
        _date = date;
        _durationMinutes = durationMinutes;
    }

    public abstract double GetDistance(); 
    public abstract double GetSpeed();    
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string formattedDate = _date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);

        return $"{formattedDate} {_activityName} ({_durationMinutes} min) - Distance {distance:F1} miles, Speed {speed:F1} mph, Pace: {pace:F1} min per mile";
    }
}