namespace DungeonCrawler;

public class Door : Object
{
    public DoorOrientation DoorOrientation { get; private set; }
    public int Direction { get; private set; }
    public Door(int x, int y)
    {
        Transform.SetScale(2, 1);
        Transform.SetPosition(x, y);
        //Graphics = '!';
    }

    public Door(int x, int y, DoorOrientation doorOrientation, int direction)
    {
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
}