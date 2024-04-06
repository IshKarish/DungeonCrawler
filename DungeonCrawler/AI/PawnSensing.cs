using System.Diagnostics;

namespace DungeonCrawler;

public class PawnSensing
{
    public Vector2 Size { get; private set; }
    public Vector2 Center { get; private set; }
    
    public int StartX { get; private set; }
    public int StartY { get; private set; }
    public int EndX { get; private set; }
    public int EndY { get; private set; }
    
    public PawnSensing(Pawn pawn)
    {
        int defaultSize = 5;
        
        Size = new Vector2(defaultSize, defaultSize);
        SetCenter(pawn.Transform.Position);
    }

    public PawnSensing(int width, int height, Pawn pawn)
    {
        width += 4;
        height += 4;
        
        Size = new Vector2(width, height);
        SetCenter(pawn.Transform.Position);
    }

    public PawnSensing(Vector2 size, Pawn pawn)
    {
        size = new Vector2(size.X + 4, size.Y + 4);
        
        Size = size;
        SetCenter(pawn.Transform.Position);
    }

    public PawnSensing(int size, Pawn pawn)
    {
        size += 4;
        
        Size = new Vector2(size, size);
        SetCenter(pawn.Transform.Position);
    }

    public void SetCenter(Vector2 newCenter)
    {
        Center = newCenter;
        
        int xHalf = Size.X / 2;
        int yHalf = Size.Y / 2;

        StartX = Center.X - xHalf;
        EndX = Center.X + xHalf;
        
        StartY = Center.Y - yHalf;
        EndY = Center.Y + yHalf;
    }

    public bool CanSee(Pawn[] pawns, Pawn pawn)
    {
        foreach (Pawn p in pawns)
        {
            if (p == pawn) continue;
            //if (CanSee(p.Transform.Position, out Direction direction)) return true;
        }

        return false;
    }

    public bool CanSee(Vector2 point, World world)
    {
        // Default direction
        Direction direction = Direction.None;
        
        // X
        bool xPositive = (point.X < EndX) && (point.X > Center.X);
        bool xNegative = (point.X > StartX) && (point.X < Center.X);
        bool xSame = point.X == Center.X;
        
        // Y
        bool yPositive = (point.Y > StartY) && (point.Y < Center.Y);
        bool yNegative = (point.Y < EndY) && (point.Y > Center.Y);
        bool ySame = point.Y == Center.Y;
        
        // Bounds
        bool inXBounds = xPositive || xNegative || xSame;
        bool inYBounds = yPositive || yNegative || ySame;
        bool canSee = inXBounds && inYBounds;

        if (canSee) direction = LookDirection(xPositive, xNegative, xSame, yPositive, yNegative, ySame);
        
        // Wall = No
        bool isSightBlocked = true;
        if (direction != Direction.None) isSightBlocked = Physics.LineTrace(Center, world, Size.X, direction, out _);
        
        return canSee && !isSightBlocked;
    }

    public Vector2[] GetActorsInRange(World world)
    {
        List<Vector2> positions = new List<Vector2>();
        
        for (int i = 0; i < world.WorldArr.GetLength(0); i++)
        {
            for (int j = 0; j < world.WorldArr.GetLength(1); j++)
            {
                Actor current = world.WorldArr[i, j];
                
                if (current != null && CanSee(current.Transform.Position, world)) positions.Add(new Vector2(i, j));
            }
        }

        return positions.ToArray();
    }

    Direction LookDirection(bool xPositive, bool xNegative, bool xSame, bool yPositive, bool yNegative, bool ySame)
    {
        Direction direction = Direction.None;
        
        if (xPositive && ySame) direction = Direction.Right;
        else if (xNegative && ySame) direction = Direction.Left;
        else if (xSame && yPositive) direction = Direction.Up;
        else if (xSame && yNegative) direction = Direction.Down;

        return direction;
    }

    public bool IsSightBlocked(Pawn player, World world)
    {
        Vector2 normalizedPlayerDistance = Center.Normalize(player.Transform.Position, new Pawn(), out float dPlayer);
        //Debug.WriteLine($"dPlayer = {dPlayer}");

        Vector2[] walls = GetActorsInRange(world);
        foreach (Vector2 v in walls)
        {
            Vector2 normalizedWallDistance = Center.Normalize(v, new Actor(), out float dWall);

            bool sameNormal = Math.Abs(normalizedPlayerDistance.fX - normalizedWallDistance.fX) < 0.5 && Math.Abs(normalizedPlayerDistance.fY - normalizedWallDistance.fY) < 0.5;
            bool isSightBlocked = dPlayer > dWall;

            if (isSightBlocked && sameNormal) return true;
        }

        return false;
    }
}