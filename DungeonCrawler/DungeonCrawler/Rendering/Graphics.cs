namespace DungeonCrawler;

public class Graphics
{
    public char Symbol { get; set; }
    public ConsoleColor Color { get; set; }

    public Graphics(char symbol, ConsoleColor color)
    {
        Symbol = symbol;
        Color = color;
    }
}