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
    public void MoveUp(int axis, World world)
    {
        if (!_pawn.Moved) _pawn.Moved = true;
        
        axis *= -1;
        
        int xPos = _transform.Position.X;
        int yPos = _transform.Position.Y;

        int lastPos = world.WorldArr.GetLength(0) - 1;

        bool isTryingToExitMap = (yPos == 0 && axis < 0) || (yPos == lastPos && axis > 0);
        bool isCollidingFromTop = IsCollidingFromTop(world) && axis < 0;
        bool isCollidingFromBottom = IsCollidingFromBottom(world) && axis > 0;

        if (isTryingToExitMap || isCollidingFromBottom || isCollidingFromTop)
        {
            //Console.Beep(7500, 50);
            return;
        }
        
        _transform.SetPosition(xPos, yPos + axis * _pawn.Speed);
        //Console.Beep(500, 100);
    }

    public void MoveRight(int axis, World world)
    {
        if (!_pawn.Moved) _pawn.Moved = true;
        
        int xPos = _transform.Position.X;
        int yPos = _transform.Position.Y;
        
        int lastPos = world.WorldArr.GetLength(1) - 1;

        bool isTryingToExitMap = (xPos == 0 && axis < 0) || (xPos == lastPos && axis > 0);
        bool isCollidingFromRight = IsCollidingFromRight(world) && axis > 0;
        bool isCollidingFromLeft = IsCollidingFromLeft(world) && axis < 0;

        if (isTryingToExitMap || isCollidingFromLeft || isCollidingFromRight)
        {
            //Console.Beep(7500, 50);
            return;
        }
        
        _transform.SetPosition(xPos + axis * _pawn.Speed, yPos);
        //Console.Beep(500, 100);
    }
    
    // Colliding
    public bool IsCollidingFromRight(World world)
    {
        return Physics.LineTrace(_transform.Position, world, 1, Direction.Right, out HitResult hitResult) && !hitResult.HitActor.Trigger;
    }

    public bool IsCollidingFromLeft(World world)
    {
        return Physics.LineTrace(_transform.Position, world, 1, Direction.Left, out HitResult hitResult) && !hitResult.HitActor.Trigger;
    }

    public bool IsCollidingFromTop(World world)
    {
        return Physics.LineTrace(_transform.Position, world, 1, Direction.Up, out HitResult hitResult) && !hitResult.HitActor.Trigger;
    }

    public bool IsCollidingFromBottom(World world)
    {
        return Physics.LineTrace(_transform.Position, world, 1, Direction.Down, out HitResult hitResult) && !hitResult.HitActor.Trigger;
    }

    // Pawn colliders
    public bool IsCollidingFromRight(Pawn pawn)
    {
        return Physics.LineTrace(_transform.Position, pawn, 1, Direction.Right, out HitResult hitResult);
    }

    public bool IsCollidingFromLeft(Pawn pawn)
    {
        return Physics.LineTrace(_transform.Position, pawn, 1, Direction.Left, out HitResult hitResult);
    }

    public bool IsCollidingFromTop(Pawn pawn)
    {
        return Physics.LineTrace(_transform.Position, pawn, 1, Direction.Up, out HitResult hitResult);
    }

    public bool IsCollidingFromBottom(Pawn pawn)
    {
        return Physics.LineTrace(_transform.Position, pawn, 1, Direction.Down, out HitResult hitResult);
    }
}