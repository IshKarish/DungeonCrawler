namespace DungeonCrawler;

public class Game
{
    public Map Map { get; private set; }
    public NavMesh NavMesh { get; private set; }
    public Character Player { get; private set; }
    public Character[] Enemies { get; private set; }

    public Game(Map map, Character player, Character[] enemies)
    {
        Map = map;
        Player = player;
        Enemies = enemies;
    }
    public Game(Map map, NavMesh navMesh, Character player, Character[] enemies)
    {
        Map = map;
        Player = player;
        Enemies = enemies;
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