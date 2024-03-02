namespace DungeonCrawler;

public class GameManager
{
    public Game CreateGame(int mapSize, Character player, Object[] objects)
    {
        Map map = new Map(mapSize, objects);
        NavMesh navMesh = new NavMesh(map);
        Character[] enemies = Enemies(80, mapSize, navMesh);
        Game game = new Game(map, navMesh, player, enemies);

        return game;
    }

    Character[] Enemies(int length, int mapSize, NavMesh navMesh)
    {
        if (length > 100) length = 100;
        
        Character[] enemies = new Character[length];
        List<Vector2> lol = new List<Vector2>();
        
        for (int i = 0; i < length; i++)
        {
            Vector2 pos = GetRandomPosition(mapSize);
            
            while (IsBlocked(navMesh.Blocked, pos) || IsBlocked(lol.ToArray(), pos)) pos = GetRandomPosition(mapSize);

            lol.Add(pos);

            Character enemy = new Character(pos.X, pos.Y);
            enemies[i] = enemy;
        }
        return enemies;
    }

    Vector2 GetRandomPosition(int mapSize)
    {
        int xPos = Random.Shared.Next(mapSize * 2);
        int yPos = Random.Shared.Next(mapSize);
        
        Vector2 pos = new Vector2(xPos, yPos);
        
        return pos;
    }

    bool IsBlocked(Vector2[] blocked, Vector2 current)
    {
        foreach (Vector2 b in blocked)
        {
            if (current.X == b.X && current.Y == b.Y) return true;
        }

        return false;
    }
    
    public void StartGame(Game game)
    {
        Map map = game.Map;
        Character player = game.Player;
        NavMesh navMesh = game.NavMesh;
        
        while (true)
        {
            Renderer.PrintMap(map, player, game.Enemies);
            Console.WriteLine(game.IsPlayerStandingOnDoor());

            bool isCollidingFromRight = player.IsCollidingFromRight(navMesh);
            bool isCollidingFromLeft = player.isCollidingFromLeft(navMesh);
            bool isCollidingFromTop = player.isCollidingFromTop(navMesh);
            bool isCollidingFromBottom = player.isCollidingFromBottom(navMesh);
            
            ConsoleKeyInfo cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (!isCollidingFromTop) player.MoveUp(-1, map);
                    else Console.Beep(7578, 1);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (!isCollidingFromBottom) player.MoveUp(1, map);
                    else Console.Beep(7578, 1);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (!isCollidingFromRight) player.MoveRight(1, map);
                    else Console.Beep(7578, 1);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (!isCollidingFromLeft) player.MoveRight(-1, map);
                    else Console.Beep(7578, 1);
                    break;
            }
            Console.Clear();
        }
    }
}