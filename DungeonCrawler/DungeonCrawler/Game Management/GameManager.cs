using System.Diagnostics;

namespace DungeonCrawler;

public class GameManager
{
    private Map _map;
    private NavMesh _navMesh;
    private Pawn _player;
    private Enemy[] _enemies;
    private Level _level;

    private Vector2 _playerLastPos;
    private Vector2[] _enemyLastPos;

    public void StartGame(Level level)
    {
        _level = level;
        _map = _level.Map;
        _navMesh = _level.NavMesh;
        
        Renderer.PrintMap(_map);
        
        _player = _level.Player;
        Renderer.PrintPawnPosition(_player);
        _playerLastPos = _player.Transform.Position;
        
        _enemies = _level.Enemies;
        foreach (Enemy enemy in _enemies)
        {
            Renderer.ClearPawnPosition(enemy);
            Renderer.PrintPawnPosition(enemy);
        }

        _enemyLastPos = new Vector2[_enemies.Length];
        for (int i = 0; i < _enemyLastPos.Length; i++)
        {
            _enemyLastPos[i] = _enemies[i].Transform.Position;
        }
        
        Thread t = new Thread(PlayerMovement);
        Thread t2 = new Thread(EnemiesMovement);
        Thread t3 = new Thread(Render);
        
        t.Start();
        t2.Start();
        t3.Start();
    }
    
    public void PlayerMovement()
    {
        while (true)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            
            _playerLastPos = _player.Transform.Position;
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
                if (enemy.PawnSensing.CanSee(_player.Transform.Position) || enemy.BehaviorTree.ShouldChase)
                {
                    enemy.BehaviorTree.ShouldChase = true;
                    Debug.WriteLine("I see you");
                }
                else
                {
                    for (int i = 0; i < _enemyLastPos.Length; i++)
                    {
                        _enemyLastPos[i] = _enemies[i].Transform.Position;
                    }
                    
                    enemy.BehaviorTree.Patrol(_map, _navMesh);
                }
            }
        }
    }

    void Render()
    {
        while (true)
        {
            for (int i = 0; i < _enemyLastPos.Length; i++)
            {
                Renderer.ClearPawnPosition(_enemyLastPos[i]);
                Renderer.PrintPawnPosition(_enemies[i]);
            }
        
            Renderer.ClearPawnPosition(_playerLastPos);
            Renderer.PrintPawnPosition(_player);
        }
    }
}