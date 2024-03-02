namespace DungeonCrawler;

public class Door : Object
{
    public DoorOrientation DoorOrientation { get; private set; }
    public int Direction { get; private set; }
    public Door(int x, int y)
    {
        Transform.SetScale(2, 1);
        Transform.SetPosition(x, y);
        Graphics.Color = ConsoleColor.Red;
    }

    public Door(int x, int y, DoorOrientation doorOrientation, int direction)
    {
        Graphics.Color = ConsoleColor.Red;
        DoorOrientation = doorOrientation;
        Direction = direction;
        switch (DoorOrientation)
        {
            case DoorOrientation.Horizontal:
                Transform.SetScale(2, 1);
                break;
            case DoorOrientation.Vertical:
                Transform.SetScale(1, 2);
                break;
        }
        Transform.SetPosition(x, y);
    }
    
    public Door(int x, int y, DoorOrientation doorOrientation, int direction, ConsoleColor color)
    {
        Graphics.Color = color;
        DoorOrientation = doorOrientation;
        Direction = direction;
        switch (DoorOrientation)
        {
            case DoorOrientation.Horizontal:
                Transform.SetScale(2, 1);
                break;
            case DoorOrientation.Vertical:
                Transform.SetScale(1, 2);
                break;
        }
        Transform.SetPosition(x, y);
    }

    public Door(Vector2 position, DoorOrientation doorOrientation, int direction, ConsoleColor color)
    {
        Graphics.Color = color;
        DoorOrientation = doorOrientation;
        Direction = direction;
        switch (DoorOrientation)
        {
            case DoorOrientation.Horizontal:
                Transform.SetScale(2, 1);
                break;
            case DoorOrientation.Vertical:
                Transform.SetScale(1, 2);
                break;
        }
        Transform.SetPosition(position.X, position.Y);
    }
    
    public Door(Vector2 position, DoorOrientation doorOrientation, int direction)
    {
        Graphics.Color = ConsoleColor.Red;
        DoorOrientation = doorOrientation;
        Direction = direction;
        switch (DoorOrientation)
        {
            case DoorOrientation.Horizontal:
                Transform.SetScale(2, 1);
                break;
            case DoorOrientation.Vertical:
                Transform.SetScale(1, 2);
                break;
        }
        Transform.SetPosition(position.X, position.Y);
    }
}