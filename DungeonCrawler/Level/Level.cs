namespace DungeonCrawler;

public class Level
{
    public Map Map { get; private set; }
    public Player Player { get; private set; }
    public Enemy[] Enemies { get; private set; } = null!;
    public World World { get; private set; }

    public Vector2 StartPosition { get; private set; }
    
    public Level() {}

    public Level(Map map, Player player)
    {
        Map = map;
        Player = player;

        World = new World(map);
    }
    
    public Level(Map map, Player player, Vector2 startPosition)
    {
        Map = map;
        Player = player;
        StartPosition = startPosition;

        World = new World(map);
    }

    public void SetEnemies(Enemy[] enemies)
    {
        Enemies = enemies;
    }
    
    public void UpdateWorldArr()
    {
        World.UpdateWorldArr(Map.Actors);
        World.AddDoors(Map);
    }

    public void SetEntrance(Level previousLevel)
    {
        if (previousLevel != null && previousLevel.Map != null)
        {
            previousLevel.UpdateWorldArr();
            
            
            foreach (Actor a in Map.Actors)
            {
                if (a is Door d && d.IsEntrance)
                {
                    d.SetDestination(previousLevel);
                }
            }
        }
    }

    public bool IsPlayerStandingOnDoor(out Actor actor)
    {
        if (WhereIsStanding(Player) is Teleporter t)
        {
            actor = t;
            return true;
        }

        actor = new Actor();
        return false;
    }
    
    Actor WhereIsStanding(Pawn pawn)
    {
        return World.WorldArr[pawn.Transform.Position.Y, pawn.Transform.Position.X];
    }
}