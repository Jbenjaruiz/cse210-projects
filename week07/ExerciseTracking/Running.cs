
public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, int durationMinutes, double distanceMiles)
        : base(date, durationMinutes)
    {
        _distanceMiles = distanceMiles;
        _activityName = "Running"; 
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        if (_durationMinutes <= 0)
            return 0;
        return (_distanceMiles / _durationMinutes) * 60.0;
    }

    public override double GetPace()
    {
        if (_distanceMiles <= 0)
            return 0; 
        return _durationMinutes / _distanceMiles;
    }
}