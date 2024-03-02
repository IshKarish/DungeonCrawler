namespace DungeonCrawler;

public static class Utilities
{
    // Game creation
    public static Game CreateGame(int mapSize, Character player, Object[] objects)
    {
        Map map = new Map(mapSize, objects);
        NavMesh navMesh = new NavMesh(map);
        Game game = new Game(map, navMesh, player);

        return game;
    }
    public static Game CreateGame(Vector2 mapSize, Character player, Object[] objects)
    {
        Map map = new Map(mapSize, objects);
        NavMesh navMesh = new NavMesh(map);
        Game game = new Game(map, navMesh, player);

        return game;
    }
    public static Game CreateGame(int mapSizeX, int mapSizeY, Character player, Object[] objects)
    {
        Map map = new Map(new Vector2(mapSizeX, mapSizeY), objects);
        NavMesh navMesh = new NavMesh(map);
        Game game = new Game(map, navMesh, player);

        return game;
    }
    
    // Enemies stuff
    public static Character[] GenerateEnemies(int enemyCount, int mapSize, NavMesh navMesh)
    {
        if (enemyCount > 100) enemyCount = 100;
        
        Character[] enemies = new Character[enemyCount];
        List<Vector2> takenPositions = new List<Vector2>();
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomPosition(mapSize);
            
            while (IsBlocked(navMesh.Blocked, pos) || IsBlocked(takenPositions.ToArray(), pos)) pos = GetRandomPosition(mapSize);

            takenPositions.Add(pos);

            Character enemy = new Character(pos.X, pos.Y);
            enemies[i] = enemy;
        }
        return enemies;
    }
    
    public static Character[] GenerateEnemies(int enemyCount, Vector2 mapSize, NavMesh navMesh)
    {
        if (enemyCount > 100) enemyCount = 100;
        
        Character[] enemies = new Character[enemyCount];
        List<Vector2> takenPositions = new List<Vector2>();
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomPosition(mapSize);
            
            while (IsBlocked(navMesh.Blocked, pos) || IsBlocked(takenPositions.ToArray(), pos)) pos = GetRandomPosition(mapSize);

            takenPositions.Add(pos);

            Character enemy = new Character(pos.X, pos.Y);
            enemies[i] = enemy;
        }
        return enemies;
    }
    
    static Vector2 GetRandomPosition(int mapSize)
    {
        int xPos = Random.Shared.Next(mapSize * 2);
        int yPos = Random.Shared.Next(mapSize);
        
        Vector2 pos = new Vector2(xPos, yPos);
        
        return pos;
    }
    
    static Vector2 GetRandomPosition(Vector2 mapSize)
    {
        int xPos = Random.Shared.Next(mapSize.X);
        int yPos = Random.Shared.Next(mapSize.Y);

        Vector2 pos = new Vector2(yPos, xPos);
        
        return pos;
    }
    
    static bool IsBlocked(Vector2[] blocked, Vector2 current)
    {
        foreach (Vector2 b in blocked)
        {
            if (current.X == b.X && current.Y == b.Y) return true;
        }

        return false;
    }
}