namespace DungeonCrawler;

public class Object
{
    public Transform Transform { get; private set; }
    public Graphics Graphics { get; init; }

    public Object()
    {
        Transform = new Transform();
        Graphics = new Graphics('&', ConsoleColor.Red);
    }
    
    public Object(Graphics graphics)
    {
        Transform = new Transform();
        Graphics = graphics;
    }

    public Object(int scaleX, int scaleY, Graphics graphics)
    {
        Transform = new Transform();
        Transform.SetScale(scaleX, scaleY);
        Graphics = graphics;
    }

    public Object(int scaleX, int scaleY, int xPosition, int yPosition, Graphics graphics)
    {
        Vector2 position = new Vector2(xPosition, yPosition);
        Vector2 scale = new Vector2(scaleX, scaleY);
        
        Transform = new Transform(position, scale);
        
        Graphics = graphics;
    }

    public Object(Vector2 scale, Graphics graphics)
    {
        Transform = new Transform();
        Transform.SetScale(scale.X, scale.Y);
        Graphics = graphics;
    }

    public Object(Vector2 position, Vector2 scale, Graphics graphics)
    {
        Graphics = graphics;
        Transform = new Transform(position, scale);
    }

    public Object(Transform transform, Graphics graphics)
    {
        Transform = transform;
        Graphics = graphics;
    }
}