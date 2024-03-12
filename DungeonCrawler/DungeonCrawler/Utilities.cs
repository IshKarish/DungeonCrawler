using System.Diagnostics;

namespace DungeonCrawler;

public static class Utilities
{
    // Level creation
    public static Level CreateLevel(Map map)
    {
        Level level = new Level(map, new NavMesh(map));

        return level;
    }

    public static Level CreateRandomLevel(Vector2 mapSize, int actorsPercentage, int enemyPercentage)
    {
        Map map = new Map(mapSize);
        
        // Actors generation
        Graphics objGraphics = new Graphics('/', ConsoleColor.Blue);
        Actor[] actors = GenerateActors(actorsPercentage, map, objGraphics);
        
        NavMesh navMesh = new NavMesh(map);
        map.AddActors(actors);

        Door dorBenDor = new Door(97, 0, DoorOrientation.Horizontal, -1);
        Door[] doors = GenerateDoors(5, map, navMesh);
        map.AddActors(doors);
        
        Level level = CreateLevel(map);
        
        // Enemies Generation
        if (enemyPercentage > 0)
        {
            Enemy[] enemies = GenerateEnemies(enemyPercentage, map, level.NavMesh);
            level.AddEnemies(enemies);
        }
        
        return level;
    }
    
    
    // Enemies stuff
    public static Enemy[] GenerateEnemies(int enemyPercentage, Map map, NavMesh navMesh)
    {
        Vector2 mapSize = new Vector2(map.MapArr.GetLength(0), map.MapArr.GetLength(1));
        
        int enemyCount = ((mapSize.X * mapSize.Y) * enemyPercentage / 100) / 20;
        if (enemyCount == 0) enemyCount = 1;
        
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
        
        int actorCount = ((mapSize.X * mapSize.Y) * actorsPercentage / 100) / 20;
        if (actorCount == 0) actorCount = 1;

        Actor[] actors = new Actor[actorCount];
        
        for (int i = 0; i < actorCount; i++)
        {
            Vector2 pos = GetRandomVector(mapSize);
            Vector2 size = GetRandomVector(5);

            while (pos.X <= 4 || pos.X >= mapSize.Y - 7)
            {
                pos = GetRandomVector(mapSize);
            }

            Actor actor = new Actor(pos, size, graphics);
            actors[i] = actor;
        }

        return actors;
    }
    
    public static Actor[] GenerateActors(int actorsPercentage, Map map, Graphics graphics, int sizeLimit)
    {
        Vector2 mapSize = new Vector2(map.MapArr.GetLength(0), map.MapArr.GetLength(1));
        
        int actorCount = ((mapSize.X * mapSize.Y) * actorsPercentage / 100) / 20;
        if (actorCount == 0) actorCount = 1;

        Actor[] actors = new Actor[actorCount];
        
        for (int i = 0; i < actorCount; i++)
        {
            Vector2 pos = GetRandomVector(mapSize);
            Vector2 size = GetRandomVector(sizeLimit);
            
            while (pos.X <= 4 || pos.X >= mapSize.Y - 7)
            {
                pos = GetRandomVector(mapSize);
            }

            Actor actor = new Actor(pos, size, graphics);
            actors[i] = actor;
        }

        return actors;
    }
    
    public static Actor[] GenerateActors(int actorsPercentage, Map map, Graphics graphics, Vector2 sizeLimit)
    {
        Vector2 mapSize = new Vector2(map.MapArr.GetLength(0), map.MapArr.GetLength(1));
        
        int actorCount = ((mapSize.X * mapSize.Y) * actorsPercentage / 100) / 20;
        if (actorCount == 0) actorCount = 1;

        Actor[] actors = new Actor[actorCount];
        
        for (int i = 0; i < actorCount; i++)
        {
            Vector2 pos = GetRandomVector(mapSize);
            Vector2 size = GetRandomVector(sizeLimit);
            
            while (pos.X <= 4 || pos.X >= mapSize.Y - 7)
            {
                pos = GetRandomVector(mapSize);
            }

            Actor actor = new Actor(pos, size, graphics);
            actors[i] = actor;
        }

        return actors;
    }
    
    // Doors stuff
    public static Door[] GenerateDoors(int doorsCount, Map map, NavMesh navMesh)
    {
        Vector2 mapSize = new Vector2(map.MapArr.GetLength(0), map.MapArr.GetLength(1));
        
        Door[] enemies = new Door[doorsCount];
        List<Vector2> takenPositions = new List<Vector2>();
        
        for (int i = 0; i < doorsCount; i++)
        {
            Vector2 pos = new Vector2(0 ,GetRandomVector(mapSize.X).Y);
            
            while (IsBlocked(navMesh.Blocked, pos) || IsBlocked(takenPositions.ToArray(), pos)) pos = GetRandomVector(mapSize);
    
            takenPositions.Add(pos);
    
            Door enemy = new Door(pos.X, pos.Y, DoorOrientation.Vertical, -1);
            enemies[i] = enemy;
        }
        return enemies;
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

    static bool DoorSafe(Vector2[] blocked, Vector2 current)
    {
        foreach (Vector2 b in blocked)
        {
            
        }

        return false;
    }
}