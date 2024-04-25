namespace DungeonCrawler;

public class CombatOptions
{
    public List<string> Options { get; private set; } = new List<string>
    {
        "Fight",
        "Talk",
        "Use",
        "Kill yourself",
        "Kill enemy (auto win)"
    };
    
    public override string ToString()
    {
        string options = "";
        
        for (int i = 0; i < Options.ToArray().Length; i++)
        {
            string s = Options.ToArray()[i];
            options += $"{i + 1}. {s}";
            if (i != Options.ToArray().Length - 1) options += "\n";
        }

        return options;
    }
}