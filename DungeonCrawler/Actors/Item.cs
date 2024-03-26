namespace DungeonCrawler;

public class Item : Actor
{
    public string Name { get; private set; }

    public Item() {}
    
    public Item(string name)
    {
        Name = name;
    }
}