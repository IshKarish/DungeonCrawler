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
    
    public Chest(Item item, Vector2 position)
    {
        Transform.SetScale(3, 2);
        Graphics = new Graphics('$', ConsoleColor.Green);
        Interactable = true;
        Item = item;
        Transform.SetPosition(position);
    }
    
    public Chest(Item item, int x, int y)
    {
        Transform.SetScale(3, 2);
        Graphics = new Graphics('$', ConsoleColor.Green);
        Interactable = true;
        Item = item;
        Transform.SetPosition(new Vector2(x, y));
    }
    
    public Chest(string item)
    {
        Transform.SetScale(3, 2);
        Graphics = new Graphics('$', ConsoleColor.Green);
        Interactable = true;
        Item = new Item(item);
    }
    
    public Chest(string item, Vector2 position)
    {
        Transform.SetScale(3, 2);
        Graphics = new Graphics('$', ConsoleColor.Green);
        Interactable = true;
        Item = new Item(item);
        Transform.SetPosition(position);
    }
    
    public Chest(string item, int x, int y)
    {
        Transform.SetScale(3, 2);
        Graphics = new Graphics('$', ConsoleColor.Green);
        Interactable = true;
        Item = new Item(item);
        Transform.SetPosition(new Vector2(x, y));
    }
}