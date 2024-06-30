namespace DungeonCrawler;

public class Graphics
{
    public char Symbol { get; private set; }
    public ConsoleColor Color { get; set; }
    public string SymbolAscii { get; private set; }
    
    public Graphics(char symbol, ConsoleColor color)
    {
        Symbol = symbol;
        Color = color;
    }

    public Graphics(char symbol, ConsoleColor color, string symbolAscii)
    {
        Symbol = symbol;
        Color = color;
        SymbolAscii = symbolAscii;
    }
}