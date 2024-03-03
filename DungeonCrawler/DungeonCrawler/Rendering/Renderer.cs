namespace DungeonCrawler;

public static class Renderer
{
    public static void PrintMap(Map map, Character player, Character[] enemies)
    {
        char[,] mapArr = map.MapArr;
        Object[] objects = map.Objects;
        
        int rows = map.MapArr.GetLength(0);
        int cols = map.MapArr.GetLength(1);

        Vector2[] enemiesPositions = EnemiesPositions(enemies);
        
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
                bool printedEnemy = false;
                
                Console.BackgroundColor = ConsoleColor.Black;

                if (IsPlayerInPosition(player, i, j))
                {
                    Console.Write('*');
                    continue;
                }
                
                foreach (Vector2 position in enemiesPositions)
                {
                    if (j == position.X && i == position.Y)
                    {
                        Console.Write('@');
                        printedEnemy = true;
                    }
                }

                if (!printedEnemy)
                {
                    if (mapArr[i, j] == '.') Console.Write(' ');
                    else
                    {
                        foreach (Object o in objects)
                        {
                            if (mapArr[i, j] == o.Graphics.Symbol) Console.BackgroundColor = o.Graphics.Color;
                        }
                        Console.Write(mapArr[i, j]);
                    }
                }
            }
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine('|');
            
            if (drawHasEnded) PrintHorizontalBorder(cols);
        }

        Console.WriteLine();
    }
    
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
            
            if (drawHasStarted) PrintHorizontalBorder(cols);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write('|');
            for (int j = 0; j < cols; j++)
            {
                Console.BackgroundColor = ConsoleColor.Black;

                if (IsPlayerInPosition(player, i, j)) Console.Write('*');
                else if (mapArr[i, j] == '.') Console.Write(' ');
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
            
            if (drawHasEnded) PrintHorizontalBorder(cols);
        }

        Console.WriteLine();
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

    static bool IsPlayerInPosition(Character player, int i, int j)
    {
        return (j == player.Transform.Position.X && i == player.Transform.Position.Y);
    }

    static Vector2[] EnemiesPositions(Character[] enemies)
    {
        Vector2[] arr = new Vector2[enemies.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            int x = enemies[i].Transform.Position.X;
            int y = enemies[i].Transform.Position.Y;
            Vector2 pos = new Vector2(x, y);
            arr[i] = pos;
        }

        return arr;
    }
}