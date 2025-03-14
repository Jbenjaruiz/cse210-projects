class PromptGenerator
{
    readonly List<string> _prompts =
    [
        "Who was the most interesting person I interacted with today, and why?",
        "What was the best part of my day, and what made it special?",
        "What was the strongest emotion I felt today, and what triggered it?",
        "If I had one thing I could do over today, what would it be and why?",
        "What is one thing I learned today that I didn’t know before?",
        "How did I step out of my comfort zone today?",
        "What is something I did today that I am proud of?",
        "Was there a moment today where I felt truly present? What was I doing?",
        "What small act of kindness did I witness or perform today?",
        "If today were a chapter in a book about my life, what would its title be?"
    ];

    public string GetRandomPrompt()
    {
        Random random = new();
        int min = 0, max = _prompts.Count - 1;
        int randomInRange = random.Next(min, max);

        return _prompts[randomInRange];
    }
}