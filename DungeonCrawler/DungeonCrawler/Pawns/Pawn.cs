namespace DungeonCrawler;

public class Pawn : Actor
{
    public int Speed { get; init; }
    public PawnMovement PawnMovement { get; init; }
    
    public Pawn()
    {
        PawnMovement = new PawnMovement(this);
        Graphics = new Graphics('*', ConsoleColor.White);
        Speed = 1;
    }

    public Pawn(int x, int y)
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(x, y);
        Graphics = new Graphics('*', ConsoleColor.White);
        Speed = 1;
    }

    public Pawn(Vector2 position, Graphics graphics)
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(position.X, position.Y);
        Graphics = graphics;
        Speed = 1;
    }
    
    public Pawn(int x, int y,  Graphics graphics)
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(x, y);
        Graphics = graphics;
        Speed = 1;
    }

    public Pawn(Vector2 position)
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(position.X, position.Y);
        Graphics = new Graphics('*', ConsoleColor.White);
        Speed = 1;
    }
    
    public Pawn(Graphics graphics)
    {
        PawnMovement = new PawnMovement(this);
        Graphics = graphics;
        Speed = 1;
    }
}