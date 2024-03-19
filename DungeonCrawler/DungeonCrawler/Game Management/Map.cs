using System.Diagnostics;

namespace DungeonCrawler;

public class Map
{
    public char[,] MapArr { get; private set; }
    public Actor[,] WorldArr { get; private set; }
    public Actor[] Actors { get; private set; }
    private static int _rows;
    private static int _cols;
    
    public Map(int size, Actor[] actors)
    {
        MapArr = new char[size, size * 2];
        WorldArr = new Actor[size, size * 2];
        
        Actors = actors;
        
        CreateMap();
    }
    
    public Map(Vector2 size, Actor[] actors)
    {
        MapArr = new char[size.X, size.Y];
        WorldArr = new Actor[size.X, size.Y];
        
        Actors = actors;
        
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

        if (Actors.Length > 0)
        {
            for (int i = 0; i < Actors.Length; i++)
            {
                AddObjects(i);
            }
        }
    }

    void AddObjects(int currentObjectIndex)
    {
        Actor currentActor = Actors[currentObjectIndex];

        bool isDoor = currentActor is Door;
        int doorDirection = 1;
        if (isDoor) doorDirection = ((Door)currentActor).Direction;
        
        
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                Vector2 currentPosition = new Vector2(j, i);
                bool isObjectInCurrentPosition = IsObjectInCurrentPosition(currentPosition, currentActor);

                if (isObjectInCurrentPosition)
                {
                    if (isDoor)
                    {
                        int firstX = currentActor.Transform.Position.X + 1;
                        int firstY = currentActor.Transform.Position.Y + 1;

                        if (((Door)currentActor).DoorOrientation == DoorOrientation.Vertical)
                        {
                            if (doorDirection > 0) firstX = currentActor.Transform.Position.X + 1;
                            else firstX = currentActor.Transform.Position.X;
                        }

                        if (((Door)currentActor).DoorOrientation == DoorOrientation.Horizontal)
                        {
                            if (doorDirection < 0) firstY = currentActor.Transform.Position.Y + 1;
                            else firstY = currentActor.Transform.Position.Y;
                        }
                        
                        if (j == firstX && i == firstY) MapArr[i, j] = '.';
                        else MapArr[i, j] = '&';
                    }
                    else
                        MapArr[i, j] = currentActor.Graphics.Symbol;
                }
            }
        }
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

    bool IsObjectInCurrentPosition(Vector2 position, Actor obj)
    {
        Vector2 objectPosition = obj.Transform.Position;
        
        bool inXPosition = (position.X >= objectPosition.X) && (position.X <= objectPosition.X + obj.Transform.Scale.X);
        bool inYPosition = (position.Y >= objectPosition.Y) && (position.Y <= objectPosition.Y + obj.Transform.Scale.Y);
        return inXPosition && inYPosition;
    }
}