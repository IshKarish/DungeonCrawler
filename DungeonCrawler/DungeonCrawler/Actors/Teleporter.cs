namespace DungeonCrawler;

public class Teleporter : Actor
{
    public Level Destination { get; private set; }
    public Teleporter(Door door)
    {
        Destination = door.Destination;
    }
}