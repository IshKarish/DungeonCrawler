namespace DungeonCrawler;

public class Door : Actor
{
    public DoorDirection Direction { get; private set; }

    public Door(int x, int y)
    {
        Transform.SetScale(4, 2);
        Transform.SetPosition(x, y);
        Graphics.Color = ConsoleColor.Red;
    }

    public Door(int x, int y, DoorDirection direction)
    {
        Graphics.Color = ConsoleColor.Red;
        Direction = direction;

        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(x, y);
    }
    
    public Door(int x, int y, DoorDirection direction, ConsoleColor color)
    {
        Graphics.Color = color;
        Direction = direction;
        
        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(x, y);
    }

    public Door(Vector2 position, DoorDirection direction, ConsoleColor color)
    {
        Graphics.Color = color;
        Direction = direction;
        
        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(position.X, position.Y);
    }
    
    public Door(Vector2 position, DoorDirection direction)
    {
        Graphics.Color = ConsoleColor.Red;
        Direction = direction;
        
        if (direction == DoorDirection.Up || direction == DoorDirection.Down) Transform.SetScale(3, 2);
        else Transform.SetScale(2, 3);
        
        Transform.SetPosition(position.X, position.Y);
    }
}