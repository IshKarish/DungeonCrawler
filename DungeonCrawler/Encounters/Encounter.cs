using System.Diagnostics;

namespace DungeonCrawler;

public class Encounter
{
    public Enemy Enemy { get; private set; }
    public Player Player { get; private set; }
    
    public bool PlayerTurn { get; private set; }
    private bool _isUsing;

    public Encounter(Enemy enemy, Player player)
    {
        Enemy = enemy;
        Player = player;
    }

    public void Act(ConsoleKey input, int optionsLeft, int optionsTop, int hpLeft, int hpTop)
    {
        switch (input)
        {
            case ConsoleKey.D1:
                Debug.WriteLine("Slap");
                
                Enemy.Damage(15);
                Debug.WriteLine(Enemy.HP);
                
                Renderer.ClearHP(hpLeft, hpTop);
                Renderer.RenderHP(Player, Enemy, hpLeft, hpTop);
                
                break;
            case ConsoleKey.D2:
                Debug.WriteLine("Shield");
                break;
            case ConsoleKey.D3:
                Debug.WriteLine("Use");
                
                _isUsing = true;
                
                Renderer.ClearFightOptions(optionsLeft, optionsTop);
                Renderer.RenderFightOptions(Player, optionsLeft, optionsTop, true);
                
                break;
            case ConsoleKey.D4:
                Debug.WriteLine("Run");
                break;
            default:
                Debug.WriteLine($"{Enemy.Name} hit you");
                break;
        }
    }
}