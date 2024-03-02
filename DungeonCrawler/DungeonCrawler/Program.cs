namespace DungeonCrawler;

class Program
{
    public static void Main(string[] args)
    {
        GameManager gameManager = new GameManager();
        
        Character player = new Character();

        Graphics objGraphics = new Graphics('/', ConsoleColor.Blue);
        Graphics objGraphics2 = new Graphics('!', ConsoleColor.Yellow);
        Graphics objGraphics3 = new Graphics('^', ConsoleColor.DarkGreen);
        
        Object obj = new Object(3, 4, 2, 6, objGraphics);
        Object obj2 = new Object(6, 2, 27, 6, objGraphics2);
        Object obj3 = new Object(4, 4, 18, 18, objGraphics3);
        Object obj4 = new Object(3, 5, 6, 9, objGraphics);
        Door doorBenDoor = new Door(14, 0, DoorOrientation.Horizontal, -1);
        Object[] objects =
        {
            obj, obj2, obj3, obj4, doorBenDoor
        };

        Game game = Utilities.CreateGame(new Vector2(20, 100), player, objects);
        Character[] enemies = Utilities.GenerateEnemies(100, new Vector2(20, 100), game.NavMesh);
        game.AddEnemies(enemies);
        
        gameManager.StartGame(game);
    }
}