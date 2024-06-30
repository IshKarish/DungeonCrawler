namespace DungeonCrawler;

public class Player : Pawn
{
    // Player stuff
    public PawnIneractor Ineractor { get; private set; }
    public Inventory Inventory { get; private set; }
    public bool IsInventoryOpened { get; set; }
    public CombatOptions CombatOptions { get; private set; }
    
    public Player() : base()
    {
        Speed = 1;
        Ineractor = new PawnIneractor(this);
        Inventory = new Inventory();
        CombatOptions = new CombatOptions();
    }
    
    public Player(int x, int y) : base(x, y)
    {
        Graphics = new Graphics('*', ConsoleColor.White);
        Speed = 1;
        Inventory = new Inventory();
        CombatOptions = new CombatOptions();
    }

    public Player(Vector2 position, Graphics graphics) : base(position, graphics)
    {
        Ineractor = new PawnIneractor(this);
        Inventory = new Inventory();
        CombatOptions = new CombatOptions();
    }

    public Player(int x, int y, Graphics graphics) : base(x, y, graphics)
    {
        Ineractor = new PawnIneractor(this);
        Inventory = new Inventory();
        CombatOptions = new CombatOptions();
    }
    
    public Player(Vector2 position) : base(position)
    {
        Graphics = new Graphics('*', ConsoleColor.White);
        Speed = 1;
        Inventory = new Inventory();
        CombatOptions = new CombatOptions();
    }

    public Player(Graphics graphics) : base(graphics)
    {
        Ineractor = new PawnIneractor(this);
        Inventory = new Inventory();
        CombatOptions = new CombatOptions();
    }
}