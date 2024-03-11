using System.Diagnostics;

namespace DungeonCrawler;

public class GameManager
{
    private Map _map;
    private NavMesh _navMesh;
    private Pawn _player;
    private Enemy[] _enemies;
    private Level _level;

    public void StartGame(Level level)
    {
        _level = level;
        _map = _level.Map;
        _navMesh = _level.NavMesh;
        
        Renderer.PrintMap(_map);
        
        Console.SetCursorPosition(0, _map.MapArr.GetLength(0) + 2);
        Console.Write("Lol");
        
        _player = _level.Player;
        Renderer.PrintPawnPosition(_player);

        if (_level.Enemies != null)
        {
            _enemies = _level.Enemies;
            
            foreach (Enemy enemy in _enemies)
            {
                Renderer.ClearPawnPosition(enemy);
                Renderer.PrintPawnPosition(enemy);
            }
        }
        else _enemies = new Enemy[0];
        
        Thread t = new Thread(PlayerMovement);
        Thread t2 = new Thread(EnemiesMovement);
        Thread t3 = new Thread(Render);
        
        t.Start();
        if (_enemies.Length > 0) t2.Start();
        t3.Start();
    }
    
    public void PlayerMovement()
    {
        while (true)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    _player.PawnMovement.MoveUp(1, _map, _navMesh);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    _player.PawnMovement.MoveUp(-1, _map, _navMesh);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    _player.PawnMovement.MoveRight(1, _map, _navMesh);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    _player.PawnMovement.MoveRight(-1, _map, _navMesh);
                    break;
            }
        }
    }

    void EnemiesMovement()
    {
        while (true)
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
        while (true)
        {
            Renderer.ClearPawnPosition(_player.Transform.LastTransform.Position);
            Renderer.PrintPawnPosition(_player);
            
            if (_enemies.Length > 0)
            {
                for (int i = 0; i < _enemies.Length; i++)
                {
                    Renderer.ClearPawnPosition(_enemies[i].Transform.LastTransform.Position);
                    Renderer.PrintPawnPosition(_enemies[i]);
                }
            }
        }
    }
}