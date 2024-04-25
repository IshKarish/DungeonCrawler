namespace DungeonCrawler;

public class Key : Item
{
    public Key() : base("Key")
    {
        Description = "Can open doors.";
    }
    
    public Key(string description) : base("Key")
    {
        Description = description;
    }
    
    public Key(string name = "Key", string description = "Can open doors.") : base(name)
    {
        Description = description;
    }
}