namespace DungeonCrawler;

public class PawnMovement
{
    private Pawn _pawn;
    private Transform _transform;
    
    public PawnMovement(Pawn pawn)
    {
        _pawn = pawn;
        _transform = pawn.Transform;
    }
    
    // Movement
    public void MoveUp(int axis, Map map)
    {
        axis *= -1;
        
        int xPos = _transform.Position.X;
        int yPos = _transform.Position.Y;

        int lastPos = map.MapArr.GetLength(0) - 1;

        bool isTryingToExitMap = (yPos == 0 && axis < 0) || (yPos == lastPos && axis > 0);
        bool isCollidingFromTop = IsCollidingFromTop(map) && axis < 0;
        bool isCollidingFromBottom = IsCollidingFromBottom(map) && axis > 0;

        if (isTryingToExitMap || isCollidingFromBottom || isCollidingFromTop)
        {
            Console.Beep(7500, 50);
            return;
        }
        
        _transform.SetPosition(xPos, yPos + axis * _pawn.Speed);
        Console.Beep(500, 100);
    }

    public void MoveRight(int axis, Map map)
    {
        int xPos = _transform.Position.X;
        int yPos = _transform.Position.Y;
        
        int lastPos = map.MapArr.GetLength(1) - 1;

        bool isTryingToExitMap = (xPos == 0 && axis < 0) || (xPos == lastPos && axis > 0);
        bool isCollidingFromRight = IsCollidingFromRight(map) && axis > 0;
        bool isCollidingFromLeft = IsCollidingFromLeft(map) && axis < 0;

        if (isTryingToExitMap || isCollidingFromLeft || isCollidingFromRight)
        {
            Console.Beep(7500, 50);
            return;
        }
        
        _transform.SetPosition(xPos + axis * _pawn.Speed, yPos);
        Console.Beep(500, 100);
    }
    
    // Colliding
    public bool IsCollidingFromRight(Map map)
    {
        return Physics.LineTrace(_transform.Position, map, 1, Direction.Right, out char hit);
    }

    public bool IsCollidingFromLeft(Map map)
    {
        return Physics.LineTrace(_transform.Position, map, 1, Direction.Left, out char hit);
    }

    public bool IsCollidingFromTop(Map map)
    {
        return Physics.LineTrace(_transform.Position, map, 1, Direction.Up, out char hit);
    }

    public bool IsCollidingFromBottom(Map map)
    {
        return Physics.LineTrace(_transform.Position, map, 1, Direction.Down, out char hit);
    }
}