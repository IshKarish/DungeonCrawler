namespace DungeonCrawler;

public class GameManager
{
    public void StartGame(Game game)
    {
        Map map = game.Map;
        Pawn player = game.Player;
        NavMesh navMesh = game.NavMesh;
        Pawn[] enemies = game.Enemies;
        
        if (enemies != null) Renderer.PrintMap(map, player, game.Enemies);
                    else Renderer.PrintMap(map, player);
        
        while (true)
        {
            
            //Console.WriteLine(game.IsPlayerStandingOnDoor());
            
            ConsoleKeyInfo cki = Console.ReadKey();
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
            
            //Console.Clear();
        }
    }
}