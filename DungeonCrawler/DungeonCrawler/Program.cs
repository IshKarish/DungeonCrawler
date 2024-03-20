namespace DungeonCrawler;

class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        GameManager gameManager = new GameManager();
        
        Player player = new Player(0, 0, new Graphics('*', ConsoleColor.White));

        Graphics objGraphics = new Graphics('/', ConsoleColor.Blue);
        Graphics objGraphics2 = new Graphics('!', ConsoleColor.Yellow);
        Graphics objGraphics3 = new Graphics('^', ConsoleColor.DarkGreen);

        Actor obj = new Actor(2, 6, 6, 4, objGraphics)
        {
            Interactable = true
        };

        Actor obj2 = new Actor(78, 6, 18, 2, objGraphics2);
        Actor obj3 = new Actor(50, 18, 4, 4, objGraphics3);
        Actor obj4 = new Actor(6, 9, 5, 5,  objGraphics);

        Trap trap = new Trap(0, 15);
        
        Door doorBenDoor = new Door(97, 0, DoorOrientation.Horizontal, -1);
        
        Actor[] objects =
        {
            obj, obj2, obj3, obj4, doorBenDoor, trap
        };

        Level level = Utilities.CreateLevel(new Vector2(20, 100), player, objects);
        
        Enemy[] enemies = Utilities.GenerateEnemies(10, level);
        //level.SetEnemies(enemies);

        Level level2 = Utilities.CreateLevel(new Vector2(20, 50), player, new Actor[0]);
        
        gameManager.StartGame(level);
    }
}