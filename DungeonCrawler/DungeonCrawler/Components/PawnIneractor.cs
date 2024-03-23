namespace DungeonCrawler;

public class PawnIneractor
{
    private Transform _transform;
    
    public PawnIneractor(Pawn pawn)
    {
        _transform = pawn.Transform;
    }

    public bool CanInteract(World world, out Actor interactable, out Direction direction)
    {
        foreach (Direction dir in Enum.GetValues(typeof(Direction)))
        {
            if (Physics.LineTrace(_transform.Position, world, 1, dir, out HitResult hitResult) && hitResult.HitActor.Interactable)
            {
                interactable = hitResult.HitActor;
                direction = dir;
                return true;
            }
        }

        interactable = new Actor();
        direction = Direction.Down;
        return false;
    }
    
    public bool CanInteract(World world, Direction direction, out Actor interactable)
    {
        bool hasHit = Physics.LineTrace(_transform.Position, world, 1, direction, out HitResult hitResult) && hitResult.HitActor.Interactable;

        if (hasHit) interactable = hitResult.HitActor;
        else interactable = new Actor();
        
        return hasHit;
    }
}