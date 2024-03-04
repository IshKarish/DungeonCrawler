namespace DungeonCrawler;

public class Enemy : Pawn
{
    public Enemy()
    {
        Graphics = new Graphics('!', ConsoleColor.DarkRed);
    }

    public Enemy(int x, int y)
    {
        Transform.SetPosition(x, y);
        Graphics = new Graphics('!', ConsoleColor.DarkRed);
    }

    public Enemy(Vector2 position, Graphics graphics)
    {
        Transform.SetPosition(position.X, position.Y);
        Graphics = graphics;
    }
    
    public Enemy(int x, int y,  Graphics graphics)
    {
        Transform.SetPosition(x, y);
        Graphics = graphics;
    }

    public Enemy(Vector2 position)
    {
        Transform.SetPosition(position.X, position.Y);
        Graphics = new Graphics('!', ConsoleColor.DarkRed);
    }
    
    public Enemy(Graphics graphics)
    {
        Graphics = graphics;
    }
}