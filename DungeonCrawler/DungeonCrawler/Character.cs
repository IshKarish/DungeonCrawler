namespace DungeonCrawler;

public class Character
{
    public Transform Transform { get; private set; }

    public Character()
    {
        Transform = new Transform();
    }

    public Character(int x, int y)
    {
        Transform = new Transform(new Vector2(x, y));
    }
    
    public void MoveUp(int axis, Map map)
    {
        int xPos = Transform.Position.X;
        int yPos = Transform.Position.Y;

        int lastPos = map.MapArr.GetLength(0) - 1;

        bool isTryingToExitMap = (yPos == 0 && axis < 0) || (yPos == lastPos && axis > 0);
        if (isTryingToExitMap) return;
        
        Transform.SetPosition(xPos, yPos + axis);
        Console.Beep(500, 100);
    }

    public void MoveRight(int axis, Map map)
    {
        int xPos = Transform.Position.X;
        int yPos = Transform.Position.Y;
        
        int lastPos = map.MapArr.GetLength(1) - 1;

        bool isTryingToExitMap = (xPos == 0 && axis < 0) || (xPos == lastPos && axis > 0);
        if (isTryingToExitMap) return;
        
        Transform.SetPosition(xPos + axis, yPos);
        Console.Beep(500, 100);
    }

    // Colliding states
    public bool IsCollidingFromRight(NavMesh navMesh)
    {
        return Physics.IsNextXColliding(this, navMesh, 1);
    }

    public bool isCollidingFromLeft(NavMesh navMesh)
    {
        return Physics.IsNextXColliding(this, navMesh, -1);
    }

    public bool isCollidingFromTop(NavMesh navMesh)
    {
        return Physics.IsNextYColliding(this, navMesh, -1);
    }

    public bool isCollidingFromBottom(NavMesh navMesh)
    {
        return Physics.IsNextYColliding(this, navMesh, 1);
    }
}