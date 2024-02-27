namespace DungeonCrawler;

class Program
{
    public static void Main(string[] args)
    {
        int mapSize = 20;
        
        Character player = new Character(mapSize, mapSize);
        Map map = new Map(mapSize, mapSize, player);
        
        while (true)
        {
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