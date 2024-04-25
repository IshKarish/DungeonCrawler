namespace DungeonCrawler;

public class Mesh
{
    public string Ascii { get; private set; }

    public Mesh(string ascii)
    {
        Ascii = ascii;
    }

    public void Render()
    {
        Console.WriteLine(Ascii);
    }
}