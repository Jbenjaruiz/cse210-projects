using System;
using System.IO;
using System.Text.Json;

public class JsonHandler
{
    private static string filePath = "data.json";

    // Method to write an array of objects to a JSON file
    public static void WriteToJsonFile(Entry[] objects)
    {
        string jsonString = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, jsonString);
    }

    // Method to read objects from a JSON file and return an array
    public static Entry[] ReadFromJsonFile()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return Array.Empty<Entry>();
        }

        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<Entry[]>(jsonString) ?? Array.Empty<Entry>();
    }
}


