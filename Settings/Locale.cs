using System;
using System.Collections.Generic;
using Chess.Engine.Localization;

namespace Chess.Settings;

public sealed class Locale
{
    public static Dictionary<string, List<string>> StringTable { get; set; } = [];

    public static event Action? CurrentLanguageChanged;

    private static readonly List<string> JsonFiles =
    [
        "en", "pt-BR"
    ];

    private static int s_index = 0;

    public static void SwapLanguage()
    {
        s_index = (s_index + 1) % JsonFiles.Count;

        var newStringTable = Json.OpenFile<Dictionary<string, List<string>>>("Settings/Locale", JsonFiles[s_index]);

        if (newStringTable is null)
        {
            return;
        }

        StringTable = newStringTable;
        CurrentLanguageChanged?.Invoke();
    }
}
