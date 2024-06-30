namespace DungeonCrawler;

public class Item : Actor
{
    public string Name { get; private set; }
    public string Description { get; init; }

    public Item() {}
    
    public Item(string name, string description = "Doing literally nothing.")
    {
        Name = name;
        Description = description;
    }
}