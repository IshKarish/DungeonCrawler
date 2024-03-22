namespace DungeonCrawler;

public class World
{
    public Actor[,] WorldArr { get; private set; }

    public World(Map map)
    {
        WorldArr = new Actor[map.MapArr.GetLength(0), map.MapArr.GetLength(1)];
        
        UpdateWorldArr(map.Actors);
        AddDoors(map);
    }
    
    public void UpdateWorldArr(Actor[] actors)
    {
        foreach (Actor a in actors)
        {
            int startPosX = a.Transform.Position.X;
            int scaleX = a.Transform.Scale.X + 1;

            int startPosY = a.Transform.Position.Y;
            int scaleY = a.Transform.Scale.Y + 1;
        
            for (int i = startPosX; i < startPosX + scaleX; i++)
            {
                for (int j = startPosY; j < startPosY + scaleY; j++)
                {
                    if (j >= WorldArr.GetLength(0)) break;
                    WorldArr[j, i] = a;
                }
            }
        }
    }

    void AddDoors(Map map)
    {
        int rows = map.MapArr.GetLength(0);
        int cols = map.MapArr.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (map.MapArr[i, j] == '.') WorldArr[i, j] = new Teleporter();
            }
        }
    }
}