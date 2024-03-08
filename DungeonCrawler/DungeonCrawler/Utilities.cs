namespace DungeonCrawler;

public static class Utilities
{
    // Game creation
    public static Level CreateLevel(int mapSize, Pawn player, Actor[] objects)
    {
        Map map = new Map(mapSize, objects);
        NavMesh navMesh = new NavMesh(map);
        Level level = new Level(map, navMesh, player);

        return level;
    }
    public static Level CreateLevel(Vector2 mapSize, Pawn player, Actor[] objects)
    {
        Map map = new Map(mapSize, objects);
        NavMesh navMesh = new NavMesh(map);
        Level level = new Level(map, navMesh, player);

        return level;
    }
    public static Level CreateLevel(int mapSizeX, int mapSizeY, Pawn player, Actor[] objects)
    {
        Map map = new Map(new Vector2(mapSizeX, mapSizeY), objects);
        NavMesh navMesh = new NavMesh(map);
        Level level = new Level(map, navMesh, player);

        return level;
    }
    
    // Enemies stuff
    public static Pawn[] GenerateEnemies(int enemyCount, int mapSize, NavMesh navMesh)
    {
        if (enemyCount > 100) enemyCount = 100;
        
        Pawn[] enemies = new Pawn[enemyCount];
        List<Vector2> takenPositions = new List<Vector2>();
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomPosition(mapSize);
            
            while (IsBlocked(navMesh.Blocked, pos) || IsBlocked(takenPositions.ToArray(), pos)) pos = GetRandomPosition(mapSize);

            takenPositions.Add(pos);

            Pawn enemy = new Pawn(pos.X, pos.Y);
            enemies[i] = enemy;
        }
        return enemies;
    }
    
    public static Enemy[] GenerateEnemies(int enemyPercentage, Vector2 mapSize, NavMesh navMesh)
    {
        int enemyCount = (mapSize.X * mapSize.Y) * enemyPercentage / 100;
        //if (enemyCount > 50) enemyCount = 50;
        
        Enemy[] enemies = new Enemy[enemyCount];
        List<Vector2> takenPositions = new List<Vector2>();
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomPosition(mapSize);
            
            while (IsBlocked(navMesh.Blocked, pos) || IsBlocked(takenPositions.ToArray(), pos)) pos = GetRandomPosition(mapSize);

            takenPositions.Add(pos);

            Enemy enemy = new Enemy(pos.X, pos.Y);
            enemies[i] = enemy;
        }
        return enemies;
    }
    
    public static Enemy[] GenerateEnemies(int enemyPercentage, Vector2 mapSize, NavMesh navMesh, Graphics graphics)
    {
        int enemyCount = (mapSize.X * mapSize.Y) * enemyPercentage / 100;
        if (enemyCount > 50) enemyCount = 50;
        
        Enemy[] enemies = new Enemy[enemyCount];
        List<Vector2> takenPositions = new List<Vector2>();
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomPosition(mapSize);
            
            while (IsBlocked(navMesh.Blocked, pos) || IsBlocked(takenPositions.ToArray(), pos)) pos = GetRandomPosition(mapSize);

            takenPositions.Add(pos);

            Enemy enemy = new Enemy(pos.X, pos.Y, graphics);
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