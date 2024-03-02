namespace DungeonCrawler;

public class Map
{
    public char[,] MapArr { get; private set; }
    public Object[] Objects { get; private set; }
    private static int _rows;
    private static int _cols;
    
    public Map(int size, Object[] objects)
    {
        MapArr = new char[size, size * 2];
        Objects = objects;
        
        CreateMap();
    }
    
    public Map(int sizeX, int sizeY, Object[] objects)
    {
        MapArr = new char[sizeX, sizeY];
        Objects = objects;
        
        CreateMap();
    }

    // Functions
    void CreateMap()
    {
        _rows = MapArr.GetLength(0);
        _cols = MapArr.GetLength(1);

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                MapArr[i, j] = ' ';
            }
        }

        if (Objects.Length > 0)
        {
            for (int i = 0; i < Objects.Length; i++)
            {
                AddObjects(i);
            }
        }
    }

    void AddObjects(int currentObjectIndex)
    {
        Object currentObject = Objects[currentObjectIndex];

        bool isDoor = currentObject is Door;
        int doorDirection = 1;
        if (isDoor) doorDirection = ((Door)currentObject).Direction;
        
        
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                Vector2 currentPosition = new Vector2(j, i);
                bool isObjectInCurrentPosition = IsObjectInCurrentPosition(currentPosition, currentObject);

                if (isObjectInCurrentPosition)
                {
                    if (isDoor)
                    {
                        int firstX = currentObject.Transform.Position.X + 1;
                        int firstY = currentObject.Transform.Position.Y + 1;

                        if (((Door)currentObject).DoorOrientation == DoorOrientation.Vertical)
                        {
                            if (doorDirection > 0) firstX = currentObject.Transform.Position.X + 1;
                            else firstX = currentObject.Transform.Position.X;
                        }

                        if (((Door)currentObject).DoorOrientation == DoorOrientation.Horizontal)
                        {
                            if (doorDirection < 0) firstY = currentObject.Transform.Position.Y + 1;
                            else firstY = currentObject.Transform.Position.Y;
                        }
                        
                        if (j == firstX && i == firstY) MapArr[i, j] = '.';
                        else MapArr[i, j] = '&';
                    }
                    else
                    MapArr[i, j] = currentObject.Graphics.Symbol;
                }
            }
        }
    }

    bool IsObjectInCurrentPosition(Vector2 position, Object obj)
    {
        Vector2 objectPosition = obj.Transform.Position;
        
        bool inXPosition = (position.X >= objectPosition.X) && (position.X <= objectPosition.X + obj.Transform.Scale.X);
        bool inYPosition = (position.Y >= objectPosition.Y) && (position.Y <= objectPosition.Y + obj.Transform.Scale.Y);
        return inXPosition && inYPosition;
    }
}