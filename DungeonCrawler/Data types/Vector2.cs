namespace DungeonCrawler;

public class Vector2
{
    public int X { get; private set; }
    public int Y { get; private set; }
    
    public float fX { get; private set; }
    public float fY { get; private set; }

    public Vector2()
    {
        X = 0;
        Y = 0;
    }

    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public Vector2(float x, float y)
    {
        fX = x;
        fY = y;
    }
}