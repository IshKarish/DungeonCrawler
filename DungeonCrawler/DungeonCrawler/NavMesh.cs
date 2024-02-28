namespace DungeonCrawler;

public class NavMesh
{
    public Vector2[] Blocked { get; private set; }

    public NavMesh(Map map)
    {
        Blocked = CreateNavMesh(map);
    }

    Vector2[] CreateNavMesh(Map map)
    {
        List<Vector2> blocked = new List<Vector2>();

        char[,] mapArr = map.MapArr;
        int rows = mapArr.GetLength(0);
        int cols = mapArr.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (mapArr[j, i] != ' ' && mapArr[j, i] != '*' && mapArr[j, i] != '.')
                {
                    Vector2 position = new Vector2(i, j);
                    blocked.Add(position);
                }
            }
        }

        return blocked.ToArray();
    }
}