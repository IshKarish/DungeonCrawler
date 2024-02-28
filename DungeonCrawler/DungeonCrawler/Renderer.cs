namespace DungeonCrawler;

public static class Renderer
{
    public static void PrintMap(Map map, Character player)
    {
        char[,] mapArr = map.MapArr;
        Object[] objects = map.Objects;
        
        int rows = map.MapArr.GetLength(0);
        int cols = map.MapArr.GetLength(1);
        
        for (int i = 0; i < rows; i++)
        {
            // States
            bool drawHasStarted = i == 0;
            bool drawHasEnded = i == rows - 1;
            
            if (drawHasStarted) PrintHorizontalBorder(rows, cols);
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write('|');
            for (int j = 0; j < cols; j++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                if (IsPlayerInPosition(player, i, j)) Console.Write('*');
                else
                {
                    foreach (Object o in objects)
                    {
                        if (mapArr[i, j] == o.Graphics.Symbol) Console.BackgroundColor = o.Graphics.Color;
                    }
                    Console.Write(mapArr[i, j]);
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine('|');
            
            if (drawHasEnded) PrintHorizontalBorder(rows, cols);
        }

        Console.WriteLine();
    }
    
    static void PrintHorizontalBorder(int _rows, int _cols)
    {
        Console.BackgroundColor = ConsoleColor.Black;
        
        for (int i = 0; i < _cols + 2; i++)
        {
            Console.Write('-');
        }
        Console.WriteLine();
    }

    static bool IsPlayerInPosition(Character player, int i, int j)
    {
        return (j == player.Transform.Position.X && i == player.Transform.Position.Y);
    }
}