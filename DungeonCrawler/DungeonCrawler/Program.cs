namespace DungeonCrawler;

class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        GameManager gameManager = new GameManager();
        
        Pawn player = new Pawn(0, 0, new Graphics('*', ConsoleColor.White));

        Level level = Utilities.CreateRandomLevel(new Vector2(20, 100), 10, 50);
        
        // Player setup
        player.SetNavMesh(level.NavMesh);
        level.AddPlayer(player);
        
        gameManager.StartGame(level);
    }
}