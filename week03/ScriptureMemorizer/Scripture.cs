using Newtonsoft.Json;

public class Scripture
{
    [JsonProperty("reference")]
    private Reference Reference { get; set; } = new Reference();


    private List<Word> _words = new List<Word>();

    [JsonProperty("text")]
    public string Text
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                _words = value.Split(' ').Select(word => new Word(word)).ToList();
            }
            else
            {
                _words = new List<Word>();
            }
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new();
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    public string GetDisplayText()
    {
        return $"{Reference.GetDisplayText()}\n{string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }
}
