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
    
    public void UpdatePlayerLocation()
    {
        RemovePlayerFromMap();
        
        int playerX = Player.Transform.Position.X;
        int playerY = Player.Transform.Position.Y;

        Map.MapArr[playerY, playerX] = '*';
    }
    
    void RemovePlayerFromMap()
    {
        for (int i = 0; i < Map.MapArr.GetLength(0); i++)
        {
            for (int j = 0; j < Map.MapArr.GetLength(1); j++)
            {
                if (Map.MapArr[j, i] == '*') Map.MapArr[j, i] = ' ';
            }
        }
    }
}