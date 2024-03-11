namespace DungeonCrawler;

public static class Utilities
{
    // Level creation
    public static Level CreateLevel(int mapSize)
    {
        Map map = new Map(mapSize);
        NavMesh navMesh = new NavMesh(map);
        Level level = new Level(map, navMesh);

        return level;
    }
    public static Level CreateLevel(Vector2 mapSize)
    {
        Map map = new Map(mapSize);
        NavMesh navMesh = new NavMesh(map);
        Level level = new Level(map, navMesh);

        return level;
    }
    public static Level CreateLevel(int mapSizeX, int mapSizeY)
    {
        Map map = new Map(new Vector2(mapSizeX, mapSizeY));
        NavMesh navMesh = new NavMesh(map);
        Level level = new Level(map, navMesh);

        return level;
    }
    
    
    // Enemies stuff
    public static Enemy[] GenerateEnemies(int enemyPercentage, Map map, NavMesh navMesh)
    {
        Vector2 mapSize = new Vector2(map.MapArr.GetLength(0), map.MapArr.GetLength(1));
        
        int enemyCount = (mapSize.X * mapSize.Y) * enemyPercentage / 100;
        
        Enemy[] enemies = new Enemy[enemyCount];
        List<Vector2> takenPositions = new List<Vector2>();
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomVector(mapSize);
            
            while (IsBlocked(navMesh.Blocked, pos) || IsBlocked(takenPositions.ToArray(), pos)) pos = GetRandomVector(mapSize);

            takenPositions.Add(pos);

            Enemy enemy = new Enemy(pos.X, pos.Y);
            enemies[i] = enemy;
        }
        return enemies;
    }
    
    
    // Actors stuff
    public static Actor[] GenerateActors(int actorsPercentage, Map map, Graphics graphics)
    {
        Vector2 mapSize = new Vector2(map.MapArr.GetLength(0), map.MapArr.GetLength(1));
        
        int enemyCount = (mapSize.X * mapSize.Y) * actorsPercentage / 100;

        Actor[] actors = new Actor[enemyCount];
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomVector(mapSize);
            Vector2 size = GetRandomVector(5);

            Actor actor = new Actor(pos, size, graphics);
            actors[i] = actor;
        }

        return actors;
    }
    
    public static Actor[] GenerateActors(int actorsPercentage, Map map, Graphics graphics, int sizeLimit)
    {
        Vector2 mapSize = new Vector2(map.MapArr.GetLength(0), map.MapArr.GetLength(1));
        
        int enemyCount = (mapSize.X * mapSize.Y) * actorsPercentage / 100;

        Actor[] actors = new Actor[enemyCount];
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomVector(mapSize);
            Vector2 size = GetRandomVector(sizeLimit);

            Actor actor = new Actor(pos, size, graphics);
            actors[i] = actor;
        }

        return actors;
    }
    
    public static Actor[] GenerateActors(int actorsPercentage, Map map, Graphics graphics, Vector2 sizeLimit)
    {
        Vector2 mapSize = new Vector2(map.MapArr.GetLength(0), map.MapArr.GetLength(1));
        
        int enemyCount = (mapSize.X * mapSize.Y) * actorsPercentage / 100;

        Actor[] actors = new Actor[enemyCount];
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomVector(mapSize);
            Vector2 size = GetRandomVector(sizeLimit);

            Actor actor = new Actor(pos, size, graphics);
            actors[i] = actor;
        }

        return actors;
    }
    
    
    // Other stuff
    static Vector2 GetRandomVector(Vector2 limit)
    {
        int xPos = Random.Shared.Next(limit.X);
        int yPos = Random.Shared.Next(limit.Y);

        Vector2 pos = new Vector2(yPos, xPos);
        
        return pos;
    }

    static Vector2 GetRandomVector(int limit)
    {
        int xPos = Random.Shared.Next(limit);
        int yPos = Random.Shared.Next(limit);

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