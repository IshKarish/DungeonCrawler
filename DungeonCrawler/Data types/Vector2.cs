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

    public Vector2 Normalize(Vector2 other, Actor type, out float d)
    {
        float dX = other.X - Y;
        float dY = other.Y - X;

        if (type is Pawn)
        {
            dX = other.X - X;
            dY = other.Y - Y;
        }

        float xPow = (float)Math.Pow(dX, 2);
        float yPow = (float)Math.Pow(dY, 2);
        d = (float)Math.Sqrt(xPow + yPow);

        Vector2 vec = new Vector2(dX / d, dY / d);
        return vec;
    }
}