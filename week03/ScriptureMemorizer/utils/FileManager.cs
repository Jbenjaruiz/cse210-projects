using Newtonsoft.Json;

public class FileManager
{
    public static List<Scripture> LoadScripturesFromJson(string path)
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

        try
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Scripture>>(jsonData) ?? new List<Scripture>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading JSON file: {ex.Message}");
            return new List<Scripture>();
        }
    }
}