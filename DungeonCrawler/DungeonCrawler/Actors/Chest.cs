namespace DungeonCrawler;

public class Chest : Actor
{
    public Item Item { get; private set; }
    
    public Chest(Item item)
    {
        Transform.SetScale(3, 2);
        Graphics = new Graphics('$', ConsoleColor.Green);
        Interactable = true;
        Item = item;
    }
}