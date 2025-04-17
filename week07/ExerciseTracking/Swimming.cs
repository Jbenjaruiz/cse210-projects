
public class Swimming : Activity
{
    private int _laps;
    private const double MetersPerLap = 50.0;
    private const double MetersToMiles = 0.000621371; 
    private const double LapLengthMiles = MetersPerLap * MetersToMiles;

    public Swimming(DateTime date, int durationMinutes, int laps)
        : base(date, durationMinutes) 
    {
        _laps = laps;
        _activityName = "Swimming"; 
    }

    public override double GetDistance()
    {
        return _laps * LapLengthMiles;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        if (_durationMinutes <= 0)
            return 0;
        return (distance / _durationMinutes) * 60.0;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance <= 0)
            return 0; 
        return _durationMinutes / distance;
    }
}