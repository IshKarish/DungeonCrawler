using System.Diagnostics;

namespace DungeonCrawler;

public class Encounter
{
    // Players
    public Enemy Enemy { get; private set; }
    public Player Player { get; private set; }
    
    // States
    public bool IsUsing { get; private set; }

    // Cursor positions
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
                Player.Slap(Enemy, out float damage);
                
                Renderer.RenderMessage(_optionsLeft, _optionsTop, $"You punched {Enemy.Name} and dealt him {damage} damage");
                RenderHP();
                
                break;
            case ConsoleKey.D2:
                Talk();
                
                return;
            case ConsoleKey.D3:
                IsUsing = true;
                Renderer.RenderInventory(Player, _optionsLeft, _optionsTop);
                
                return;
            case ConsoleKey.D4:
                break;
            default:
                Debug.WriteLine("NO");
                return;
        }
        
        Console.ReadKey(true);

        Enemy.Slap(Player, out float d);
        Renderer.RenderHP(Player, Enemy, _hpLeft, _hpTop);
        Renderer.RenderMessage(_optionsLeft, _optionsTop, $"{Enemy.Name} punched you and dealt {d} damage.");

        Console.ReadKey(true);

        Renderer.RenderFightOptions(Player, _optionsLeft, _optionsTop);
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
                    Debug.WriteLine("Back");
                    
                    Renderer.RenderFightOptions(Player, _optionsLeft, _optionsTop);
                    
                    break;
                default:
                    Use(c);
                    break;
            }
            
            IsUsing = false;
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
        
        if (item is Weapon w)
        {
            Enemy.Damage(w.Damage);
            Player.Inventory.RemoveItem(item);
            RenderMessage($"You used {item.Name} and dealt {w.Damage} to {Enemy.Name}");
        }
        else RenderMessage($"You used {item.Name} but it didn't do anything");
        
        RenderHP();
    }

    void Talk()
    {
        bool shouldSpare = FightDialogues.RandomDialogue(out string line, out string answer, out string outcome);
        outcome = outcome.Replace("Enemy", Enemy.Name);
        
        RenderMessage($"You: {line}");
        Console.ReadKey(true);
        RenderMessage($"{Enemy.Name}: {answer}");
        Console.ReadKey(true);
        RenderMessage(outcome);
        Console.ReadKey(true);
        RenderMessage("                                                                                                                                                                    ");

        if (shouldSpare)
        {
            Enemy.Slap(Player, out float damage);
            RenderMessage($"{Enemy.Name} punched you and dealt {damage} damage");
            RenderHP();
            Console.ReadKey(true);
        }
        
        Renderer.RenderFightOptions(Player, _optionsLeft, _optionsTop);
    }
    
    void RenderHP()
    {
        Renderer.ClearHP(_hpLeft, _hpTop);
        Renderer.RenderHP(Player, Enemy, _hpLeft, _hpTop);
    }

    void RenderMessage(string str)
    {
        Renderer.RenderMessage(_optionsLeft, _optionsTop, str);
    }
}