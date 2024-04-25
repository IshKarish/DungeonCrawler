namespace DungeonCrawler;

public class HitResult
{
    public Actor HitActor { get; private set; }
    public int Distance { get; private set; }

    public HitResult() {}

    public HitResult(Actor hitActor, int distance)
    {
        HitActor = hitActor;
        Distance = distance;
    }
}