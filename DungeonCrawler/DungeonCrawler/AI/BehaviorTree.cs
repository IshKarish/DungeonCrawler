namespace DungeonCrawler;

public class BehaviorTree
{
    private Pawn _pawn;
    public bool ShouldChase { get; set; }

    public BehaviorTree(Pawn pawn)
    {
        _pawn = pawn;
    }

    public void Patrol(Map map, NavMesh navMesh)
    {
        int direction = Random.Shared.Next(0, 2);
        int dir = 0;

        while (dir == 0)
        {
            dir = Random.Shared.Next(-1, 1);
        }
        
        if (direction == 1) _pawn.PawnMovement.MoveRight(dir, map, navMesh);
        else _pawn.PawnMovement.MoveUp(dir, map, navMesh);

        if (_pawn is Enemy e) e.PawnSensing.SetCenter(_pawn.Transform.Position);
    }

    public void Chase()
    {
        
    }
}