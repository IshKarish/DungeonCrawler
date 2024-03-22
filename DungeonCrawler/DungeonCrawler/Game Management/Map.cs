using System.Diagnostics;

namespace DungeonCrawler;

public class Map
{
    public char[,] MapArr { get; private set; }
    public Actor[] Actors { get; private set; }
    private static int _rows;
    private static int _cols;
    
    public Map(int size, Actor[] actors)
    {
        MapArr = new char[size, size * 2];
        Actors = new Actor[0];
        CreateMap(actors);
    }
    
    public Map(Vector2 size, Actor[] actors)
    {
        MapArr = new char[size.X, size.Y];
        Actors = new Actor[0];
        CreateMap(actors);
    }
    
    public Map(int size)
    {
        MapArr = new char[size, size * 2];
        Actors = new Actor[0];
        CreateMap();
    }
    
    public Map(Vector2 size)
    {
        MapArr = new char[size.X, size.Y];
        Actors = new Actor[0];
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
    }
    
    void CreateMap(Actor[] actors)
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

        for (int i = 0; i < actors.Length; i++)
        {
            AddActor(actors[i]);
        }
    }

    public void AddActor(Actor actor)
    {
        AddToActorArr(actor);
        
        bool isDoor = actor is Door;
        int doorDirection = 1;
        if (isDoor) doorDirection = ((Door)actor).Direction;
        
        
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                Vector2 currentPosition = new Vector2(j, i);
                bool isObjectInCurrentPosition = IsObjectInCurrentPosition(currentPosition, actor);

                if (isObjectInCurrentPosition)
                {
                    if (isDoor)
                    {
                        int firstX = actor.Transform.Position.X + 1;
                        int firstY = actor.Transform.Position.Y + 1;

                        if (((Door)actor).DoorOrientation == DoorOrientation.Vertical)
                        {
                            if (doorDirection > 0) firstX = actor.Transform.Position.X + 1;
                            else firstX = actor.Transform.Position.X;
                        }

                        if (((Door)actor).DoorOrientation == DoorOrientation.Horizontal)
                        {
                            if (doorDirection < 0) firstY = actor.Transform.Position.Y + 1;
                            else firstY = actor.Transform.Position.Y;
                        }
                        
                        if (j == firstX && i == firstY) MapArr[i, j] = '.';
                        else MapArr[i, j] = '&';
                    }
                    else
                        MapArr[i, j] = actor.Graphics.Symbol;
                }
            }
        }

        Debug.WriteLine(Actors.Length);
    }

    void AddToActorArr(Actor actor)
    {
        Actor[] newArr = new Actor[Actors.Length + 1];
        for (int i = 0; i < Actors.Length; i++)
        {
            newArr[i] = Actors[i];
        }
        newArr[^1] = actor;
        Actors = newArr;
    }

    bool IsObjectInCurrentPosition(Vector2 position, Actor obj)
    {
        Vector2 objectPosition = obj.Transform.Position;
        
        bool inXPosition = (position.X >= objectPosition.X) && (position.X <= objectPosition.X + obj.Transform.Scale.X);
        bool inYPosition = (position.Y >= objectPosition.Y) && (position.Y <= objectPosition.Y + obj.Transform.Scale.Y);
        return inXPosition && inYPosition;
    }
}