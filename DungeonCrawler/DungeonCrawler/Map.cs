namespace DungeonCrawler;

public class Map
{
    // Vars
    public Object obj = new Object(4, 2, 6, 4);
    
    public Character Player { get; set; }
    public int[,] Grid { get; private set; }
    
    private const char _horizontalBorder = '-';
    private const char _verticalBorder = '|';
    
    // Constructors
    public Map(Character player)
    {
        Player = player;
        Grid = new int[10, 10];
    }
    
    public Map(int sizeX, int sizeY, Character player)
    {
        Grid = new int[sizeX, sizeY];
        Player = player;
    }

    // Functions
    public void PrintMap()
    {
        int rows = Grid.GetLength(0);
        int cols = Grid.GetLength(1);
        
        for (int i = 0; i < rows; i++)
        {
            // States
            bool drawHasStarted = i == 0;
            bool drawHasEnded = i == rows - 1;
            
            if (drawHasStarted) // Print horizontal border
            {
                for (int j = 0; j < cols + 2; j++) 
                {
                    Console.Write(_horizontalBorder);
                }
                Console.WriteLine();
            }
            Console.Write(_verticalBorder); // Print vertical border
            
            for (int j = 0; j < cols; j++) // Print actual map
            {
                if (i == Player.Y && j == Player.X) Console.Write("*");
                else
                {
                    if ((i >= obj.LocationY && i <= obj.LocationY + (obj.SizeY - 1)) &&
                        (j >= obj.LocationX && j <= obj.LocationX + (obj.SizeX - 1)))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("&");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                }
            }
            
            Console.WriteLine(_verticalBorder); // Print vertical border
            if (drawHasEnded) // Print horizontal border
            {
                for (int j = 0; j < cols + 2; j++) 
                {
                    Console.Write(_horizontalBorder);
                }
            }
        }

        Console.WriteLine();
    }

    void PrintObject()
    {
        int sizeX = obj.SizeX;
        int sizeY = obj.SizeY;

        for (int j = 0; j < sizeX; j++)
        {
            Console.Write("&");
        }
    }
}