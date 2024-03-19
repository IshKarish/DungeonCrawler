using System.Diagnostics;

namespace DungeonCrawler;

public class BehaviorTree
{
    private readonly Pawn _pawn;

    public BehaviorTree(Pawn pawn)
    {
        _pawn = pawn;
    }

    public void Patrol(World world)
    {
        int axis = Random.Shared.Next(0, 2);
        int direction = Random.Shared.Next(-1, 2);

        while (direction == 0)
        {
            direction = Random.Shared.Next(-1, 2);
        }
        Debug.WriteLine(direction);
        
        if (axis == 1) _pawn.PawnMovement.MoveRight(direction, world);
        else _pawn.PawnMovement.MoveUp(direction, world);

        if (_pawn is Enemy e) e.PawnSensing.SetCenter(_pawn.Transform.Position);
    }

    public void Chase()
    {
        
    }
}