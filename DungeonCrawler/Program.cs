namespace DungeonCrawler;

class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        GameManager gameManager = new GameManager();
        
        Player player = new Player(0, 0, new Graphics('*', ConsoleColor.White));
        
        Level level2 = Utilities.CreateLevel(new Vector2(10, 50), player);
        
        #region Actors creation
        Graphics objGraphics = new Graphics('/', ConsoleColor.Blue);
        Graphics objGraphics2 = new Graphics('!', ConsoleColor.Yellow);
        Graphics objGraphics3 = new Graphics('^', ConsoleColor.DarkGreen);

        Actor obj = new Actor(2, 6, 6, 4, objGraphics);
        Actor obj2 = new Actor(78, 6, 18, 2, objGraphics2);
        Actor obj3 = new Actor(50, 18, 4, 4, objGraphics3);
        Actor obj4 = new Actor(6, 9, 5, 5,  objGraphics);
        Trap trap = new Trap(TrapDirection.Left, 3, obj4);
        Trap trap2 = new Trap(TrapDirection.Right, 1, obj4);
                
        Door doorBenDoor = new Door(97, 0, DoorDirection.Down, level2);
        Door dorBenDor = new Door(34, 13, DoorDirection.Left, level2);
        Door door2 = new Door(47, 3, DoorDirection.Left, true);

        Chest chest = new Chest(new Item("Key"));
                
        Actor[] objects =
        {
            obj, obj2, obj3, obj4, door2, chest, doorBenDoor, trap, trap2, dorBenDor
        };
        #endregion
        
        Level level = Utilities.CreateLevel(new Vector2(20, 100), player, objects);

        Door gay = new Door(26, 4, DoorDirection.Left, level, true);
        level2.Map.AddActor(gay);
        level2.UpdateWorldArr();
        
        Enemy[] enemies = Utilities.GenerateEnemies(50, level);
        //level.SetEnemies(enemies);
        
        gameManager.StartGame(level);
    }
}