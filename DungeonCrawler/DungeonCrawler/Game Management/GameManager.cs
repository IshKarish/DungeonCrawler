﻿using System.Diagnostics;

namespace DungeonCrawler;

public class GameManager
{
    private Map _map;
    private NavMesh _navMesh;
    private Pawn _player;
    private Enemy[] _enemies;
    private Level _level;

    private bool switchingLevel;
    private bool playerMoved = false;

    public void StartGame(Level firstLevel)
    {
        StartLevel(firstLevel);
    }
    
    public void StartLevel(Level level)
    {
        Console.Clear();
        
        _level = level;
        _map = _level.Map;
        _navMesh = _level.NavMesh;
        
        Renderer.PrintMap(_map);
        
        //Console.SetCursorPosition(0, _map.MapArr.GetLength(0) + 2);
        //Console.Write("Lol");
        
        _player = _level.Player;

        if (_level.Enemies != null) _enemies = _level.Enemies;
        else _enemies = new Enemy[0];
        
        Thread t = new Thread(PlayerMovement);
        Thread t2 = new Thread(EnemiesMovement);
        Thread t3 = new Thread(Render);
        
        t.Start();
        if (_enemies.Length > 0) t2.Start();
        t3.Start();
    }

    public void SwitchLevel(Level level)
    {
        switchingLevel = true;
        
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Black;
        
        _player.Transform.SetPosition(0, 0);
        
        switchingLevel = false;
        StartLevel(level);
    }
    
    public void PlayerMovement()
    {
        while (!switchingLevel)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (!playerMoved) playerMoved = true;
            
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    _player.PawnMovement.MoveUp(1, _map);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    _player.PawnMovement.MoveUp(-1, _map);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    _player.PawnMovement.MoveRight(1, _map);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    _player.PawnMovement.MoveRight(-1, _map);
                    break;
            }

            bool LineTrace = Physics.LineTrace(_player.Transform.Position, _map, 1, Direction.Right, out HitResult hitResult);
            if (LineTrace) Debug.WriteLine($"Hit {hitResult.HitActor.Graphics.Symbol} with {hitResult.HitActor.Graphics.Color} color.");

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
                    enemy.BehaviorTree.Patrol(_map, _navMesh);
                }
            }
        }
    }

    void Render()
    {
        while (!switchingLevel)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            
            Renderer.ClearPawnPosition(_player.Transform.LastTransform.Position);
            Renderer.PrintPawnPosition(_player);
            
            if (_enemies.Length > 0)
            {
                foreach (Enemy e in _enemies)
                {
                    Renderer.ClearPawnPosition(e.Transform.LastTransform.Position);
                    Renderer.PrintPawnPosition(e);
                }
            }
            
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}