namespace DungeonCrawler;

class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        GameManager gameManager = new GameManager();
        
        Pawn player = new Pawn(0, 0, new Graphics('*', ConsoleColor.White));

        Graphics objGraphics = new Graphics('/', ConsoleColor.Blue);
        Graphics objGraphics2 = new Graphics('!', ConsoleColor.Yellow);
        Graphics objGraphics3 = new Graphics('^', ConsoleColor.DarkGreen);
        
        Actor obj = new Actor(2, 6, 3, 4, objGraphics);
        Actor obj2 = new Actor(6, 9,3, 4,  objGraphics);
        Actor obj3 = new Actor(10, 6, 3, 4, objGraphics);
        Actor obj4 = new Actor(14, 9, 3, 4, objGraphics);
        Actor obj5 = new Actor(18, 6, 3, 4, objGraphics);
        
        Actor obj6 = new Actor(78, 6, 10, 4, objGraphics2);
        
        Actor obj7 = new Actor(50, 18, 4, 4, objGraphics3);
        
        Door doorBenDoor = new Door(97, 0, DoorOrientation.Horizontal, -1);
        
        Actor[] objects =
        {
            obj, obj2, obj3, obj4, obj5, obj6, obj7, doorBenDoor
        };

        Vector2 l = new Vector2(20, 100);
        
        Level level = Utilities.CreateLevel(l);
        
        player.SetNavMesh(level.NavMesh);
        level.AddPlayer(player);
        
        Enemy[] enemies = Utilities.GenerateEnemies(1, level.Map, level.NavMesh);
        level.AddEnemies(enemies);

        Actor[] actors = Utilities.GenerateActors(1, level.Map, objGraphics);
        level.Map.AddActors(actors);
        
        gameManager.StartGame(level);
    }
}