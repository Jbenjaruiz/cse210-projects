public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }


    public void Display()
    {
        Console.WriteLine($"1 - Date: {Date} - Prompt: {PromptText}");
        Console.WriteLine(EntryText);
        Console.WriteLine();
    }
}