namespace DungeonCrawler;

public class Object
{
    public Transform Transform { get; private set; }
    public char Graphics { get; init; }

    public Object()
    {
        Transform = new Transform();
        Graphics = '&';
    }

    public Object(int scaleX, int scaleY)
    {
        Transform = new Transform();
        Transform.SetScale(scaleX, scaleY);
        Graphics = '&';
    }

    public Object(int scaleX, int scaleY, int xPosition, int yPosition)
    {
        Vector2 position = new Vector2(xPosition, yPosition);
        Vector2 scale = new Vector2(scaleX, scaleY);
        
        Transform = new Transform(position, scale);
        
        Graphics = '&';
    }

    public Object(Vector2 position, Vector2 scale)
    {
        Transform = new Transform(position, scale);
    }
}