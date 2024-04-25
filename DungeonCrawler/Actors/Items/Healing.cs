namespace DungeonCrawler;

public class Healing : Item
{
    public float HP { get; private set; }
    
    public Healing(string name = "Banana", string description = "", float hp = 10) : base(name)
    {
        HP = hp;
        
        if (description == "") Description = $"Heals you by {hp} HP.";
        else Description = description;
    }
    
    public Healing(string name = "Banana", float hp = 10, string description = "") : base(name)
    {
        HP = hp;
        
        if (description == "") Description = $"Heals you by {hp} HP.";
        else Description = description;
    }
}