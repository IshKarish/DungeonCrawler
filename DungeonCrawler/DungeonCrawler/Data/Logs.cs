namespace DungeonCrawler;

public static class Logs
{
    public static List<string> LogsLst { get; private set; } = new List<string>();
    private static bool _changed;

    public static void Add(string log)
    {
        LogsLst.Add(log);
        _changed = true;
    }

    public static bool HasChanged()
    {
        if (_changed)
        {
            _changed = false;
            return true;
        }

        return false;
    }

    public static void KeepFive()
    {
        if (LogsLst.ToArray().Length > 5) LogsLst.RemoveAt(0);
    }

    public new static string ToString()
    {
        if (LogsLst.Count == 0) return "You have nothing lol";
        
        string lstStr = "";
        for (int i = LogsLst.ToArray().Length - 1; i >= 0; i--)
        {
            string s = LogsLst.ToArray()[i];
            lstStr += $" * {s}";
            if (i != 0) lstStr += "\n";
        }

        return lstStr;
    }
}