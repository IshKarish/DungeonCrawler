namespace DungeonCrawler;

public class Enemy : Pawn
{
    public BehaviorTree BehaviorTree { get; set; }
    public Enemy()
    {
        Graphics = new Graphics('!', ConsoleColor.DarkRed);
        BehaviorTree = new BehaviorTree(this);
    }

    public Enemy(int x, int y)
    {
        Transform.SetPosition(x, y);
        Graphics = new Graphics('!', ConsoleColor.DarkRed);
        BehaviorTree = new BehaviorTree(this);
    }

    public Enemy(Vector2 position, Graphics graphics)
    {
        Transform.SetPosition(position.X, position.Y);
        Graphics = graphics;
        BehaviorTree = new BehaviorTree(this);
    }
    
    public Enemy(int x, int y,  Graphics graphics)
    {
        Transform.SetPosition(x, y);
        Graphics = graphics;
        BehaviorTree = new BehaviorTree(this);
    }

    public Enemy(Vector2 position)
    {
        Transform.SetPosition(position.X, position.Y);
        Graphics = new Graphics('!', ConsoleColor.DarkRed);
        BehaviorTree = new BehaviorTree(this);
    }
    
    public Enemy(Graphics graphics)
    {
        Graphics = graphics;
        BehaviorTree = new BehaviorTree(this);
    }
}