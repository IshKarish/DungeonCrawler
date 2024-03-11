namespace DungeonCrawler;

public static class Renderer
{
    public static void PrintMap(Map map)
    {
        char[,] mapArr = map.MapArr;
        Actor[] objects = map.Actors;
        
        int rows = map.MapArr.GetLength(0);
        int cols = map.MapArr.GetLength(1);
        
        for (int i = 0; i < rows; i++)
        {
            // States
            bool drawHasStarted = i == 0;
            bool drawHasEnded = i == rows - 1;
            
            if (drawHasStarted) PrintHorizontalBorder(cols);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write('|');
            for (int j = 0; j < cols; j++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                
                if (mapArr[i, j] == '.') Console.Write(' ');
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
            
            if (drawHasEnded) PrintHorizontalBorder(cols);
        }

        Console.WriteLine();
    }
    
    public static void ClearPawnPosition(Pawn pawn)
    {
        Console.SetCursorPosition(pawn.Transform.Position.X + 1, pawn.Transform.Position.Y + 1);
    }
    
    public static void ClearPawnPosition(Vector2 position)
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
    }

    public static void UpdatePawnPosition(Pawn pawn)
    {
        Console.SetCursorPosition(pawn.Transform.Position.X, pawn.Transform.Position.Y + 1);
        
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(' ');
        Console.SetCursorPosition(pawn.Transform.Position.X + 1, pawn.Transform.Position.Y + 1);
        
        Console.BackgroundColor = pawn.Graphics.Color;
        Console.Write(pawn.Graphics.Symbol);
        
        Console.SetCursorPosition(pawn.Transform.Position.X + 1, pawn.Transform.Position.Y + 1);
        Console.BackgroundColor = ConsoleColor.Black;
    }

    static void PrintHorizontalBorder(int cols)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        
        for (int i = 0; i < cols + 2; i++)
        {
            Console.Write('-');
        }
        Console.WriteLine();
    }
}