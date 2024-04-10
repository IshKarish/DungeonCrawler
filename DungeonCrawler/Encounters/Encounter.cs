using System.Diagnostics;

namespace DungeonCrawler;

public class Encounter
{
    public Enemy Enemy { get; private set; }
    public Player Player { get; private set; }
    
    public bool IsUsing { get; private set; }

    private int _optionsLeft;
    private int _optionsTop;
    private int _hpLeft;
    private int _hpTop;

    public Encounter(Enemy enemy, Player player)
    {
        Enemy = enemy;
        Player = player;
    }
    
    public void SetScreenValues(int optionsLeft, int optionsTop, int hpLeft, int hpTop)
    {
        _optionsLeft = optionsLeft;
        _optionsTop = optionsTop;
        _hpLeft = hpLeft;
        _hpTop = hpTop;
    }
    
    public void Act(ConsoleKey input)
    {
        switch (input)
        {
            case ConsoleKey.D1:
                Player.Slap(Enemy, out int damage);
                
                ClearInfo();
                DisplayInfo("slapped", Player, damage);
                DisplayInfo("", Enemy);
                
                break;
            case ConsoleKey.D2:
                break;
            case ConsoleKey.D3:
                IsUsing = true;
                
                Renderer.ClearFightOptions(_optionsLeft, _optionsTop);
                Renderer.RenderFightOptions(Player, _optionsLeft, _optionsTop, true);
                
                return;
            case ConsoleKey.D4:
                break;
            default:
                Debug.WriteLine($"{Enemy.Name} hit you");
                break;
        }
    }

    public void Use(ConsoleKey input)
    {
        string choice = input.ToString();

        try
        {
            int c = int.Parse(choice[1].ToString());
            switch (c)
            {
                case 0:
                    IsUsing = false;

                    Renderer.ClearFightOptions(_optionsLeft, _optionsTop);
                    Renderer.RenderFightOptions(Player, _optionsLeft, _optionsTop);

                    break;
                default:
                    Use(c);
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("NO");
        }
    }
    
    void Use(int number)
    {
        Item item = Player.Inventory.Item(number);
        Debug.WriteLine($"Used {item.Name}");

        ClearInfo();
        if (item is Weapon w)
        {
            Enemy.Damage(w.Damage);
            Player.Inventory.RemoveItem(item);
            
            DisplayInfo(item, Player);
            DisplayInfo("", Enemy);
        }
        DisplayInfo(item, Player);
        DisplayInfo("", Enemy);
        
        DisplayHP();
        
        Use(ConsoleKey.D0);
    }
    
    void DisplayHP()
    {
        Renderer.ClearHP(_hpLeft, _hpTop);
        Renderer.RenderHP(Player, Enemy, _hpLeft, _hpTop);
    }

    void DisplayInfo(string action, Pawn pawn, float damage = 0)
    {
        Console.SetCursorPosition(_hpLeft, _hpTop + 3);

        if (pawn is Player)
        {
            if (action != "") Console.WriteLine($"You {action} {Enemy.Name}! You dealt him {damage} damage");
            else Console.WriteLine($"You missed {Enemy.Name}..");
        }
        else
        {
            Console.SetCursorPosition(_hpLeft, _hpTop + 4);
            
            if (action != "") Console.WriteLine($"But {Enemy.Name} {action} you! He dealt him {damage} damage");
            else Console.WriteLine($"And {Enemy.Name} missed you");
        }
        
        DisplayHP();
    }
    
    void DisplayInfo(Item item, Pawn pawn)
    {
        Console.SetCursorPosition(_hpLeft, _hpTop + 3);

        if (pawn is Player)
        {
            if (item is Weapon w) Console.WriteLine($"You used {item.Name} and it dealt {w.Damage} to {Enemy.Name}!");
            else Console.WriteLine($"You used {item.Name} but it didn't do anything");
        }

        DisplayHP();
    }

    void ClearInfo()
    {
        Console.SetCursorPosition(_hpLeft, _hpTop + 3);

        Console.WriteLine("                                                                                              ");
    }
}