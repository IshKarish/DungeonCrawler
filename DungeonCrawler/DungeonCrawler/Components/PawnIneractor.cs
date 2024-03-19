namespace DungeonCrawler;

public class PawnIneractor
{
    private Pawn _pawn;
    private Transform _transform;
    
    public PawnIneractor(Pawn pawn)
    {
        _pawn = pawn;
        _transform = pawn.Transform;
    }

    public bool CanInteract(World world)
    {
        foreach (Direction dir in Enum.GetValues(typeof(Direction)))
        {
            if (Physics.LineTrace(_transform.Position, world, 1, dir, out HitResult hitResult) && hitResult.HitActor.Interactable) return true;
        }

        return false;
    }
}