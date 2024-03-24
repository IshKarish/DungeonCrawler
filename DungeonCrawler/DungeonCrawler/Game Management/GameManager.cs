using System.Diagnostics;

namespace DungeonCrawler;

public class GameManager
{
    private Map _map;
    private Player _player;
    private Enemy[] _enemies;
    private Level _level;
    private World _world;

    private bool _switchingLevel;
    private bool _canInteract;
    private bool _standingOnDoor;

    private bool _shouldRetractTrap;
    private Trap _trap;
    
    private ConsoleKeyInfo _input;
    
    public void StartGame(Level firstLevel)
    {
        StartLevel(firstLevel);
    }
    
    public void StartLevel(Level level)
    {
        //_switchingLevel = false;
        _shouldRetractTrap = false;
        _canInteract = false;
        _trap = null!;
        
        Console.Clear();
        
        _level = level;
        _map = _level.Map;
        _world = _level.World;
        
        Renderer.PrintMap(_map);
        
        Thread.Sleep(1000);
        
        _player = _level.Player;
        foreach (Actor a in _map.Actors)
        {
            if (a is Door door && door.IsEntrance)
            {
                _player.Transform.SetPosition(door.PlayerSpawnPoint);
                _player.Transform.SetLastTransform(_player.Transform);
            }
        }

        if (_level.Enemies != null) _enemies = _level.Enemies;
        else _enemies = new Enemy[0];
        
        _switchingLevel = false;
        
        Thread t = new Thread(PlayerMovement);
        Thread t2 = new Thread(EnemiesMovement);
        Thread t3 = new Thread(GameManagement);
        Thread t4 = new Thread(Render);
        
        t.Start();
        if (_enemies.Length > 0) t2.Start();
        t3.Start();
        t4.Start();
    }

    public void SwitchLevel(Level level)
    {
        if (_level != null) _level.UpdateWorldArr();
        level.UpdateWorldArr();
        
        _switchingLevel = true;
        
        Thread.Sleep(500);
        
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        
        if (_player != null) _player.Transform.SetPosition(0, 0);
        
        Thread.Sleep(10);
        
        StartLevel(level);
    }
    
    void PlayerMovement()
    {
        _player.Moved = false;
        while (!_switchingLevel && !_player.IsDead)
        {
            _input = Console.ReadKey(true);
            if (_player.IsDead) break;
            
            switch (_input.Key)
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
        }
    }

    void EnemiesMovement()
    {
        while (!_switchingLevel)
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
        string emptyLine = "                                                                     ";

        foreach (Actor a in _world.WorldArr)
        {
            if (a is Door d && d.IsEntrance) Renderer.OpenDoor(d);
        }
        
        while (!_switchingLevel)
        {
            Console.SetCursorPosition(0, _world.WorldArr.GetLength(0) + 2);
            Console.WriteLine("Lol");
            
            if (_canInteract) Console.WriteLine("Press E to interact.");
            else Console.WriteLine(emptyLine);
            
            if (_player.IsDead) Console.WriteLine("You ded lol");
            else Console.WriteLine(emptyLine);
            
            Console.BackgroundColor = ConsoleColor.Black;
            
            if (_player.Moved) Renderer.ClearPosition(_player.Transform.LastTransform.Position);
            Renderer.PrintPawnPosition(_player);

            if (_shouldRetractTrap)
            {
                _shouldRetractTrap = false;
                Renderer.RetractTrap(_trap);
            }

            if (_player.Ineractor.OpenDoor)
            {
                if (_player.Ineractor.Interactable is Door d) Renderer.OpenDoor(d);
                _player.Ineractor.OpenDoor = false;
            }

            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
    
    void GameManagement()
    {
        while (!_switchingLevel && !_player.IsDead)
        {
            TrapsDetector();
            InteractionsManager(); 
            LevelSwitcher();
        }
    }

    void TrapsDetector()
    {
        foreach (Actor a in _map.Actors)
        {
            if (a is Trap t && t.Activate(_player))
            {
                _shouldRetractTrap = true;
                _trap = t;
                _world.UpdateActor(t);
            }
        }
    }

    void InteractionsManager()
    {
        _canInteract = _player.Ineractor.CanInteract(_world, out Actor interactable, out _);
        bool isInteractButtonPressed = _input.Key == ConsoleKey.E;
        
        if (isInteractButtonPressed && !_player.Ineractor.IsIteracting)
        {
            _player.Ineractor.Interact(interactable, _input);
        }
        else if (!isInteractButtonPressed && _player.Ineractor.IsIteracting)
        {
            _player.Ineractor.Release();
        }
    }

    void LevelSwitcher()
    {
        _standingOnDoor = _level.IsPlayerStandingOnDoor(out Actor actor) && actor is Teleporter teleporter && teleporter.Destination != null && !_standingOnDoor;
        
        if (_standingOnDoor)
        {
            _switchingLevel = true;
            if (actor is Teleporter a) SwitchLevel(a.Destination);
            _switchingLevel = false;
        }
    }
}