using System.Collections.Generic;

namespace Chess.Settings;

public static class User
{
    public static Dictionary<string, bool> ToggleSettings { get; private set; } = [];
    public static Dictionary<string, string> SelectionSettings { get; private set; } = [];
}
