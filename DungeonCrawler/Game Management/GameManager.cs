using System.Diagnostics;

namespace DungeonCrawler;

public class GameManager
{
    private Map _map;
    private Player _player;
    private Enemy[] _enemies;
    private Level _level;
    private World _world;

    private bool _isPaused;

    private bool _switchingLevel;
    private bool _canInteract;
    private bool _standingOnDoor;

    private bool _shouldRetractTrap;
    private Trap _trap;
    
    private ConsoleKeyInfo _input;

    #region Managment

    public void StartGame(Level firstLevel)
    {
        StartLevel(firstLevel);
        new Thread(PauseManager).Start(); 
        //Utilities.Speak("Rise and shine, Mr. Ben Dor, Rise and shine. Not that I wish to imply you have been sleeping on the class. No one is more deserving of a rest. And all the effort in the world would have gone to waste until... well, let's just say tiltan has come again. The right teacher in the wrong class can make all the difference in the world. So, wake up, Mr. Ben Dor, Wake up and grade the project.");

        //Utilities.Speak("Time, Dor Ben Dor? Is it really that time again? It seems as if you only just arrived. You've done a great deal in a small time span. You've done so well, in fact, that I've received some interesting grade for the project. Ordinarily I will get an F, but these are extra ordinary times. Rather than offer you the illusion of free choice, I will take the liberty of choosing for you, if and when the time comes round again. I do apologize for what must seem to you an arbitrary imposition, Dor Ben Dor. I trust it will all make sense to you in the course of… well, I'm really not at liberty to say. In the meantime, this is where I get off.");
    }
    
    public void StartLevel(Level level)
    {
        _shouldRetractTrap = false;
        _canInteract = false;
        _trap = null!;
        
        Console.Clear();
        
        _level = level;
        _map = _level.Map;
        _world = _level.World;
        
        Renderer.PrintMap(_map);
        
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
        
        StartThreads();
    }

    void StartThreads()
    {
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

    public void Pause()
    {
        _input = new ConsoleKeyInfo();
        
        _isPaused = true;
        Thread.Sleep(10);
        Console.Clear();
    }

    public void Resume()
    {
        _input = new ConsoleKeyInfo();
        
        Renderer.PrintMap(_map);
        _isPaused = false;
        
        StartThreads();
    }
    
    void PauseManager()
    {
        while (true)
        {
            bool pause = _input.Key == Keybindings.Pause;
            switch (pause)
            {
                case true when !_isPaused:
                    Pause();
                    break;
                case true when _isPaused:
                    Resume();
                    break;
            }
        }
    }

    #endregion

    #region Movement

    void PlayerMovement()
    {
        _player.Moved = false;
        while (!_switchingLevel && !_player.IsDead && !_isPaused)
        {
            _input = Console.ReadKey(true);
            if (_player.IsDead) break;
            
            switch (_input.Key)
            {
                case Keybindings.Forward:
                    _player.PawnMovement.MoveUp(1, _world);
                    break;
                case Keybindings.Backwards:
                    _player.PawnMovement.MoveUp(-1, _world);
                    break;
                case Keybindings.Right:
                    _player.PawnMovement.MoveRight(1, _world);
                    break;
                case Keybindings.Left:
                    _player.PawnMovement.MoveRight(-1, _world);
                    break;
            }
        }
    }

    void EnemiesMovement()
    {
        while (!_switchingLevel && !_isPaused)
        {
            foreach (Enemy e in _enemies)
            {
                if (!e.IsDead)
                {
                    if (e.PawnSensing.CanSee(_player.Transform.Position, _world) || e.BehaviorTree.IsChasing)
                    {
                        if (!e.BehaviorTree.IsChasing) e.BehaviorTree.IsChasing = true;
                        e.BehaviorTree.Chase(_world, _player);
                    }
                    else
                    {
                        //_world.RemoveActor(e);
                        //e.BehaviorTree.Patrol(_world, _enemies);
                        //_world.UpdateActor(e);
                    }
                }
            }
        }
    }

    #endregion

    #region Rendering

    void Render()
    {
        foreach (Actor a in _world.WorldArr)
        {
            if (a is Door d && (d.IsEntrance || d.IsOpened)) Renderer.OpenDoor(d);
        }
        
        while (!_isPaused && !_switchingLevel)
        {
            TextRendering();
            
            bool openInventory = _input.Key == Keybindings.Inventory;
            if (openInventory && !_player.IsInventoryOpened) RenderInventory();
            else if (openInventory && _player.IsInventoryOpened) RenderInventory(false);
            else if (_player.IsInventoryOpened && _player.Inventory.HasChanged)
            {
                RenderInventory(false);
                Console.SetCursorPosition(0, Console.GetCursorPosition().Top - 1);
                RenderInventory();
            }

            PlayerRender();
            EnemiesRender();
            InteractionsRender();
            
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
    
    void PlayerRender()
    {
        if (_player.Moved) Renderer.ClearPosition(_player.Transform.LastTransform.Position);
        Renderer.PrintPawnPosition(_player);
    }
    
    void EnemiesRender()
    {
        if (_enemies.Length > 0)
        {
            foreach (Enemy e in _enemies)
            {
                if (e.Moved) Renderer.ClearPosition(e.Transform.LastTransform.Position);
                Renderer.PrintPawnPosition(e);
            }
        }
    }
    
    void InteractionsRender()
    {
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
    }
    
    void TextRendering()
    {
        int top = _world.WorldArr.GetLength(0) + 2;
        string emptyLine = "                                                                     ";
        
        Console.SetCursorPosition(0, top);
            
        if (_canInteract) Console.WriteLine($"Press {Keybindings.Use} to interact.");
        else Console.WriteLine(emptyLine);
        
        if (_player.IsDead) Console.WriteLine("You ded lol");
        else Console.WriteLine(emptyLine);

        if (_player.Inventory.Equipped)
        {
            Console.WriteLine($"You equipped {_player.Inventory.Items[^1].Name}!");
            new Thread(Cooldown).Start();
        }
        else Console.WriteLine(emptyLine);
        
        Console.BackgroundColor = ConsoleColor.Black;
    }

    void Cooldown()
    {
        Thread.Sleep(2000);
        _player.Inventory.Equipped = false;
    }
    
    void RenderInventory(bool render = true, int line = 0)
    {
        _player.IsInventoryOpened = render;
        Console.SetCursorPosition(0, Console.GetCursorPosition().Top + line);
        
        if (!render) Console.WriteLine("                                                                 ");
        else Console.WriteLine(_player.Inventory.ToString());
        _player.Inventory.HasChanged = false;

        _input = new ConsoleKeyInfo();
    }
    
    #endregion

    #region Gameplay

    void GameManagement()
    {
        while (!_switchingLevel && !_player.IsDead && !_isPaused)
        {
            OverlapCheck();
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
                _player.Kill();
                _shouldRetractTrap = true;
                _trap = t;
                _world.UpdateActor(t);
            }

            foreach (Enemy e in _enemies)
            {
                if (a is Trap tr && tr.Activate(e))
                {
                    e.Kill();
                    _shouldRetractTrap = true;
                    _trap = tr;
                    _world.UpdateActor(tr);
                }
            }
        }
    }

    void InteractionsManager()
    {
        _canInteract = _player.Ineractor.CanInteract(_world, out Actor interactable, out _);
        bool isInteractButtonPressed = _input.Key == Keybindings.Use;
        
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

    void OverlapCheck()
    {
        _player.PawnMovement.IsOverlapped(_enemies);
    }

    #endregion
}