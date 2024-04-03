using System.Diagnostics;

namespace DungeonCrawler;

public class PawnIneractor
{
    private Transform _transform;
    private Pawn _pawn;
    
    public bool IsIteracting { get; private set; }
    public bool OpenDoor { get; set; }
    public Actor Interactable { get; set; }
    
    public PawnIneractor(Pawn pawn)
    {
        _pawn = pawn;
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
    
    public void Interact(Actor interactable, ConsoleKeyInfo _input)
    {
        Interactable = interactable;
        IsIteracting = true;

        bool isPawn = IsPlayer(out Player p);
        
        switch (interactable)
        {
            case Chest chest:
                if (isPawn)
                {
                    p.Inventory.AddItem(chest.Item);
                    chest.Interactable = false;
                }
                if (chest.Item is RickRoll rickRoll) rickRoll.OpenRickRoll();
                break;
            case Door:
                if (isPawn && p.Inventory.HasItem("Key", true)) OpenDoor = true;
                break;
        }

        IsIteracting = true;
    }

    public void Release()
    {
        IsIteracting = false;
    }

    bool IsPlayer(out Player player)
    {
        if (_pawn is Player p)
        {
            player = p;
            return true;
        }

        player = null!;
        return false;
    }
}