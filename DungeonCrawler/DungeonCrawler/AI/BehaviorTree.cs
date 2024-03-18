using System.Diagnostics;

namespace DungeonCrawler;

public class BehaviorTree
{
    private readonly Pawn _pawn;

    public BehaviorTree(Pawn pawn)
    {
        _pawn = pawn;
    }

    public void Patrol(Map map, NavMesh navMesh)
    {
        int axis = Random.Shared.Next(0, 2);
        int direction = Random.Shared.Next(-1, 2);

        while (direction == 0)
        {
            direction = Random.Shared.Next(-1, 2);
        }
        Debug.WriteLine(direction);
        
        if (axis == 1) _pawn.PawnMovement.MoveRight(direction, map);
        else _pawn.PawnMovement.MoveUp(direction, map);

        if (_pawn is Enemy e) e.PawnSensing.SetCenter(_pawn.Transform.Position);
    }

    public void Chase()
    {
        
    }
}