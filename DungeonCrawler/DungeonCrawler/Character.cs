namespace DungeonCrawler;

public class Character
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public int LastX { get; set; }
    public int LastY { get; set; }
    
    public Character() {}
    
    public Character(int lastX, int lastY)
    {
        LastX = lastX;
        LastY = lastY;
    }

    public Character(int x, int y, int lastX, int lastY)
    {
        X = x;
        Y = y;
        
        LastX = lastX;
        LastY = lastY;
    }

    public void MoveUp(int axis)
    {
        bool isGoingOutsideOfMap = (Y == 0 && axis < 0) || (Y == LastY - 1 && axis > 0);
        
        if (isGoingOutsideOfMap) return;
        Y += axis;
    }

    public void MoveRight(int axis)
    {
        bool isGoingOutsideOfMap = (X == 0 && axis < 0) || (X == LastX - 1 && axis > 0);
        
        if (isGoingOutsideOfMap) return;
        X += axis;
    }
}