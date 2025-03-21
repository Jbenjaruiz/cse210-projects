using Newtonsoft.Json;

public class Reference
{
    [JsonProperty("book")]
    private string Book { get; set; } = "";

    [JsonProperty("chapter")]
    private int Chapter { get; set; }

    [JsonProperty("verse")]
    private int Verse { get; set; }

    [JsonProperty("endVerse")]
    private int EndVerse { get; set; }

    public string GetDisplayText()
    {
        return EndVerse == Verse
            ? $"{Book} {Chapter}:{Verse}"
            : $"{Book} {Chapter}:{Verse}-{EndVerse}";
    }
}
