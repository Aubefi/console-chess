using System;
using System.IO;
using System.Text.Json;

namespace Chess.Engine.Localization;

public static class Json
{
    public static TClass? OpenFile<TClass>(string folderName, string fileName) where TClass : class
    {
        var path = Path.Combine(AppContext.BaseDirectory, folderName, $"{fileName}.json");

        if (File.Exists(path) is false)
        {
            return null;
        }

        using var jsonFile = File.Open(path, FileMode.Open);

        return JsonSerializer.Deserialize<TClass>(jsonFile);
    }
}
