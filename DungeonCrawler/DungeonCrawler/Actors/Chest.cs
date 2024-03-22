namespace DungeonCrawler;

public class Chest : Actor
{
    public Chest()
    {
        Transform.SetScale(3, 2);
        Graphics = new Graphics('$', ConsoleColor.Green);
        Trigger = true;
    }
}