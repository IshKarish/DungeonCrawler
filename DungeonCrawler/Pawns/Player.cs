namespace DungeonCrawler;

public class Player : Pawn
{
    public PawnIneractor Ineractor { get; private set; }
    
    public Player()
    {
        PawnMovement = new PawnMovement(this);
        Graphics = new Graphics('*', ConsoleColor.White);
        Speed = 1;
        Ineractor = new PawnIneractor(this);
    }
    
    public Player(int x, int y)
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(x, y);
        Graphics = new Graphics('*', ConsoleColor.White);
        Speed = 1;
    }

    public Player(Vector2 position, Graphics graphics) : base(position, graphics)
    {
        Ineractor = new PawnIneractor(this);
    }

    public Player(int x, int y, Graphics graphics) : base(x, y, graphics)
    {
        Ineractor = new PawnIneractor(this);
    }
    
    public Player(Vector2 position)
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(position.X, position.Y);
        Graphics = new Graphics('*', ConsoleColor.White);
        Speed = 1;
    }

    public Player(Graphics graphics) : base(graphics)
    {
        Ineractor = new PawnIneractor(this);
    }
}