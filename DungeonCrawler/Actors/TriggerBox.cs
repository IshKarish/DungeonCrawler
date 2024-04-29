namespace DungeonCrawler;

public class TriggerBox : Actor
{
    public Sequence Sequence { get; private set; }
    
    public TriggerBox(bool drawDebugBox = false)
    {
        Trigger = true;

        if (!drawDebugBox) Graphics = new Graphics(' ', ConsoleColor.Black);
        else Graphics = new Graphics('T', ConsoleColor.Yellow);
    }
    
    public TriggerBox(Vector2 position, Vector2 scale, bool drawDebugBox = false)
    {
        Transform.SetPosition(position);
        Transform.SetScale(scale);

        Trigger = true;
        
        if (!drawDebugBox) Graphics = new Graphics(' ', ConsoleColor.Black);
        else Graphics = new Graphics('T', ConsoleColor.Yellow);
    }

    public TriggerBox(Vector2 position, bool drawDebugBox = false)
    {
        Transform.SetPosition(position);

        Trigger = true;
        
        if (!drawDebugBox) Graphics = new Graphics(' ', ConsoleColor.Black);
        else Graphics = new Graphics('T', ConsoleColor.Yellow);
    }

    public TriggerBox(int xPos, int yPos, int xScale, int yScale, bool drawDebugBox = false)
    {
        Transform.SetPosition(xPos, yPos);
        Transform.SetScale(xScale, yScale);

        Trigger = true;
        
        if (!drawDebugBox) Graphics = new Graphics(' ', ConsoleColor.Black);
        else Graphics = new Graphics('T', ConsoleColor.Yellow);
    }

    public TriggerBox(int x, int y, bool drawDebugBox = false)
    {
        Transform.SetPosition(x, y);

        Trigger = true;
        
        if (!drawDebugBox) Graphics = new Graphics(' ', ConsoleColor.Black);
        else Graphics = new Graphics('T', ConsoleColor.Yellow);
    }

    public void AddCutscene(Sequence sequence)
    {
        Sequence = sequence;
    }
}