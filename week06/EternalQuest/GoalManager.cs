using System.Text.Json;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    public void Start()
    {
        LoadGoals();
        string choice;
        do
        {
            Console.WriteLine($"\nEternal Quest - Level {_level}");
            Console.WriteLine($"Current Score: {_score}");
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Select a choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    break;
                case "5":
                    LoadGoals();
                    break;
                case "6":
                    Console.WriteLine("Exiting Eternal Quest. Farewell!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != "6");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
        Console.WriteLine($"Current Level: {_level}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nSelect the type of goal to create:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Progress Goal");
        Console.Write("Enter your choice: ");
        string goalType = Console.ReadLine();

        Console.Write("Enter the short name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter the description of the goal: ");
        string description = Console.ReadLine();
        Console.Write("Enter the points for completing/recording the goal: ");
        if (!int.TryParse(Console.ReadLine(), out int points))
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("Simple goal created successfully!");
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("Eternal goal created successfully!");
                break;
            case "3":
                Console.Write("Enter the target number of times to complete the goal: ");
                if (!int.TryParse(Console.ReadLine(), out int target))
                {
                    Console.WriteLine("Invalid target value.");
                    return;
                }
                Console.Write("Enter the bonus points for completing the checklist: ");
                if (!int.TryParse(Console.ReadLine(), out int bonus))
                {
                    Console.WriteLine("Invalid bonus value.");
                    return;
                }
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("Checklist goal created successfully!");
                break;
            case "4":
                Console.Write("Enter the target amount for the progress goal: ");
                if (!int.TryParse(Console.ReadLine(), out int progressTarget))
                {
                    Console.WriteLine("Invalid target value.");
                    return;
                }
                _goals.Add(new ProgressGoal(name, description, points, progressTarget));
                Console.WriteLine("Progress goal created successfully!");
                break;
            default:
                Console.WriteLine("Invalid goal type selected.");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        if (_goals.Count == 0) return;

        Console.Write("Enter the number of the goal you accomplished: ");
        if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber > 0 && goalNumber <= _goals.Count)
        {
            Goal selectedGoal = _goals[goalNumber - 1];
            selectedGoal.RecordEvent();

            int pointsEarned = selectedGoal is ChecklistGoal checklistGoal ? checklistGoal.GetPointsForEvent() : selectedGoal.Points;
            if (selectedGoal is ProgressGoal progressGoal)
            {
                pointsEarned = progressGoal.GetPointsForEvent();
            }

            _score += (int)(pointsEarned * GetLevelMultiplier());

            Console.WriteLine($"Event recorded for '{selectedGoal.ShortName}'. You earned {pointsEarned} points!");
            UpdateLevel();
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(new { Score = _score, Goals = _goals }, options);
            File.WriteAllText("goals.json", jsonString);
            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        try
        {
            if (File.Exists("goals.json"))
            {
                string jsonString = File.ReadAllText("goals.json");
                var saveData = JsonSerializer.Deserialize<SaveData>(jsonString);
                if (saveData != null)
                {
                    _score = saveData.Score;
                    _goals = new List<Goal>();
                    foreach (var goalData in saveData.Goals)
                    {
                        if (goalData is JsonElement element)
                        {
                            var type = element.GetProperty("$type").GetString();
                            switch (type)
                            {
                                case "EternalQuest.SimpleGoal":
                                    _goals.Add(JsonSerializer.Deserialize<SimpleGoal>(element.GetRawText()));
                                    break;
                                case "EternalQuest.EternalGoal":
                                    _goals.Add(JsonSerializer.Deserialize<EternalGoal>(element.GetRawText()));
                                    break;
                                case "EternalQuest.ChecklistGoal":
                                    _goals.Add(JsonSerializer.Deserialize<ChecklistGoal>(element.GetRawText()));
                                    break;
                                case "EternalQuest.ProgressGoal":
                                    _goals.Add(JsonSerializer.Deserialize<ProgressGoal>(element.GetRawText()));
                                    break;
                            }
                        }
                    }
                    UpdateLevel();
                    Console.WriteLine("Goals loaded successfully!");
                }
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }


    private void UpdateLevel()
    {
        int previousLevel = _level;
        _level = 1 + (_score / 1000);
        if (_level > previousLevel)
        {
            Console.WriteLine($"Congratulations! You leveled up to Level {_level}!");
        }
    }


    private double GetLevelMultiplier()
    {
        return 1 + (_level * 0.05);
    }
}