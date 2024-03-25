using System.Diagnostics;

namespace DungeonCrawler;

public class BehaviorTree
{
    private readonly Pawn _pawn;

    public BehaviorTree(Pawn pawn)
    {
        _pawn = pawn;
    }

    public void Patrol(World world, Pawn[] enemies)
    {
        Thread.Sleep(10);

        Vector2 dir = GetRandomDirection();
        while (IsCollidingEnemies(enemies))
        {
            dir = GetRandomDirection();
        }
        
        if (dir.X == 1) _pawn.PawnMovement.MoveRight(dir.Y, world);
        else _pawn.PawnMovement.MoveUp(dir.Y, world);

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

    public bool IsCollidingEnemies(Pawn[] enemies)
    {
        Debug.WriteLine(enemies.Length);
        foreach (Pawn e in enemies)
        {
            bool right = _pawn.PawnMovement.IsCollidingFromRight(e);
            bool left = _pawn.PawnMovement.IsCollidingFromLeft(e);
            bool up = _pawn.PawnMovement.IsCollidingFromTop(e);
            bool down = _pawn.PawnMovement.IsCollidingFromBottom(e);

            Debug.WriteLine($"right = {right}, left = {left}, up = {up}, down = {down}");
            if (right || left || up || down) return true;
        }
        
        return false;
    }

    public void Chase()
    {
        
    }
}