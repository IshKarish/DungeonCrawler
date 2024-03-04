namespace DungeonCrawler;

class Program
{
    public static void Main(string[] args)
    {
        //Console.CursorVisible = false;
        
        GameManager gameManager = new GameManager();
        
        Pawn player = new Pawn(0, 0, new Graphics('*', ConsoleColor.White));

        Graphics objGraphics = new Graphics('/', ConsoleColor.Blue);
        Graphics objGraphics2 = new Graphics('!', ConsoleColor.Yellow);
        Graphics objGraphics3 = new Graphics('^', ConsoleColor.DarkGreen);
        
        Actor obj = new Actor(3, 4, 2, 6, objGraphics);
        Actor obj2 = new Actor(6, 2, 27, 6, objGraphics2);
        Actor obj3 = new Actor(4, 4, 18, 18, objGraphics3);
        Actor obj4 = new Actor(3, 5, 6, 9, objGraphics);
        Door doorBenDoor = new Door(14, 0, DoorOrientation.Horizontal, -1);
        Actor[] objects =
        {
            obj, obj2, obj3, obj4, doorBenDoor
        };

        Game game = Utilities.CreateGame(new Vector2(20, 100), player, objects);
        Pawn[] enemies = Utilities.GenerateEnemies(10, new Vector2(20, 100), game.NavMesh);
        game.AddEnemies(enemies);
        
        gameManager.StartGame(game);
    }
}