namespace DungeonCrawler;

public class BehaviorTree
{
    private readonly Pawn _pawn;
    public bool IsChasing { get; set; }

    public BehaviorTree(Pawn pawn)
    {
        _pawn = pawn;
    }

    public void Patrol(World world, Pawn[] pawns)
    {
        Thread.Sleep(10);

        Vector2 dir = GetRandomDirection();
        int axis = dir.Y;
        
        //if (InRange(pawns)) axis *= -1;
        
        if (dir.X == 1) _pawn.PawnMovement.MoveRight(axis, world);
        else _pawn.PawnMovement.MoveUp(axis, world);

        if (_pawn is Enemy e) e.PawnSensing.SetCenter(_pawn.Transform.Position);
    }

    Vector2 GetRandomDirection()
    {
        int axis = Random.Shared.Next(0, 2);
        int dir = Random.Shared.Next(-1, 2);

        while (dir == 0)
        {
            dir = Random.Shared.Next(-1, 2);
        }

        return new Vector2(axis, dir);
    }

    public void Chase(World world, Pawn pawn)
    {
        int xDistance = pawn.Transform.Position.X - _pawn.Transform.Position.X;
        int yDistance = pawn.Transform.Position.Y - _pawn.Transform.Position.Y;

        if (xDistance > 0) _pawn.PawnMovement.MoveRight(1, world);
        else if (xDistance < 0) _pawn.PawnMovement.MoveRight(-1, world);
        
        Thread.Sleep(1);

        if (yDistance > 0) _pawn.PawnMovement.MoveUp(-1, world);
        else if (yDistance < 0) _pawn.PawnMovement.MoveUp(1, world);
    }
}