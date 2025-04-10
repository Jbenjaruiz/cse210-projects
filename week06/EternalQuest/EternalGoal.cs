
public class EternalGoal : Goal
{
    private int _timesRecorded;

    public EternalGoal(string name, string description, int points)
    {
        ShortName = name;
        Description = description;
        Points = points;
        _timesRecorded = 0;
    }

    public override void RecordEvent()
    {
        _timesRecorded++;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {ShortName} ({Description}) - Recorded {_timesRecorded} times";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{ShortName}:{Description}:{Points}:{_timesRecorded}";
    }
}