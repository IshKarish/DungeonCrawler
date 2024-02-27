namespace DungeonCrawler;

public class Transform
{
    public Vector2 Position { get; private set; }
    public Vector2 Scale { get; private set; }

    public Transform()
    {
        Position = new Vector2();
        Scale = new Vector2();
    }

    public void SetPosition(int x, int y)
    {
        Position = new Vector2(x, y);
    }
    
    public void SetScale(int x, int y)
    {
        Scale = new Vector2(x, y);
    }
}