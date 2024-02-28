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
        Object obj2 = new Object(6, 2, 7, 14, objGraphics2);
        Object obj3 = new Object(4, 4, 18, 18, objGraphics3);
        Object obj4 = new Object(3, 5, 5, 3, objGraphics);
        Door dorBenDor = new Door(15, 0, DoorOrientation.Vertical, -1);
        Object[] objects = { obj, obj2, obj3, obj4, dorBenDor };

        Game game = gameManager.CreateGame(20, player, objects);
        gameManager.StartGame(game);
    }
}