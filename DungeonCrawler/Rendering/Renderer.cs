using System.Diagnostics;

namespace DungeonCrawler;

public static class Renderer
{
    public static void RenderDeathScreen()
    {
        Console.WriteLine("YOU DIED");

        string line = DeathScreen.RandomLine();
        Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@##@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#S%SS%%%%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@S%S%?****?%#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@S%S%*+;:,:+%%#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#%%S%?*?++*?%%S@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@S?%*;;**+;;*?#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@S%??**++**?S@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#????**??S@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@???*;;*?@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#?*+?%*++*S@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#SS%+;;;;;;++*SS#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@@@@@@@@@###SS%%%%?****??**?%%%SSS###@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@%%@@@@@@%#@@@@@@@#S%%%%%S%%%%?*+++*%*+*%%%%SSSSSS#@@@@@@@@@#@@@@#S@@@@@@@@@@@@@@@@\n@@@@@@%?S*%@@@@@*+#@@@@@#S%%%%%%%%%%%?;++;;+**?%%%%%%%%SSS#@@@@@@@S?#@@#S@@@@@@@@@@@@@@@@@\n@@@@@@@???*?S@@@%+?@@@@#S%%%%%%%%?%%SS+;;:;+??%%%%%S%SSSSS#@@@@@@#%%@@#S@@@@@@@@@@@@@@@@@@\n@@@@@@@#??**???%%?*%S##SS%%%%%%%%???***;;;++??%%SSSSSSSSSS#@@#SSSSSSS%#@@@@@@@@@@@@@@@@@@@\n@@@@@@@@#%*????%??**%%+SS%%%%#S?%***+*?**+++??%SSSSSS#SSSS#@@S%SS%%S#@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@%???????*?%%?%S%%%S@@SSS*??%%*++++*?SSSSSS@@####S#@#SSSS##@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@#S%??**+?%?S%%%%SS###%S%%%%%?*++*%%%%SSSS##SS##SS#@#######@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@SSS%S%S%%%%%S@##@SSS%SS%%****??%SSSS#@########@@@@@##@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@#SSS%%%S#@@@@###SSSSS%++*SSS####@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@\n@@@@@@@@@@@@@@@@@@@@##SSSSS@@@@@@###SSSS%???S#####@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
        Utilities.Speak(line);
        Debug.WriteLine(line);
        
        //Environment.Exit(0);
    }

    public static void RenderCutscene()
    {
        
    }
    
    // Encounters
    public static void RenderEncounter(Encounter encounter, out int hpLeft, out int hpTop, out int optionsLeft, out int optionsTop)
    {
        // Set variables
        Enemy enemy = encounter.Enemy;
        
        string ascii = enemy.Graphics.SymbolAscii;
        ConsoleColor color = enemy.Graphics.Color;

        // Draw Enemy
        Console.WriteLine($"You encountered {enemy.Name}!\n");
        
        hpTop = Console.GetCursorPosition().Top;
        Console.BackgroundColor = color;

        bool addToLeft = true;
        hpLeft = 1;
        
        foreach (char c in ascii)
        {
            Console.Write(c);
            
            if (c == '\n')
            {
                addToLeft = false;
                hpTop++;
            }
            
            if (addToLeft) hpLeft++;
        }

        hpTop /= 2;
        
        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("\n");

        (optionsLeft, optionsTop) = Console.GetCursorPosition();
    }

    public static void RenderFightOptions(Player player, int cursorLeft, int cursorTop)
    {
        ClearFightOptions(cursorLeft, cursorTop);
        Console.SetCursorPosition(cursorLeft, cursorTop);

        Console.WriteLine(player.CombatOptions);
    }

    public static void RenderInventory(Player player, int cursorLeft, int cursorTop)
    {
        ClearFightOptions(cursorLeft, cursorTop);
        Console.SetCursorPosition(cursorLeft, cursorTop);
        
        Console.WriteLine("0. Back");
        Console.WriteLine(player.Inventory);
    }
    
    public static void RenderMessage(int cursorLeft, int cursorTop, string line)
    {
        ClearFightOptions(cursorLeft, cursorTop);
        Console.SetCursorPosition(cursorLeft, cursorTop);
        
        Console.WriteLine(line);
    }

    public static void ClearFightOptions(int cursorLeft, int cursorTop)
    {
        Console.SetCursorPosition(cursorLeft, cursorTop);

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("                                                                                                                                                             ");
        }
        
        Console.SetCursorPosition(0, 0);
    }
    
    public static void RenderHP(Player player, Enemy enemy, int cursorLeft, int cursorTop)
    {
        Console.SetCursorPosition(cursorLeft, cursorTop);
        Console.Write($"Player HP: {player.HP:0.00}");
        
        Console.SetCursorPosition(cursorLeft, cursorTop + 1);
        Console.Write($"{enemy.Name}'s HP: {enemy.HP:0.00}");
    }

    public static void ClearHP(int cursorLeft, int cursorTop)
    {
        Console.SetCursorPosition(cursorLeft, cursorTop);
        Console.Write("                             ");
        
        Console.SetCursorPosition(cursorLeft, cursorTop + 1);
        Console.Write("                             ");
    }
    
    // Map
    public static void RenderMap(Map map)
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
        PrintMapName(map);
        
        int top = rows + 2;
        Console.SetCursorPosition(0, top);
    }

    static void PrintMapName(Map map)
    {
        int halfNameLength = map.Name.Length / 2;
        if (map.Name.Length % 2 == 0) halfNameLength -= 1;
        
        int left = map.MapArr.GetLength(1) / 2;
        if (left % 2 == 0) left += 1;
        
        Console.SetCursorPosition(left - halfNameLength, 0);
        
        Console.Write(map.Name);
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