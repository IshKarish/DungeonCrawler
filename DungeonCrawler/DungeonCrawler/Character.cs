namespace DungeonCrawler;

public class Character
{
    public Transform Transform { get; private set; }

    public Character()
    {
        Transform = new Transform();
    }

    public void MoveUp(int axis)
    {
        int xPos = Transform.Position.X;
        int yPos = Transform.Position.Y;
        
        Transform.SetPosition(xPos, yPos + axis);
    }

    public void MoveRight(int axis)
    {
        int xPos = Transform.Position.X;
        int yPos = Transform.Position.Y;
        
        Transform.SetPosition(xPos + axis, yPos);
    }
}