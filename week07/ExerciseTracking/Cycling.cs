
public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, int durationMinutes, double speedMph)
        : base(date, durationMinutes) 
    {
        _speedMph = speedMph;
        _activityName = "Cycling"; 
    }

    public override double GetDistance()
    {
        return (_speedMph / 60.0) * _durationMinutes;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        if (_speedMph <= 0)
            return 0; 
        return 60.0 / _speedMph;
    }
}
