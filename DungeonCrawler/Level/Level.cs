using System.Diagnostics;

namespace DungeonCrawler;

public class Level
{
    public Map Map { get; private set; }
    public Player Player { get; private set; }
    public Enemy[] Enemies { get; private set; } = null!;
    public World World { get; private set; }

    public Level(Map map, Player player)
    {
        Map = map;
        Player = player;

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

    public bool IsPlayerStandingOnDoor(out Actor actor)
    {
        if (WhereIsStanding(Player) is Teleporter t)
        {
            Debug.WriteLine("AAAAAAAAAAAAAAAAAAAA");   
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