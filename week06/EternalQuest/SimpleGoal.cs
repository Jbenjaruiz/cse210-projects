
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
    {
        ShortName = name;
        Description = description;
        Points = points;
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {ShortName} ({Description})";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{ShortName}:{Description}:{Points}:{_isComplete}";
    }
}