namespace DungeonCrawler;

public class Enemy : Pawn
{
    public BehaviorTree BehaviorTree { get; set; }
    public PawnSensing PawnSensing { get; set; }
    public CombatOptions CombatOptions { get; private set; }
    
    // Default graphics
    private char _symbol = '!';
    private ConsoleColor _color = ConsoleColor.DarkRed;
    private string _ascii = " .----------------. \n| .--------------. |\n| |              | |\n| |      _       | |\n| |     | |      | |\n| |     | |      | |\n| |     | |      | |\n| |     |_|      | |\n| |     (_)      | |\n| '--------------' |\n '----------------' ";
    
    public Enemy(string name = "Bob")
    {
        Graphics = new Graphics(_symbol, _color, _ascii);
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(this);
        CombatOptions = new CombatOptions(this);
        Name = name;
    }

    public Enemy(int x, int y, string name = "Bob")
    {
        Transform.SetPosition(x, y);
        Graphics = new Graphics(_symbol, _color, _ascii);
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(5, this);
        CombatOptions = new CombatOptions(this);
        Name = name;
    }
    
    public Enemy(int x, int y, PawnSensing pawnSensing, string name = "Bob")
    {
        Transform.SetPosition(x, y);
        Graphics = new Graphics(_symbol, _color, _ascii);
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = pawnSensing;
        CombatOptions = new CombatOptions(this);
        Name = name;
    }

    public Enemy(Vector2 position, Graphics graphics, string name = "Bob")
    {
        Transform.SetPosition(position.X, position.Y);
        Graphics = graphics;
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(this);
        CombatOptions = new CombatOptions(this);
        Name = name;
    }
    
    public Enemy(Vector2 position, Graphics graphics, PawnSensing pawnSensing, string name = "Bob")
    {
        Transform.SetPosition(position.X, position.Y);
        Graphics = graphics;
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = pawnSensing;
        CombatOptions = new CombatOptions(this);
        Name = name;
    }
    
    public Enemy(int x, int y,  Graphics graphics, string name = "Bob")
    {
        Transform.SetPosition(x, y);
        Graphics = graphics;
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(this);
        CombatOptions = new CombatOptions(this);
        Name = name;
    }
    
    public Enemy(int x, int y,  Graphics graphics, PawnSensing pawnSensing, string name = "Bob")
    {
        Transform.SetPosition(x, y);
        Graphics = graphics;
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = pawnSensing;
        CombatOptions = new CombatOptions(this);
        Name = name;
    }
    
    public Enemy(Vector2 position, string name = "Bob")
    {
        Transform.SetPosition(position.X, position.Y);
        Graphics = new Graphics(_symbol, _color, _ascii);
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(this);
        CombatOptions = new CombatOptions(this);
        Name = name;
    }
    
    public Enemy(Vector2 position, PawnSensing pawnSensing, string name = "Bob")
    {
        Transform.SetPosition(position.X, position.Y);
        Graphics = new Graphics(_symbol, _color, _ascii);
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = pawnSensing;
        CombatOptions = new CombatOptions(this);
        Name = name;
    }
    
    public Enemy(Graphics graphics, string name = "Bob")
    {
        Graphics = graphics;
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = new PawnSensing(this);
        CombatOptions = new CombatOptions(this);
        Name = name;
    }
    
    public Enemy(Graphics graphics, PawnSensing pawnSensing, string name = "Bob")
    {
        Graphics = graphics;
        BehaviorTree = new BehaviorTree(this);
        PawnSensing = pawnSensing;
        CombatOptions = new CombatOptions(this);
        Name = name;
    }
}