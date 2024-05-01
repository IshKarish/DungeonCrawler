namespace DungeonCrawler;

public class GameManager
{
    private ConsoleKeyInfo _input;
    
    // Level related stuff
    private Map _map;
    private Player _player;
    private Enemy[] _enemies;
    private Level _level;
    private World _world;
    
    // States
    public bool StartMovement;
    
    private bool _isPaused;
    private bool _inCombat;
    private bool _switchingLevel;
    
    private bool _canInteract;
    private bool _standingOnDoor;
    private bool _shouldRetractTrap;
    
    public bool IsPlaying;
    public bool IsDroppingItem;
    
    // Other
    private Trap _currentTrap;

    #region Managment

    public void StartGame(Level firstLevel)
    {
        new Thread(Input).Start();
        StartLevel(firstLevel);
    }
    
    public void StartLevel(Level level)
    {
        if (level is CutsceneLevel c)
        {
            c.Play();
            return;
        }
        
        _shouldRetractTrap = false;
        _canInteract = false;
        _currentTrap = null!;
        
        Console.Clear();
        
        _level = level;
        _map = _level.Map;
        _world = _level.World;
        
        Renderer.RenderMap(_map);
        
        _player = _level.Player;
        
        if (level.StartPosition != null) _player.Transform.SetPosition(level.StartPosition);
        else _player.Transform.SetPosition(0, 0);
        
        foreach (Actor a in _map.Actors)
        {
            if (a is Door door && door.IsEntrance)
            {
                _player.Transform.SetPosition(door.PlayerSpawnPoint);
                _player.Transform.SetLastTransform(_player.Transform);
            }
            
            if (a is TriggerBox t && t.Sequence != null)
            {
                bool isTriggerOnEntrance = a.Transform.Position.X == _player.Transform.Position.X && a.Transform.Position.Y == _player.Transform.Position.Y;
                
                if (!isTriggerOnEntrance) StartMovement = true;
                break;
            }
        }

        if (_level.Enemies != null) _enemies = _level.Enemies;
        else _enemies = new Enemy[0];
        
        _switchingLevel = false;
        Logs.Add("You entered a new level");
        
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
        if (_level != null && _level is not CutsceneLevel) _level.UpdateWorldArr();
        if (level is not CutsceneLevel) level.UpdateWorldArr();
        
        _switchingLevel = true;
        
        Thread.Sleep(500);
        
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;

        if (_player != null)
        {
            if (level.StartPosition != null) _player.Transform.SetPosition(level.StartPosition);
            else _player.Transform.SetPosition(0, 0);
        }
        
        Thread.Sleep(10);
        
        StartLevel(level);
    }

    public void Pause(bool clear = true)
    {
        _input = new ConsoleKeyInfo();
        
        _isPaused = true;
        Thread.Sleep(10);
        if (clear) Console.Clear();
    }

    public void Resume(bool cleared = true)
    {
        _input = new ConsoleKeyInfo();

        if (cleared) Renderer.RenderMap(_map);
        _isPaused = false;
        
        StartThreads();
    }

    #endregion

    #region Movement

    void PlayerMovement()
    {
        _player.Moved = false;
        while (!_switchingLevel && !_player.IsDead && !_isPaused)
        {
            if (StartMovement)
            {
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
    }

    void EnemiesMovement()
    {
        while (!_switchingLevel && !_isPaused)
        {
            if (StartMovement)
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
                        else e.BehaviorTree.Patrol(_world, _enemies);
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
            InventoryUI();
            PlayerRender();
            EnemiesRender();
            InteractionsRender();
            
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }

    void InventoryUI()
    {
        bool openInventory = _input.Key == Keybindings.Inventory;
        if (openInventory && !_player.IsInventoryOpened) RenderInventory();
        else if (openInventory && _player.IsInventoryOpened) RenderInventory(false);

        if ((_player.Inventory.Equipped || IsDroppingItem) && _player.IsInventoryOpened) 
        {
            _player.Inventory.Equipped = false;
            RenderInventory(false);
            RenderInventory();
        }
    }
    
    void RenderInventory(bool render = true)
    {
        int left = _world.WorldArr.GetLength(1) + 2;
        int top = 5;
        
        _player.IsInventoryOpened = render;
        if (!render)
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine("                                                                                                        ");
            foreach (Item i in _player.Inventory.Items.ToArray())
            {
                Console.SetCursorPosition(left, top);

                string current = $"1. {i.Name}: {i.Description}.";
                for (int j = 0; j < current.Length; j++) Console.Write(" ");
                
                top++;
            }
        }
        else
        {
            Console.SetCursorPosition(left, top);
            Console.WriteLine("You have nothing lol");
            for (int i = 0; i < _player.Inventory.Items.Count; i++)
            {
                Console.SetCursorPosition(left, top);
                
                Item item = _player.Inventory.Items[i];
                Console.WriteLine($"{i + 1}. {item.Name}: {item.Description}");
                
                top++;
            }
        }
        
        _player.Inventory.HasChanged = false;
    
        _input = new ConsoleKeyInfo();
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
            Renderer.RetractTrap(_currentTrap);
        }
    
        if (_player.Ineractor.OpenDoor)
        {
            if (_player.Ineractor.Interactable is Door d) Renderer.OpenDoor(d);
            _player.Ineractor.OpenDoor = false;
        }
    }
    
    void TextRendering()
    {
        int top = _world.WorldArr.GetLength(0) + 10;
        
        Console.SetCursorPosition(0, top);
        
        top = _world.WorldArr.GetLength(0) + 2;
        Console.SetCursorPosition(1, top);
        if (_canInteract) Console.WriteLine($"Press {Keybindings.Use} to interact.");
        else Console.WriteLine("                    ");
        
        if (_player.HpChanged()) RenderHP(false);
        else RenderHP();
        
        if (Logs.HasChanged()) RenderLogs(false);
        else RenderLogs();
        
        Console.SetCursorPosition(0, 0);
        
        Console.BackgroundColor = ConsoleColor.Black;
    }

    void RenderLogs(bool render = true)
    {
        Logs.KeepFive();
        
        int top = _world.WorldArr.GetLength(0) + 10;

        if (!render)
        {
            Console.SetCursorPosition(0, top);
            for (int i = 0; i < Logs.LogsLst.ToArray().Length; i++)
            {
                Console.WriteLine("                                                                                                                                                          ");
            }
        }
        else
        {
            Console.SetCursorPosition(0, top);

            Console.WriteLine(Logs.ToString());
        }
    }

    void RenderHP(bool render = true)
    {
        int left = _world.WorldArr.GetLength(1) + 4;
        string emptyLine = "                                          ";
        
        Console.SetCursorPosition(left, 1);
        if (!render) Console.WriteLine(emptyLine);
        Console.SetCursorPosition(left, 1);
        if (render) Console.WriteLine($"You have {_player.HP} HP.");
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
            InventoryManagement();
        }
    }

