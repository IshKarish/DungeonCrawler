namespace DungeonCrawler;

public class Vector2
{
    public int X { get; private set; }
    public int Y { get; private set; }

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

    public Vector2 Distance(Vector2 other, Actor type)
    {
        int xDis = other.X - Y;
        int yDis = other.Y - X;

        if (type is Pawn)
        {
            xDis = other.X - X;
            yDis = other.Y - Y;
        }

        return new Vector2(Math.Abs(xDis), Math.Abs(yDis));
    }

    public override string ToString()
    {
        return $"{X}, {Y}";
    }
}