using System.Diagnostics;

namespace DungeonCrawler;

public static class Renderer
{
    public static void PrintMap(Map map)
    {
        Console.SetCursorPosition(0, 0);
        Console.Clear();
        
        int rows = map.MapArr.GetLength(0);
        
        for (int i = 0; i < rows; i++)
        {
            // States
            bool drawHasStarted = i == 0;
            bool drawHasEnded = i == rows - 1;
            
            if (drawHasStarted) PrintHorizontalBorder(map);
            PrintColumn(map, i);
            if (drawHasEnded) PrintHorizontalBorder(map);
        }

        Console.WriteLine();
    }

    static void PrintColumn(Map map, int i)
    {
        char[,] mapArr = map.MapArr;
        Actor[] objects = map.Actors;
        
        int cols = map.MapArr.GetLength(1);
        
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write('|');
        for (int j = 0; j < cols; j++)
        {
            Console.BackgroundColor = ConsoleColor.Black;
                
            if (mapArr[i, j] == 'D') Console.Write(' ');
            else
            {
                foreach (Actor o in objects)
                {
                    if (mapArr[i, j] == o.Graphics.Symbol) Console.BackgroundColor = o.Graphics.Color;
                }
                Console.Write(mapArr[i, j]);
            }
        }
            
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine('|');
    }
    
    static void PrintHorizontalBorder(Map map)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        
        int cols = map.MapArr.GetLength(1);
        for (int i = 0; i < cols + 2; i++)
        {
            Console.Write('-');
        }
        Console.WriteLine();
    }
    
    public static void ClearPosition(Vector2 position)
    {
        Console.SetCursorPosition(position.X + 1, position.Y + 1);
    }

    public static void PrintPawnPosition(Pawn pawn)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(' ');
        
        Console.SetCursorPosition(pawn.Transform.Position.X + 1, pawn.Transform.Position.Y + 1);
        Console.BackgroundColor = pawn.Graphics.Color;
        Console.Write(pawn.Graphics.Symbol);
        
        Console.SetCursorPosition(0, 0);
    }

    public static void RetractTrap(Trap trap)
    {
        trap.Trigger = false;
        
        Console.SetCursorPosition(trap.Transform.Position.X + 1, trap.Transform.Position.Y + 1);
        Console.BackgroundColor = ConsoleColor.Black;

        if (trap.Direction == TrapDirection.Right)
        {
            int xPos = trap.Transform.Position.X + 1;
            Console.SetCursorPosition(xPos, trap.Transform.Position.Y + 1);

            Console.Write('<');
            for (int i = 0; i < trap.Transform.Scale.X; i++)
            {
                Console.Write('-');
            }
        }
        else
        {
            for (int i = 0; i < trap.Transform.Scale.X; i++)
            {
                Console.Write('-');
            }
            Console.Write('>');
        }
    }

    public static void OpenDoor(Door door)
    {
        door.Open();
        
        Console.SetCursorPosition(door.Entry.X + 1, door.Entry.Y + 1);
        Console.BackgroundColor = ConsoleColor.Black;

        Console.Write(' ');
    }
}