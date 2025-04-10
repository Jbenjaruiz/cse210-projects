
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    public int Target { get; set; }
    public int Bonus { get; set; }

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
    {
        ShortName = name;
        Description = description;
        Points = points;
        Target = target;
        Bonus = bonus;
        _amountCompleted = 0;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= Target;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {ShortName} ({Description}) - Completed {_amountCompleted}/{Target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName}:{Description}:{Points}:{Target}:{Bonus}:{_amountCompleted}";
    }

    public int GetPointsForEvent()
    {
        return _amountCompleted == Target ? Points + Bonus : Points;
    }
}