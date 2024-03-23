namespace DungeonCrawler;

class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        GameManager gameManager = new GameManager();
        
        Player player = new Player(0, 0, new Graphics('*', ConsoleColor.White));
        
        Level level2 = Utilities.CreateLevel(new Vector2(10, 50), player);
        Level level3 = Utilities.CreateLevel(new Vector2(15, 25), player);
        Door lol = new Door(4, 4, DoorDirection.Left, true);
        //level3.Map.AddActor(lol);
        
        #region Actors creation
        Graphics objGraphics = new Graphics('/', ConsoleColor.Blue);
        Graphics objGraphics2 = new Graphics('!', ConsoleColor.Yellow);
        Graphics objGraphics3 = new Graphics('^', ConsoleColor.DarkGreen);

        Actor obj = new Actor(2, 6, 6, 4, objGraphics);
        Actor obj2 = new Actor(78, 6, 18, 2, objGraphics2);
        Actor obj3 = new Actor(50, 18, 4, 4, objGraphics3);
        Actor obj4 = new Actor(6, 9, 5, 5,  objGraphics);
                
        Door doorBenDoor = new Door(97, 0, DoorDirection.Down, level2);
        Door door2 = new Door(47, 3, DoorDirection.Left, true);

        Chest chest = new Chest(new RickRoll());
                
        Actor[] objects =
        {
            obj, obj2, obj3, obj4, door2, chest, doorBenDoor
        };
        #endregion
        
        Level level = Utilities.CreateLevel(new Vector2(20, 100), player, objects);
        Trap trap = new Trap(TrapDirection.Left, 3, obj4);
        Trap trap2 = new Trap(TrapDirection.Right, 1, obj4);
        Door d3 = new Door(12, 6, DoorDirection.Down, level);
        level.Map.AddActor(d3);
        level.Map.AddActor(trap);
        level.Map.AddActor(trap2);
        level.UpdateWorldArr();

        Door gay = new Door(26, 4, DoorDirection.Left, level, true);
        level2.Map.AddActor(gay);
        level2.UpdateWorldArr();
        
        Enemy[] enemies = Utilities.GenerateEnemies(10, level);
        //level.SetEnemies(enemies);
        
        //Renderer.PrintMap(level3.Map);
        gameManager.StartGame(level);
    }
}