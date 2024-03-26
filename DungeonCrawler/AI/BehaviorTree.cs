namespace DungeonCrawler;

public class BehaviorTree
{
    private readonly Pawn _pawn;

    public BehaviorTree(Pawn pawn)
    {
        _pawn = pawn;
    }

    public void Patrol(World world, Pawn[] pawns)
    {
        Thread.Sleep(10);

        Vector2 dir = GetRandomDirection();
        int axis = dir.Y;
        
        if (inRagne(pawns)) axis *= -1;
        
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

    bool inRagne(Pawn[] pawns)
    {
        PawnSensing sensor = new PawnSensing(1, _pawn);

        foreach (Pawn p in pawns)
        {
            if (p == _pawn) continue;
            if (sensor.CanSee(p.Transform.Position)) return true;
        }

        return false;
    }

    public void Chase()
    {
        
    }
}