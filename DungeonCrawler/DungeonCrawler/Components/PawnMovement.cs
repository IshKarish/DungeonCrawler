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
    
    public void MoveUp(int axis, Map map, NavMesh navMesh)
    {
        axis *= -1;
        
        int xPos = _transform.Position.X;
        int yPos = _transform.Position.Y;

        int lastPos = map.MapArr.GetLength(0) - 1;

        bool isTryingToExitMap = (yPos == 0 && axis < 0) || (yPos == lastPos && axis > 0);
        bool isCollidingFromTop = this.isCollidingFromTop(navMesh) && axis < 0;
        bool isCollidingFromBottom = this.isCollidingFromBottom(navMesh) && axis > 0;

        if (isTryingToExitMap || isCollidingFromBottom || isCollidingFromTop)
        {
            Console.Beep(7500, 50);
            return;
        }
        
        _transform.SetPosition(xPos, yPos + axis * _pawn.Speed);
        Console.Beep(500, 100);
    }

    public void MoveRight(int axis, Map map, NavMesh navMesh)
    {
        int xPos = _transform.Position.X;
        int yPos = _transform.Position.Y;
        
        int lastPos = map.MapArr.GetLength(1) - 1;

        bool isTryingToExitMap = (xPos == 0 && axis < 0) || (xPos == lastPos && axis > 0);
        bool isCollidingFromRight = IsCollidingFromRight(navMesh) && axis > 0;
        bool isCollidingFromLeft = this.isCollidingFromLeft(navMesh) && axis < 0;

        if (isTryingToExitMap || isCollidingFromLeft || isCollidingFromRight)
        {
            Console.Beep(7500, 50);
            return;
        }
        
        _transform.SetPosition(xPos + axis * _pawn.Speed, yPos);
        Console.Beep(500, 100);
    }

    // Colliding states
    public bool IsCollidingFromRight(NavMesh navMesh)
    {
        return Physics.IsNextXColliding(_pawn, navMesh, 1);
    }

    public bool isCollidingFromLeft(NavMesh navMesh)
    {
        return Physics.IsNextXColliding(_pawn, navMesh, -1);
    }

    public bool isCollidingFromTop(NavMesh navMesh)
    {
        return Physics.IsNextYColliding(_pawn, navMesh, -1);
    }

    public bool isCollidingFromBottom(NavMesh navMesh)
    {
        return Physics.IsNextYColliding(_pawn, navMesh, 1);
    }
}