    void InventoryManagement()
    {
        if (_player.IsInventoryOpened && _input.Key != 0 && !IsDroppingItem)
        {
            bool b = int.TryParse(_input.KeyChar.ToString(), out int c);
            if (b)
            {
                IsDroppingItem = true;
                _player.Inventory.RemoveItem(c, this);
            }
        }
    }

    void TrapsDetector()
    {
        foreach (Actor a in _map.Actors)
        {
            if (a is Trap t && t.Activate(_player))
            {
                Logs.Add($"You stepped on a trap and lost {t.Damage} HP");
                _player.Damage(t.Damage);
                
                _shouldRetractTrap = true;
                _currentTrap = t;
                _world.UpdateActor(t);
                
                if (_player.IsDead)
                {
                    Pause();
                    Renderer.RenderDeathScreen();
                }
            }

            foreach (Enemy e in _enemies)
            {
                if (a is Trap tr && tr.Activate(e))
                {
                    Logs.Add("This is not related to you but some enemy stepped on a trap and fucking died.");
                    KillEnemy(e);
                    
                    _shouldRetractTrap = true;
                    _currentTrap = tr;
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
            _input = new ConsoleKeyInfo();
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
            if (actor is Teleporter a)
            {
                if (a.Door != null && a.Destination is not CutsceneLevel)
                {
                    a.Door.SetAsEntrance(_map.Actors);
                    a.Destination.SetEntrance(_level);
                }
                SwitchLevel(a.Destination);
            }
            _switchingLevel = false;
        }
    }

    void OverlapCheck()
    {
        if (_player.PawnMovement.IsOverlapped(_enemies, out Actor hitActor))
        {
            if (hitActor is Enemy e && !e.IsDead && !_inCombat)
            {
                _inCombat = true;
                Pause();
                EnterEncounter(new Encounter(e, _player));
            }
        }
        else if (_player.PawnMovement.IsOverlapped(_world, out hitActor))
        {
            if (hitActor is not Teleporter)
            {
                if (hitActor is TriggerBox t && t.Sequence != null && !IsPlaying)
                {
                    IsPlaying = true;
                    t.Sequence.Play(this);
                }
            }
            _map.RemoveActor(hitActor);
            _world.RemoveActor(hitActor);
        }
    }

    #endregion

    void Input()
    {
        while (!_inCombat)
        {
            _input = Console.ReadKey(true);
            Thread.Sleep(1);
            _input = new ConsoleKeyInfo();
        }
    }

    void EnterEncounter(Encounter encounter)
    {
        Renderer.RenderEncounter(encounter, out int hpLeft, out int hpTop, out int optionsLeft, out int optionsTop);
        encounter.SetScreenValues(optionsLeft, optionsTop, hpLeft, hpTop);
        
        Renderer.RenderFightOptions(_player, optionsLeft, optionsTop);
        Renderer.RenderHP(_player, encounter.Enemy, hpLeft, hpTop);

        do
        {
            _input = Console.ReadKey(true);
            
            if (encounter.IsUsing) encounter.Use(_input.Key);
            else encounter.Act(_input.Key);
        } 
        while (!_player.IsDead && !encounter.Enemy.IsDead);

        if (encounter.Enemy.IsDead)
        {
            KillEnemy(encounter.Enemy);
            Logs.Add($"You encountered an enemy named {encounter.Enemy.Name} and won");
            Resume();
        }
        else
        {
            Pause();
            Renderer.RenderDeathScreen();
        }

        _inCombat = false;
        new Thread(Input).Start();
    }

    private void KillEnemy(Enemy e)
    {
        e.Kill();
        
        List<Enemy> eLst = _enemies.ToList();
        eLst.Remove(e);
        _enemies = eLst.ToArray();
    }
}