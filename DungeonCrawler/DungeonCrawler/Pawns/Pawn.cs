namespace DungeonCrawler;

public class Pawn : Actor
{
    public PawnMovement PawnMovement { get; init; }
    
    public Pawn()
    {
        PawnMovement = new PawnMovement(this);
        Graphics = new Graphics('*', ConsoleColor.White);
    }

    public Pawn(int x, int y)
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(x, y);
        Graphics = new Graphics('*', ConsoleColor.White);
    }

    public Pawn(Vector2 position, Graphics graphics)
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(position.X, position.Y);
        Graphics = graphics;
    }
    
    public Pawn(int x, int y,  Graphics graphics)
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(x, y);
        Graphics = graphics;
    }

    public Pawn(Vector2 position)
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(position.X, position.Y);
        Graphics = new Graphics('*', ConsoleColor.White);
    }
    
    public Pawn(Graphics graphics)
    {
        PawnMovement = new PawnMovement(this);
        Graphics = graphics;
    }
}