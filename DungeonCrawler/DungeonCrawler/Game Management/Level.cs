namespace DungeonCrawler;

public class Level
{
    public Map Map { get; private set; }
    public NavMesh NavMesh { get; private set; } = null!;
    public Pawn Player { get; private set; }
    public Enemy[] Enemies { get; private set; } = null!;

    public Level(Map map, Pawn player)
    {
        Map = map;
        Player = player;
    }

    public Level(Map map, NavMesh navMesh, Pawn player)
    {
        Map = map;
        Player = player;
        NavMesh = navMesh;
    }

    public static Level CreateInstance(Map map, NavMesh navMesh, Pawn player)
    {
        return new Level(map, navMesh, player);
    }

    public void AddEnemies(Enemy[] enemies)
    {
        Enemies = enemies;
    }

    public bool IsPlayerStandingOnDoor()
    {
        return StandingChar() == '.';
    }
    
    char StandingChar()
    {

        return 'a';
        //return Map.MapArr[Player.Transform.Position.Y, Player.Transform.Position.X];
    }
}