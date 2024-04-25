using System.Diagnostics;

namespace DungeonCrawler;

public class Map
{
    public string Name { get; private set; }
    
    public char[,] MapArr { get; private set; }
    public Actor[] Actors { get; private set; }
    private static int _rows;
    private static int _cols;
    
    public Map(string name, int size, Actor[] actors)
    {
        Name = name;
        
        MapArr = new char[size, size * 2];
        Actors = new Actor[0];
        CreateMap(actors);
    }
    
    public Map(string name, Vector2 size, Actor[] actors)
    {
        Name = name;
        
        MapArr = new char[size.X, size.Y];
        Actors = new Actor[0];
        CreateMap(actors);
    }
    
    public Map(string name, int size)
    {
        Name = name;
        
        MapArr = new char[size, size * 2];
        Actors = new Actor[0];
        CreateMap();
    }
    
    public Map(string name, Vector2 size)
    {
        Name = name;
        
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

        AddActors(actors);
    }

    public void AddActors(Actor[] actors)
    {
        foreach (Actor a in actors)
        {
            AddActor(a);
        }
    }

    public void AddActor(Actor actor)
    {
        AddToActorArr(actor);
        
        bool isDoor = actor is Door;
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _cols; j++)
            {
                Vector2 currentPosition = new Vector2(j, i);
                bool isObjectInCurrentPosition = IsObjectInCurrentPosition(currentPosition, actor);

                if (isObjectInCurrentPosition)
                {
                    if (isDoor) MapArr[i, j] = '&';
                    else MapArr[i, j] = actor.Graphics.Symbol;
                }
            }
        }
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