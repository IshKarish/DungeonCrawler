namespace DungeonCrawler;

public class BehaviorTree
{
    private Pawn _pawn;

    public BehaviorTree(Pawn pawn)
    {
        _pawn = pawn;
    }

    public void Patrol(Map map, NavMesh navMesh)
    {
        int direction = Random.Shared.Next(0, 1);
        int dir = Random.Shared.Next(-1, 1);
        
        if (direction == 1) _pawn.PawnMovement.MoveRight(1, map, navMesh);
        else _pawn.PawnMovement.MoveUp(1, map, navMesh);

        //Console.WriteLine(_pawn);
    }
}