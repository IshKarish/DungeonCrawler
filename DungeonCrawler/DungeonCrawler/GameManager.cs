namespace DungeonCrawler;

public class GameManager
{
    public Game CreateGame(int mapSize, Character player, Object[] objects)
    {
        Map map = new Map(mapSize, objects);
        NavMesh navMesh = new NavMesh(map);
        Game game = new Game(map, navMesh, player);

        return game;
    }
    
    public void StartGame(Game game)
    {
        Map map = game.Map;
        Character player = game.Player;
        NavMesh navMesh = game.NavMesh;
        
        while (true)
        {
            Renderer.PrintMap(map, player);
            Console.WriteLine(game.IsPlayerStandingOnDoor());

            bool isCollidingFromRight = Physics.IsNextXColliding(player, navMesh, 1);
            bool isCollidingFromLeft = Physics.IsNextXColliding(player, navMesh, -1);
            bool isCollidingFromTop = Physics.IsNextYColliding(player, navMesh, -1);
            bool isCollidingFromBottom = Physics.IsNextYColliding(player, navMesh, 1);
            
            ConsoleKeyInfo cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (!isCollidingFromTop) player.MoveUp(-1);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (!isCollidingFromBottom) player.MoveUp(1);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (!isCollidingFromRight) player.MoveRight(1);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (!isCollidingFromLeft) player.MoveRight(-1);
                    break;
            }
            Console.Clear();
        }
    }
}