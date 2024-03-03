namespace DungeonCrawler;

public class Game
{
    public Map Map { get; private set; }
    public NavMesh NavMesh { get; private set; } = null!;
    public Pawn Player { get; private set; }
    public Pawn[] Enemies { get; private set; } = null!;

    public Game(Map map, Pawn player)
    {
        Map = map;
        Player = player;
    }

    public Game(Map map, NavMesh navMesh, Pawn player)
    {
        Map = map;
        Player = player;
        NavMesh = navMesh;
    }

    public static Game CreateInstance(Map map, NavMesh navMesh, Pawn player)
    {
        return new Game(map, navMesh, player);
    }

    public void AddEnemies(Pawn[] enemies)
    {
        Enemies = enemies;
    }

    public bool IsPlayerStandingOnDoor()
    {
        return StandingChar() == '.';
    }
    
    char StandingChar()
    {
        return Map.MapArr[Player.Transform.Position.Y, Player.Transform.Position.X];
    }
}