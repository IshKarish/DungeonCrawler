namespace DungeonCrawler;

public class Pawn : Actor
{
    public int Speed { get; init; } = 1;
    public PawnMovement PawnMovement { get; init; }
    public bool IsDead { get; private set; }
    public bool Moved { get; set; }
    public string Name { get; init; }

    public float HP { get; private set; } = 100;
    
    public Pawn(string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Graphics = new Graphics('@', ConsoleColor.Gray);
        Name = name;
    }

    public Pawn(int x, int y, string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(x, y);
        Graphics = new Graphics('@', ConsoleColor.Gray);
        Name = name;
    }

    public Pawn(Vector2 position, Graphics graphics, string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(position.X, position.Y);
        Graphics = graphics;
        Name = name;
    }
    
    public Pawn(int x, int y,  Graphics graphics, string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(x, y);
        Graphics = graphics;
        Name = name;
    }

    public Pawn(Vector2 position, string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Transform.SetPosition(position.X, position.Y);
        Graphics = new Graphics('@', ConsoleColor.Gray);
        Name = name;
    }
    
    public Pawn(Graphics graphics, string name = "Bob")
    {
        PawnMovement = new PawnMovement(this);
        Graphics = graphics;
        Name = name;
    }

    public void Heal(float amount)
    {
        HP += amount;
    }

    public void Damage(int amount)
    {
        if (HP - amount <= 0) Kill();
        else if (HP > 0) HP -= amount;
    }

    public void Kill()
    {
        HP = 0;
        IsDead = true;
    }
}