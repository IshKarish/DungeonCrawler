namespace DungeonCrawler;

public class Actor
{
    public Transform Transform { get; init; }
    public Graphics Graphics { get; init; }
    public bool Trigger { get; set; }
    public bool CanInteract { get; set; }

    public Actor()
    {
        Transform = new Transform();
        Graphics = new Graphics('&', ConsoleColor.Red);
        Trigger = false;
        CanInteract = false;
    }
    
    public Actor(Graphics graphics)
    {
        Transform = new Transform();
        Graphics = graphics;
        Trigger = false;
        CanInteract = false;
    }

    public Actor(int scaleX, int scaleY, Graphics graphics)
    {
        Transform = new Transform();
        Transform.SetScale(scaleX, scaleY);
        Graphics = graphics;
        Trigger = false;
        CanInteract = false;
    }

    public Actor(int xPosition, int yPosition, int scaleX, int scaleY, Graphics graphics)
    {
        Vector2 position = new Vector2(xPosition, yPosition);
        Vector2 scale = new Vector2(scaleX, scaleY);
        Transform = new Transform(position, scale);
        
        Graphics = graphics;
        Trigger = false;
        CanInteract = false;
    }

    public Actor(Vector2 scale, Graphics graphics)
    {
        Transform = new Transform();
        Transform.SetScale(scale.X, scale.Y);
        Graphics = graphics;
        Trigger = false;
        CanInteract = false;
    }

    public Actor(Vector2 position, Vector2 scale, Graphics graphics)
    {
        Graphics = graphics;
        Transform = new Transform(position, scale);
        Trigger = false;
        CanInteract = false;
    }

    public Actor(Transform transform, Graphics graphics)
    {
        Transform = transform;
        Graphics = graphics;
        Trigger = false;
        CanInteract = false;
    }
    
    public Actor(Transform transform)
    {
        Transform = transform;
        Graphics = new Graphics('&', ConsoleColor.Red);
        Trigger = false;
        CanInteract = false;
    }
}