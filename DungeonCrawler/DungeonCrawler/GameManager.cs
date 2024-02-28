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
        
        foreach (Vector2 w in navMesh.Walkable)
        {
            Console.WriteLine($"{w.X}, {w.Y}");
        }
        
        while (true)
        {
            game.UpdatePlayerLocation();
            map.PrintMap();
            
            ConsoleKeyInfo cki = Console.ReadKey();
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    player.MoveUp(-1);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    player.MoveUp(1);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    player.MoveRight(1);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    player.MoveRight(-1);
                    break;
            }
            Console.Clear();
        }
    }
}