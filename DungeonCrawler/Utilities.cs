using System.Speech.Synthesis;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Multimedia;

namespace DungeonCrawler;

public static class Utilities
{
    // Game creation
    public static Level CreateLevel(string name, int mapSize, Player player, Actor[] objects)
    {
        Map map = new Map(name, mapSize, objects);
        Level level = new Level(map, player);

        return level;
    }
    public static Level CreateLevel(string name, Vector2 mapSize, Player player, Actor[] objects)
    {
        Map map = new Map(name, new Vector2(mapSize.Y, mapSize.X), objects);
        Level level = new Level(map, player);

        return level;
    }
    public static Level CreateLevel(string name, int mapSizeX, int mapSizeY, Player player, Actor[] objects)
    {
        Map map = new Map(name, new Vector2(mapSizeY, mapSizeX), objects);
        Level level = new Level(map, player);

        return level;
    }
    
    public static Level CreateLevel(string name, int mapSize, Player player, Vector2 startPosition)
    {
        Map map = new Map(name, mapSize);
        Level level = new Level(map, player, startPosition);

        return level;
    }
    public static Level CreateLevel(string name, Vector2 mapSize, Player player, Vector2 startPosition)
    {
        Map map = new Map(name, new Vector2(mapSize.Y, mapSize.X));
        Level level = new Level(map, player, startPosition);

        return level;
    }
    public static Level CreateLevel(string name, int mapSizeX, int mapSizeY, Player player, Vector2 startPosition)
    {
        Map map = new Map(name, new Vector2(mapSizeY, mapSizeX));
        Level level = new Level(map, player, startPosition);

        return level;
    }
    
    public static Level CreateLevel(string name, int mapSize, Player player, Actor[] objects, Vector2 startPosition)
    {
        Map map = new Map(name, mapSize, objects);
        Level level = new Level(map, player, startPosition);

        return level;
    }
    public static Level CreateLevel(string name, Vector2 mapSize, Player player, Actor[] objects, Vector2 startPosition)
    {
        Map map = new Map(name, new Vector2(mapSize.Y, mapSize.X), objects);
        Level level = new Level(map, player, startPosition);

        return level;
    }
    public static Level CreateLevel(string name, int mapSizeX, int mapSizeY, Player player, Actor[] objects, Vector2 startPosition)
    {
        Map map = new Map(name, new Vector2(mapSizeY, mapSizeX), objects);
        Level level = new Level(map, player, startPosition);

        return level;
    }
    
    public static Level CreateLevel(string name, int mapSize, Player player)
    {
        Map map = new Map(name, mapSize);
        Level level = new Level(map, player);

        return level;
    }
    public static Level CreateLevel(string name, Vector2 mapSize, Player player)
    {
        Map map = new Map(name, new Vector2(mapSize.Y, mapSize.X));
        Level level = new Level(map, player);

        return level;
    }
    public static Level CreateLevel(string name, int mapSizeX, int mapSizeY, Player player)
    {
        Map map = new Map(name, new Vector2(mapSizeY, mapSizeX));
        Level level = new Level(map, player);

        return level;
    }
    
    // Enemies stuff
    public static Enemy[] GenerateEnemies(int enemyPercentage, Level level, string name = "Bob")
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

            Enemy enemy = new Enemy(pos.X, pos.Y, name);
            enemy.Transform.SetLastTransform(new Transform(new Vector2(pos.X, pos.Y)));
            
            enemies[i] = enemy;
        }
        return enemies;
    }
    
    public static Enemy[] GenerateEnemies(int enemyPercentage, Level level, int sensingRange, string name = "Bob")
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
            enemy = new Enemy(pos.X, pos.Y, new PawnSensing(sensingRange, enemy), name);
            enemy.Transform.SetLastTransform(new Transform(new Vector2(pos.X, pos.Y)));
            
            enemies[i] = enemy;
        }
        return enemies;
    }

    public static Enemy GenerateEnemy(Level level, int sensingRange, string name = "Bob")
    {
        return GenerateEnemies(1, level, sensingRange, name)[0];
    }
    
    public static Enemy GenerateEnemy(Level level, string name = "Bob")
    {
        return GenerateEnemies(1, level, name)[0];
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
    
    public static void Speak(string str, string voice = "Microsoft David Desktop", int volume = 100)
    { 
        SpeechSynthesizer _synthesizer = new SpeechSynthesizer();
    
        _synthesizer.Volume = volume;
        _synthesizer.Rate = 0;
        if (voice == "Microsoft David Desktop") _synthesizer.Rate = 2;
        _synthesizer.SelectVoice(voice);
        
        _synthesizer.Speak(str);
    }

    public static Playback PlayMidi(string path)
    {
        var midiFile = MidiFile.Read(path);

        OutputDevice outputDevice = OutputDevice.GetByIndex(0);
        Playback playback = midiFile.GetPlayback(outputDevice);
        
        return playback;
    }
}