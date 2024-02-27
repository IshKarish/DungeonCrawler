namespace DungeonCrawler;

public class Object
{
    public Transform Transform { get; private set; }

    public Object()
    {
        Transform = new Transform();
    }

    public Object(int scaleX, int scaleY)
    {
        Transform = new Transform();
        Transform.SetScale(scaleX, scaleY);
    }

    public Object(int scaleX, int scaleY, int xPosition, int yPosition)
    {
        Vector2 position = new Vector2(xPosition, yPosition);
        Vector2 scale = new Vector2(scaleX, scaleY);
        
        Transform = new Transform(position, scale);
    }

    public Object(Vector2 position, Vector2 scale)
    {
        Transform = new Transform(position, scale);
    }
}