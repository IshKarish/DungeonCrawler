namespace DungeonCrawler;

public class Actor
{
    public Transform Transform { get; init; }
    public Graphics Graphics { get; init; }

    public Actor()
    {
        Transform = new Transform();
        Graphics = new Graphics('&', ConsoleColor.Red);
    }
    
    public Actor(Graphics graphics)
    {
        Transform = new Transform();
        Graphics = graphics;
    }

    public Actor(int scaleX, int scaleY, Graphics graphics)
    {
        Transform = new Transform();
        Transform.SetScale(scaleX, scaleY);
        Graphics = graphics;
    }

    public Actor(int xPosition, int yPosition, int scaleX, int scaleY, Graphics graphics)
    {
        Vector2 position = new Vector2(xPosition, yPosition);
        Vector2 scale = new Vector2(scaleX, scaleY);
        
        Transform = new Transform(position, scale);
        
        Graphics = graphics;
    }

    public Actor(Vector2 scale, Graphics graphics)
    {
        Transform = new Transform();
        Transform.SetScale(scale.X, scale.Y);
        Graphics = graphics;
    }

    public Actor(Vector2 position, Vector2 scale, Graphics graphics)
    {
        Graphics = graphics;
        Transform = new Transform(position, scale);
    }

    public Actor(Transform transform, Graphics graphics)
    {
        Transform = transform;
        Graphics = graphics;
    }
    
    public Actor(Transform transform)
    {
        Transform = transform;
        Graphics = new Graphics('&', ConsoleColor.Red);
    }
}