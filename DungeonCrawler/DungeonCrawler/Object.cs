namespace DungeonCrawler;

public class Object
{
    public int SizeX { get; set; }
    public int SizeY { get; set; }
    
    public int LocationX { get; set; }
    public int LocationY { get; set; }

    public Object(int sizeX, int sizeY, int locationX, int locationY)
    {
        SizeX = sizeX;
        SizeY = sizeY;

        LocationX = locationX;
        LocationY = locationY;
    }
}