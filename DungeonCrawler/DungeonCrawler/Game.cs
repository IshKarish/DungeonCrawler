namespace DungeonCrawler;

public class Game
{
    public Map Map { get; private set; }
    public NavMesh NavMesh { get; private set; }
    public Character Player { get; private set; }

    public Game(Map map, Character player)
    {
        Map = map;
        Player = player;
    }
    public Game(Map map, NavMesh navMesh, Character player)
    {
        Map = map;
        Player = player;
        NavMesh = navMesh;
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