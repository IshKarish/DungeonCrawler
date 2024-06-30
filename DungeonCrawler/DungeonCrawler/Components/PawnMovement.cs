namespace DungeonCrawler;

public class PawnMovement
{
    private Pawn _pawn;
    private Transform _transform;

    private bool _canEnterTriggers;

    public PawnMovement(Pawn pawn, bool canEnterTriggers)
    {
        _pawn = pawn;
        _transform = pawn.Transform;

        _canEnterTriggers = canEnterTriggers;
    }
    
    // Movement
    public void MoveUp(int axis, World world)
    {
        if (!_pawn.Moved) _pawn.Moved = true;
        
        Thread.Sleep(10);
        
        axis *= -1;
        
        int xPos = _transform.Position.X;
        int yPos = _transform.Position.Y;

        int lastPos = world.WorldArr.GetLength(0) - 1;

        bool isTryingToExitMap = (yPos == 0 && axis < 0) || (yPos == lastPos && axis > 0);
        bool isCollidingFromTop = IsCollidingFromTop(world) && axis < 0;
        bool isCollidingFromBottom = IsCollidingFromBottom(world) && axis > 0;

        if (isTryingToExitMap || isCollidingFromBottom || isCollidingFromTop) return;
        _transform.SetPosition(xPos, yPos + axis * _pawn.Speed);
    }

    public void MoveRight(int axis, World world)
    {
        if (!_pawn.Moved) _pawn.Moved = true;
        
        Thread.Sleep(11);
        
        int xPos = _transform.Position.X;
        int yPos = _transform.Position.Y;
        
        int lastPos = world.WorldArr.GetLength(1) - 1;
        
        bool isTryingToExitMap = (xPos == 0 && axis < 0) || (xPos == lastPos && axis > 0);
        bool isCollidingFromRight = IsCollidingFromRight(world) && axis > 0;
        bool isCollidingFromLeft = IsCollidingFromLeft(world) && axis < 0;

        if (isTryingToExitMap || isCollidingFromLeft || isCollidingFromRight) return;
        _transform.SetPosition(xPos + axis * _pawn.Speed, yPos);
    }
    
    // Colliding
    void OnActorBeginOverlap(Actor hitActor) // I forgot why i made this function but left it anyway because why not
    {
        
    }
    
    bool IsCollidingFromRight(World world)
    {
        bool isColliding = Physics.LineTrace(_transform.Position, world, 1, Direction.Right, out HitResult hitResult);
        if (_canEnterTriggers) isColliding = Physics.LineTrace(_transform.Position, world, 1, Direction.Right, out hitResult) && !hitResult.HitActor.Trigger;
        
        return isColliding;
    }

    bool IsCollidingFromLeft(World world)
    {
        bool isColliding = Physics.LineTrace(_transform.Position, world, 1, Direction.Left, out HitResult hitResult);
        if (_canEnterTriggers) isColliding = Physics.LineTrace(_transform.Position, world, 1, Direction.Left, out hitResult) && !hitResult.HitActor.Trigger;
        
        return isColliding;
    }

    bool IsCollidingFromTop(World world)
    {
        bool isColliding = Physics.LineTrace(_transform.Position, world, 1, Direction.Up, out HitResult hitResult);
        if (_canEnterTriggers) isColliding = Physics.LineTrace(_transform.Position, world, 1, Direction.Up, out hitResult) && !hitResult.HitActor.Trigger;
        
        return isColliding;
    }

    bool IsCollidingFromBottom(World world)
    {
        bool isColliding = Physics.LineTrace(_transform.Position, world, 1, Direction.Down, out HitResult hitResult);
        if (_canEnterTriggers) isColliding = Physics.LineTrace(_transform.Position, world, 1, Direction.Down, out hitResult) && !hitResult.HitActor.Trigger;
        
        return isColliding;
    }

    public bool IsOverlapped(World world, out Actor hitActor)
    {
        bool isOverlapping = Physics.LineTrace(_transform.Position, world, out HitResult hitResult);
        hitActor = hitResult.HitActor;
        
        if (isOverlapping) OnActorBeginOverlap(hitActor);
        return isOverlapping;
    }
    
    public bool IsOverlapped(Pawn[] pawns, out Actor hitActor)
    {
        bool isOverlapping = Physics.LineTrace(_transform.Position, pawns, out HitResult hitResult);
        hitActor = hitResult.HitActor;
        
        if (isOverlapping) OnActorBeginOverlap(hitActor);
        return isOverlapping;
    }
}