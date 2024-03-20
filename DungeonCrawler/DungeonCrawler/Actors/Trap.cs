namespace DungeonCrawler;

public class Trap : Actor
{
    private int _range = 5;
    
    public Trap(int x, int y, int range)
    {
        Transform = new Transform(new Vector2(x, y));
        Graphics = new Graphics('>', ConsoleColor.Black);
        Trigger = true;
        Interactable = false;
        _range = range;
    }

    public Trap(Vector2 position, int range)
    {
        Transform = new Transform(position);
        Graphics = new Graphics('>', ConsoleColor.Black);
        Trigger = true;
        Interactable = false;
        _range = range;
    }
    
    public Trap(int x, int y)
    {
        Transform = new Transform(new Vector2(x, y));
        Graphics = new Graphics('>', ConsoleColor.Black);
        Trigger = true;
        Interactable = false;
    }

    public Trap(Vector2 position)
    {
        Transform = new Transform(position);
        Graphics = new Graphics('>', ConsoleColor.Black);
        Trigger = true;
        Interactable = false;
    }

    public bool ShouldKill(Pawn pawn)
    {
        bool xTrigger = pawn.Transform.Position.X == Transform.Position.X;
        bool yTrigger = pawn.Transform.Position.Y == Transform.Position.Y;
        if (xTrigger && yTrigger) return true;

        bool inRange = Physics.LineTrace(Transform.Position, pawn, _range, Direction.Right, out HitResult hitResult);
        return inRange;
    }
}