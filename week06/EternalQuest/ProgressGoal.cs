// Exceeding Requirement: Goal that tracks progress towards a larger goal
public class ProgressGoal : Goal
{
    private int _amountCompleted;
    public int Target { get; set; }

    public ProgressGoal(string name, string description, int points, int target)
    {
        ShortName = name;
        Description = description;
        Points = points;
        Target = target;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted > Target)
        {
            _amountCompleted = Target;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= Target;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {ShortName} ({Description}) - Progress: {_amountCompleted}/{Target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal:{ShortName}:{Description}:{Points}:{Target}:{_amountCompleted}";
    }

    public int GetPointsForEvent()
    {
        return Points;
    }
}