namespace DungeonCrawler;

public class World
{
    public Actor[,] WorldArr { get; private set; }
    public Vector2[] Positions { get; private set; }
    
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
        
        UpdatePositionsArr();
    }

    public void RemoveActor(Actor a)
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
                WorldArr[j, i] = null!;
            }
        }
        
        UpdatePositionsArr();
    }

    public void UpdateActor(Actor a)
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
        
        UpdatePositionsArr();
    }

    public void AddDoors(Map map)
    {
        int rows = map.MapArr.GetLength(0);
        int cols = map.MapArr.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (WorldArr[i, j] is Door d)
                {
                    Vector2 entry = d.Entry;
                    WorldArr[entry.Y, entry.X] = d.Teleporter;
                }
            }
        }
        
        UpdatePositionsArr();
    }

    public void UpdatePositionsArr()
    {
        List<Vector2> blocked = new List<Vector2>();

        foreach (Actor a in WorldArr)
        {
            if (a == null) continue;
            blocked.Add(a.Transform.Position);
        }

        Positions = blocked.ToArray();
    }
}