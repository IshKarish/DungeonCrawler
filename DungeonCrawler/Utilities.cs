using System.Diagnostics;
using System.Speech.Synthesis;

namespace DungeonCrawler;

public static class Utilities
{
    // Game creation
    public static Level CreateLevel(int mapSize, Player player, Actor[] objects)
    {
        Map map = new Map(mapSize, objects);
        Level level = new Level(map, player);

        return level;
    }
    public static Level CreateLevel(Vector2 mapSize, Player player, Actor[] objects)
    {
        Map map = new Map(mapSize, objects);
        Level level = new Level(map, player);

        return level;
    }
    public static Level CreateLevel(int mapSizeX, int mapSizeY, Player player, Actor[] objects)
    {
        Map map = new Map(new Vector2(mapSizeX, mapSizeY), objects);
        Level level = new Level(map, player);

        return level;
    }
    
    public static Level CreateLevel(int mapSize, Player player)
    {
        Map map = new Map(mapSize);
        Level level = new Level(map, player);

        return level;
    }
    public static Level CreateLevel(Vector2 mapSize, Player player)
    {
        Map map = new Map(mapSize);
        Level level = new Level(map, player);

        return level;
    }
    public static Level CreateLevel(int mapSizeX, int mapSizeY, Player player)
    {
        Map map = new Map(new Vector2(mapSizeX, mapSizeY));
        Level level = new Level(map, player);

        return level;
    }
    
    // Enemies stuff
    public static Enemy[] GenerateEnemies(int enemyPercentage, Level level)
    {
        level.UpdateWorldArr();
        
        Vector2 mapSize = new Vector2(level.Map.MapArr.GetLength(0), level.Map.MapArr.GetLength(1));
        
        int enemyCount = ((mapSize.X * mapSize.Y) * enemyPercentage / 100) / 20;
        if (enemyCount == 0) enemyCount = 1;
        
        Enemy[] enemies = new Enemy[enemyCount];
        List<Vector2> takenPositions = new List<Vector2>();
        foreach (Vector2 p in level.World.Positions)
        {
            if (p != null) takenPositions.Add(p);
        }
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomVector(mapSize);
            while (IsBlocked(takenPositions.ToArray(), pos)) pos = GetRandomVector(mapSize);
            
            takenPositions.Add(pos);

            Enemy enemy = new Enemy(pos.X, pos.Y);
            enemy.Transform.SetLastTransform(new Transform(new Vector2(pos.X, pos.Y)));
            
            enemies[i] = enemy;
        }
        return enemies;
    }
    
    public static Enemy[] GenerateEnemies(int enemyPercentage, Level level, int sensingRange)
    {
        level.UpdateWorldArr();
        
        Vector2 mapSize = new Vector2(level.Map.MapArr.GetLength(0), level.Map.MapArr.GetLength(1));
        
        int enemyCount = ((mapSize.X * mapSize.Y) * enemyPercentage / 100) / 20;
        if (enemyCount == 0) enemyCount = 1;
        
        Enemy[] enemies = new Enemy[enemyCount];
        List<Vector2> takenPositions = new List<Vector2>();
        foreach (Vector2 p in level.World.Positions)
        {
            if (p != null) takenPositions.Add(p);
        }
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector2 pos = GetRandomVector(mapSize);
            while (IsBlocked(takenPositions.ToArray(), pos)) pos = GetRandomVector(mapSize);

            takenPositions.Add(pos);

            Enemy enemy = new Enemy(pos.X, pos.Y);
            enemy = new Enemy(pos.X, pos.Y, new PawnSensing(sensingRange, enemy));
            enemy.Transform.SetLastTransform(new Transform(new Vector2(pos.X, pos.Y)));
            
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
    
    static bool IsBlocked(Vector2[] blocked, Vector2 current)
    {
        foreach (Vector2 b in blocked)
        {
            if (current.X == b.Y && current.Y == b.X) return true;
        }

        return false;
    }
    
    public static void Speak(string str)
    { 
        SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
    
        _synthesizer.Volume = 100;
        _synthesizer.Rate = 2;
        
        _synthesizer.Speak(str);
    }
}