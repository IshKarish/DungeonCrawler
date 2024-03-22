namespace DungeonCrawler;

public class Transform
{
    public Vector2 Position { get; private set; }
    public Vector2 Scale { get; private set; }
    public Transform LastTransform { get; private set; }

    public Transform()
    {
        Position = new Vector2();
        Scale = new Vector2();
    }

    public Transform(Vector2 position, Vector2 scale)
    {
        Position = position;
        Scale = new Vector2(scale.X - 1, scale.Y - 1);
    }

    public Transform(Vector2 position)
    {
        Position = position;
        Scale = new Vector2();
    }

    public void SetPosition(int x, int y)
    {
        LastTransform = new Transform(Position, Scale);
        Position = new Vector2(x, y);
    }
    
    public void SetPosition(Vector2 position)
    {
        LastTransform = new Transform(Position, Scale);
        Position = position;
    }
    
    public void SetScale(int x, int y)
    {
        LastTransform = new Transform(Position, Scale);
        Scale = new Vector2(x - 1, y - 1);
    }
    
    public void SetScale(Vector2 scale)
    {
        LastTransform = new Transform(Position, Scale);
        Scale = new Vector2(scale.X - 1, scale.Y - 1);
    }

    public void SetLastTransform(Transform transform)
    {
        LastTransform = new Transform(transform.Position, transform.Scale);
    }
}