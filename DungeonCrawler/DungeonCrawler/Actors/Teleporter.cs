namespace DungeonCrawler;

public class Teleporter : Actor
{
    public Level Destination { get; private set; }
    public Door Door { get; private set; }
    
    public Teleporter(Door door)
    {
        Door = door;
        Destination = door.Destination;
    }
    
    public Teleporter(int x, int y, Level destination)
    {
        Transform = new Transform(new Vector2(x, y));
        Destination = destination;
        Trigger = true;
    }

    public Teleporter(int x, int y, Level destination, Graphics graphics)
    {
        Transform = new Transform(new Vector2(x, y));
        Destination = destination;
        Trigger = true;
        Graphics = graphics;
    }
    
    public Teleporter(int x, int y, int xSize, int ySize, Level destination, Graphics graphics)
    {
        Transform = new Transform(new Vector2(x, y), new Vector2(xSize, ySize));
        Destination = destination;
        Trigger = true;
        Graphics = graphics;
    }
    
    public Teleporter(int x, int y, int xSize, int ySize, Level destination)
    {
        Transform = new Transform(new Vector2(x, y), new Vector2(xSize, ySize));
        Destination = destination;
        Trigger = true;
    }


    public void ChangeDestination(Level destination)
    {
        Destination = destination;
    }
}