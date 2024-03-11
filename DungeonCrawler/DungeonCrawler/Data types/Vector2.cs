namespace DungeonCrawler;

public class Vector2
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Vector2()
    {
        X = 1;
        Y = 1;
    }

    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
    }
}