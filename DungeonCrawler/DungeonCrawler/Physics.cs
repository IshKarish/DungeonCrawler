namespace DungeonCrawler;

public static class Physics
{
    public static bool IsNextXColliding(Character player, NavMesh navMesh, int direction)
    {
        if (direction > 0) direction = 1;
        else direction = -1;

        int[] yPositions = CorrespondingYPositions(navMesh, player.Transform.Position.X, direction);

        foreach (Vector2 w in navMesh.Blocked)
        {
            bool isNextXColliding = player.Transform.Position.X + direction == w.X;
            if (isNextXColliding)
            {
                foreach (int y in yPositions)
                {
                    if (player.Transform.Position.Y == y) return true;
                }
            }
        }
        
        return false;
    }

    public static bool IsNextYColliding(Character player, NavMesh navMesh, int direction)
    {
        if (direction > 0) direction = 1;
        else direction = -1;

        int[] xPositions = CorrespondingXPositions(navMesh, player.Transform.Position.Y, direction);

        foreach (Vector2 w in navMesh.Blocked)
        {
            bool isNextXColliding = player.Transform.Position.Y + direction == w.Y;
            if (isNextXColliding)
            {
                foreach (int x in xPositions)
                {
                    if (player.Transform.Position.X == x) return true;
                }
            }
        }
        
        return false;
    }

    static int[] CorrespondingXPositions(NavMesh navMesh, int yPosition, int direction)
    {
        if (direction > 0) direction = 1;
        else direction = -1;
        
        List<int> x = new List<int>();
        
        foreach (Vector2 v in navMesh.Blocked)
        {
            if (v.Y == yPosition + direction) x.Add(v.X);
        }

        return x.ToArray();
    }
    
    static int[] CorrespondingYPositions(NavMesh navMesh, int xPosition, int direction)
    {
        if (direction > 0) direction = 1;
        else direction = -1;
        
        List<int> y = new List<int>();
        
        foreach (Vector2 v in navMesh.Blocked)
        {
            if (v.X == xPosition + direction) y.Add(v.Y);
        }

        return y.ToArray();
    }
}