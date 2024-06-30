namespace DungeonCrawler;

public class Enemy : Pawn
{
    public BehaviorTree BehaviorTree { get; set; }
    public PawnSensing PawnSensing { get; set; }
    
    // Default graphics
    private char _symbol = '!';
    private ConsoleColor _color = ConsoleColor.DarkRed;
    private string _ascii = " .----------------. \n| .--------------. |\n| |              | |\n| |      _       | |\n| |     | |      | |\n| |     | |      | |\n| |     | |      | |\n| |     |_|      | |\n| |     (_)      | |\n| '--------------' |\n '----------------' ";
    
    public Enemy(string name = "Bob") : base(name, false)
    {
        Graphics = new Graphics(_symbol, _color, _ascii);
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(this);
    }

    public Enemy(int x, int y, string name = "Bob") : base(x, y, name, false)
    {
        Graphics = new Graphics(_symbol, _color, _ascii);
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(5, this);
    }
    
    public Enemy(int x, int y, PawnSensing pawnSensing, string name = "Bob") : base(x, y, name, false)
    {
        Graphics = new Graphics(_symbol, _color, _ascii);
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = pawnSensing;
    }

    public Enemy(Vector2 position, Graphics graphics, string name = "Bob") : base(position, graphics, name, false)
    {
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(this);
    }
    
    public Enemy(Vector2 position, Graphics graphics, PawnSensing pawnSensing, string name = "Bob") : base(position, graphics, name, false)
    {
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = pawnSensing;
    }
    
    public Enemy(int x, int y, Graphics graphics, string name = "Bob") : base(x, y, graphics, name, false)
    {
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(this);
    }
    
    public Enemy(int x, int y,  Graphics graphics, PawnSensing pawnSensing, string name = "Bob") : base(x, y, graphics, name, false)
    {
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = pawnSensing;
    }
    
    public Enemy(Vector2 position, string name = "Bob") : base(position, name, false)
    {
        Graphics = new Graphics(_symbol, _color, _ascii);
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(this);
    }
    
    public Enemy(Vector2 position, PawnSensing pawnSensing, string name = "Bob") : base(position, name, false)
    {
        Graphics = new Graphics(_symbol, _color, _ascii);
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = pawnSensing;
    }
    
    public Enemy(Graphics graphics, string name = "Bob") : base(graphics, name, false)
    {
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(this);
    }
    
    public Enemy(Graphics graphics, PawnSensing pawnSensing, string name = "Bob") : base(graphics, name, false)
    {
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = pawnSensing;
    }
}