public class Journal
{
    public static List<Entry> _entries = [];

    public static void LoadEntries()
    {
        _entries = JsonHandler.ReadFromJsonFile().ToList();
    }

    public static void AddEntry()
    {
        PromptGenerator _promptGenerator = new();

        string _promptText = _promptGenerator.GetRandomPrompt();

        Console.WriteLine(_promptText);

        string _entryText = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;

        string _dateText = theCurrentTime.ToShortDateString();

        Entry _entry = new()
        {
            Date = _dateText,
            PromptText = _promptText,
            EntryText = _entryText
        };

        _entries.Add(_entry);

        SaveEntries();

        Console.WriteLine("Entry added!");
    }

    public static void DisplayAllEntries()
    {
        LoadEntries();

        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public static void SaveEntries()
    {
        JsonHandler.WriteToJsonFile(_entries.ToArray());
    }


    public static void SearchByDate()
    {
        Console.Write("Enter the date to search (DD/MM/YYYY): ");
        string dateToSearch = Console.ReadLine();

        List<Entry> _matchingEntries = [.. _entries.Where(entry => entry.Date.StartsWith(dateToSearch))];

        if (_matchingEntries.Count == 0)
        {
            Console.WriteLine("No entries found for this date.");
            return;
        }

        Console.WriteLine("\nEntries for " + dateToSearch + ":");
        foreach (var entry in _matchingEntries)
        {
            entry.Display();
        }
    }

    public static void DeleteEntry()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries to delete.");
            return;
        }

        DisplayAllEntries();
        Console.Write("Enter the number of the entry to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _entries.Count)
        {
            _entries.RemoveAt(index - 1);
            SaveEntries();
            Console.WriteLine("Entry deleted.");
        }
        else
        {
            Console.WriteLine("Invalid entry number.");
        }
    }

}
