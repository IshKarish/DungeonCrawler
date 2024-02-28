namespace DungeonCrawler;

public class Character
{
    public Transform Transform { get; private set; }

    public Character()
    {
        Transform = new Transform();
    }

    public int Raycast()
    {
        return Transform.Position.X + 1;
    }

    public void MoveUp(int axis)
    {
        if (!inMapBounds()) return;
        
        int xPos = Transform.Position.X;
        int yPos = Transform.Position.Y;

        bool isTryingToExitMap = (yPos == 0 && axis < 0) || (yPos == 19 && axis > 0);
        if (isTryingToExitMap) return;
        
        Transform.SetPosition(xPos, yPos + axis);
    }

    public void MoveRight(int axis)
    {
        if (!inMapBounds()) return;
        
        int xPos = Transform.Position.X;
        int yPos = Transform.Position.Y;

        bool isTryingToExitMap = (xPos == 0 && axis < 0) || (xPos == 19 && axis > 0);
        if (isTryingToExitMap) return;
        
        Transform.SetPosition(xPos + axis, yPos);
    }

    public bool inMapBounds()
    {
        int xPos = Transform.Position.X;
        int yPos = Transform.Position.Y;

        bool inXBounds = xPos >= 0 && xPos < 20;
        bool inYBounds = yPos >= 0 && yPos < 20;

        return inXBounds && inYBounds;
    }
}