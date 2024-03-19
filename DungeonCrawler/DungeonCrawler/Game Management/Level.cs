namespace DungeonCrawler;

public class Level
{
    public Map Map { get; private set; }
    public NavMesh NavMesh { get; private set; } = null!;
    
    public Pawn Player { get; private set; }
    public Enemy[] Enemies { get; private set; } = null!;
    
    public World World { get; private set; }

    public Level(Map map, Pawn player)
    {
        Map = map;
        Player = player;

        World = new World(map);
    }

    public Level(Map map, NavMesh navMesh, Pawn player)
    {
        Map = map;
        Player = player;
        NavMesh = navMesh;
        
        World = new World(map);
    }

    public void SetEnemies(Enemy[] enemies)
    {
        Enemies = enemies;
    }

    public bool IsPlayerStandingOnDoor()
    {
        return WhereIsStanding(Player) == '.';
    }
    
    char WhereIsStanding(Pawn pawn)
    {
        return Map.MapArr[pawn.Transform.Position.Y, pawn.Transform.Position.X];
    }
}