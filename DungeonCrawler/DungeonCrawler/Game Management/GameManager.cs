using System.Diagnostics;

namespace DungeonCrawler;

public class GameManager
{
    private Map _map;
    private Player _player;
    private Enemy[] _enemies;
    private Level _level;
    private World _world;

    private bool switchingLevel;
    private bool playerMoved;

    private bool shouldRetractTrap;
    private Trap trap;

    public void StartGame(Level firstLevel)
    {
        StartLevel(firstLevel);
    }
    
    public void StartLevel(Level level)
    {
        Console.Clear();
        
        _level = level;
        _map = _level.Map;
        _world = _level.World;
        
        Renderer.PrintMap(_map);
        
        _player = _level.Player;

        if (_level.Enemies != null) _enemies = _level.Enemies;
        else _enemies = new Enemy[0];
        
        Thread t = new Thread(PlayerMovement);
        Thread t2 = new Thread(EnemiesMovement);
        Thread t3 = new Thread(Render);
        Thread t4 = new Thread(TrapsDetector);
        
        t.Start();
        if (_enemies.Length > 0) t2.Start();
        t3.Start();
        t4.Start();
    }

    public void SwitchLevel(Level level)
    {
        switchingLevel = true;
        
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        
        _player.Transform.SetPosition(0, 0);
        
        Thread.Sleep(10);
        
        switchingLevel = false;
        StartLevel(level);
    }
    
    void PlayerMovement()
    {
        while (!switchingLevel && !_player.IsDead)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (!playerMoved) playerMoved = true;
            
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    _player.PawnMovement.MoveUp(1, _world);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    _player.PawnMovement.MoveUp(-1, _world);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    _player.PawnMovement.MoveRight(1, _world);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    _player.PawnMovement.MoveRight(-1, _world);
                    break;
            }

            bool LineTrace = Physics.LineTrace(_player.Transform.Position, _world, 1, Direction.Up, out HitResult hitResult);
            if (LineTrace && hitResult.HitActor is Teleporter) Debug.WriteLine($"Lol");

            if (_level.IsPlayerStandingOnDoor())
            {
                SwitchLevel(Utilities.CreateLevel(new Vector2(20, 50), _player, new Actor[0]));
            }
        }
    }

    void EnemiesMovement()
    {
        while (!switchingLevel)
        {
            foreach (Enemy enemy in _enemies)
            {
                if (enemy.PawnSensing.CanSee(_player.Transform.Position))
                {
                    Debug.WriteLine("I see you");
                }
                else
                {
                    enemy.BehaviorTree.Patrol(_world);
                }
            }
        }
    }

    void Render()
    {
        while (!switchingLevel)
        {
            //Console.SetCursorPosition(0, _world.WorldArr.GetLength(0) + 2);
            //
            //bool playerCanInteract = _player.Ineractor.CanInteract(_world);
            //if (playerCanInteract) Console.WriteLine("Press E to interact");
            //else Console.WriteLine("                      ");
            //
            //if (_player.IsDead) Console.WriteLine("You ded lol");
            //else Console.WriteLine("                      ");
            //
            //Console.WriteLine(playerMoved);
            //
            //Console.BackgroundColor = ConsoleColor.Black;
            
            if (playerMoved) Renderer.ClearPosition(_player.Transform.LastTransform.Position);
            Renderer.PrintPawnPosition(_player);
            
            if (_enemies.Length > 0)
            {
                foreach (Enemy e in _enemies)
                {
                    Renderer.ClearPosition(e.Transform.LastTransform.Position);
                    Renderer.PrintPawnPosition(e);
                }
            }

            if (shouldRetractTrap)
            {
                shouldRetractTrap = false;
                Renderer.RetractTrap(trap);
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }

    void TrapsDetector()
    {
        while (!switchingLevel && !_player.IsDead)
        {
            foreach (Actor a in _map.Actors)
            {
                if (a is Trap t && t.ShouldKill(_player))
                {
                    shouldRetractTrap = true;
                    trap = (Trap)a;
                    _player.Kill();
                }
            }
        }
    }
}