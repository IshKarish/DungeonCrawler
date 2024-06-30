using System.Diagnostics;

namespace DungeonCrawler;

public class Trap : Actor
{
    public TrapDirection Direction { get; private set; }
    public bool Retracted { get; set; }
    private int _range = 5;
    public float Damage { get; private set; }
    
    public Trap(TrapDirection direction, int y, int range, Map map, float damage = 30)
    {
        Damage = damage;
        Direction = direction;
        
        int x = 0;
        char symbol = '>';
        if (direction == TrapDirection.Right)
        {
            x = map.MapArr.GetLength(1) - 1;
            symbol = '<';
        }
        
        Transform = new Transform(new Vector2(x, y));
        Graphics = new Graphics(symbol, ConsoleColor.Black);
        Trigger = true;
        Interactable = false;
    }
    
    public Trap(TrapDirection direction, int y, Map map, float damage = 30)
    {
        Damage = damage;
        Direction = direction;
        
        int x = 0;
        char symbol = '>';
        if (direction == TrapDirection.Right)
        {
            x = map.MapArr.GetLength(1) - 1;
            symbol = '<';
        }
        
        Transform = new Transform(new Vector2(x, y));
        Graphics = new Graphics(symbol, ConsoleColor.Black);
        Trigger = true;
        Interactable = false;
    }
    
    public Trap(TrapDirection direction, int y, Actor attachedActor, float damage = 30)
    {
        Damage = damage;
        Direction = direction;
        
        int x = attachedActor.Transform.Position.X + attachedActor.Transform.Scale.X + 1;
        char symbol = '>';
        if (direction == TrapDirection.Right)
        {
            x = attachedActor.Transform.Position.X - 1;
            symbol = '<';
        }

        y += attachedActor.Transform.Position.Y;
        bool yInLimit = y > attachedActor.Transform.Position.Y && y < attachedActor.Transform.Position.Y + attachedActor.Transform.Scale.Y + 1;
        
        if (!yInLimit)
        {
            y = attachedActor.Transform.Position.Y + attachedActor.Transform.Scale.Y;
        }
        
        Transform = new Transform(new Vector2(x, y));
        Graphics = new Graphics(symbol, ConsoleColor.Black);
        Trigger = true;
        Interactable = false;
    }
    
    public bool Activate(Pawn pawn)
    {
        if (Retracted) return false;
        
        bool xTrigger = pawn.Transform.Position.X == Transform.Position.X;
        bool yTrigger = pawn.Transform.Position.Y == Transform.Position.Y;
        if (xTrigger && yTrigger) return true;

        bool inRange = Physics.LineTrace(Transform.Position, pawn, _range, Direction, out HitResult hitResult);
        if (inRange)
        {
            Transform.SetScale(new Vector2(hitResult.Distance, 1));
            if (Direction == TrapDirection.Right) Transform.SetPosition(pawn.Transform.Position.X + 1, Transform.Position.Y);
            
            Retracted = true;
            Trigger = false;
        }
        
        return inRange;
    }
}