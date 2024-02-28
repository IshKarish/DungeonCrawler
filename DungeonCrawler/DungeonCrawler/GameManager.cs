namespace DungeonCrawler;

public class GameManager
{
    public Game CreateGame(int mapSize, Character player, Object[] objects)
    {
        Map map = new Map(mapSize, objects);
        NavMesh navMesh = new NavMesh(map);
        Game game = new Game(map, navMesh, player);

        return game;
    }
    
    public void StartGame(Game game)
    {
        Map map = game.Map;
        Character player = game.Player;
        NavMesh navMesh = game.NavMesh;
        
        while (true)
        {
            game.UpdatePlayerLocation();
            map.PrintMap();

            bool isCollidingFromRight = IsNextXColliding(player, navMesh, 1);
            bool isCollidingFromLeft = IsNextXColliding(player, navMesh, -1);
            bool isCollidingFromTop = IsNextYColliding(player, navMesh, -1);
            bool isCollidingFromBottom = IsNextYColliding(player, navMesh, 1);
            
            ConsoleKeyInfo cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (!isCollidingFromTop) player.MoveUp(-1);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (!isCollidingFromBottom) player.MoveUp(1);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (!isCollidingFromRight) player.MoveRight(1);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (!isCollidingFromLeft) player.MoveRight(-1);
                    break;
            }

            //Console.WriteLine();
            Console.Clear();
        }
    }

    bool IsNextXColliding(Character player, NavMesh navMesh, int direction)
    {
        if (direction > 0) direction = 1;
        else direction = -1;

        int[] yPositions = CorrespondingYPositions(navMesh, player.Transform.Position.X, direction);

        foreach (Vector2 w in navMesh.Walkable)
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

    bool IsNextYColliding(Character player, NavMesh navMesh, int direction)
    {
        if (direction > 0) direction = 1;
        else direction = -1;

        int[] xPositions = CorrespondingXPositions(navMesh, player.Transform.Position.Y, direction);

        foreach (Vector2 w in navMesh.Walkable)
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

    int[] CorrespondingXPositions(NavMesh navMesh, int yPosition, int direction)
    {
        if (direction > 0) direction = 1;
        else direction = -1;
        
        List<int> x = new List<int>();
        
        foreach (Vector2 v in navMesh.Walkable)
        {
            if (v.Y == yPosition + direction) x.Add(v.X);
        }

        return x.ToArray();
    }
    
    int[] CorrespondingYPositions(NavMesh navMesh, int xPosition, int direction)
    {
        if (direction > 0) direction = 1;
        else direction = -1;
        
        List<int> y = new List<int>();
        
        foreach (Vector2 v in navMesh.Walkable)
        {
            if (v.X == xPosition + direction) y.Add(v.Y);
        }

        return y.ToArray();
    }
}