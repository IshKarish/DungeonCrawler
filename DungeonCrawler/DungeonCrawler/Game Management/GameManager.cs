namespace DungeonCrawler;

public class GameManager
{
    public void StartGame(Level level)
    {
        Map map = level.Map;
        NavMesh navMesh = level.NavMesh;
        
        Renderer.PrintMap(map);
        
        Pawn player = level.Player;
        Renderer.UpdatePawnPosition(player, false);
        
        Enemy[] enemies = level.Enemies;
        foreach (Enemy enemy in enemies)
        {
            Renderer.UpdatePawnPosition(enemy, false);
        }
        
        Console.SetCursorPosition(player.Transform.Position.X + 1, player.Transform.Position.Y + 1);
        
        while (true)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    player.PawnMovement.MoveUp(-1, map, navMesh);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    player.PawnMovement.MoveUp(1, map, navMesh);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    player.PawnMovement.MoveRight(1, map, navMesh);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    player.PawnMovement.MoveRight(-1, map, navMesh);
                    break;
            }
            
            //Renderer.UpdatePawnPosition(player, true);
            
            foreach (Enemy enemy in enemies)
            {
                enemy.PawnMovement.MoveRight(1, map, navMesh);
                //Renderer.UpdatePawnPosition(enemy, true);
            }
        }
    }
}