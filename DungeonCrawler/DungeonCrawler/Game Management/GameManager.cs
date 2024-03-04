namespace DungeonCrawler;

public class GameManager
{
    public void StartGame(Game game)
    {
        Map map = game.Map;
        NavMesh navMesh = game.NavMesh;
        
        Renderer.PrintMap(map);
        
        Pawn player = game.Player;
        Renderer.UpdatePawnPosition(player, false);
        
        Pawn[] enemies = game.Enemies;
        foreach (Pawn enemy in enemies)
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
                    player.MoveUp(-1, map, navMesh);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    player.MoveUp(1, map, navMesh);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    player.MoveRight(1, map, navMesh);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    player.MoveRight(-1, map, navMesh);
                    break;
            } 
            
            Renderer.UpdatePawnPosition(player, true);
        }
    }
}