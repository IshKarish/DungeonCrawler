namespace DungeonCrawler;

public static class Physics
{
    public static bool LineTrace(Vector2 start, World world, int length, Direction direction, out HitResult hitResult)
    {
        hitResult = new HitResult();
        
        for (int i = 0; i <= length; i++)
        {
            Actor hitActor = null;
            try
            {
                switch (direction)
                {
                    case Direction.Up:
                        hitActor = world.WorldArr[start.Y - i, start.X];
                        break;
                    case Direction.Down:
                        hitActor = world.WorldArr[start.Y + i, start.X];
                        break;
                    case Direction.Left:
                        hitActor = world.WorldArr[start.Y, start.X - i];
                        break;
                    case Direction.Right:
                        hitActor = world.WorldArr[start.Y, start.X + i];
                        break;
                    case Direction.UpLeft:
                        hitActor = world.WorldArr[start.Y - i, start.X - i];
                        break;
                    case Direction.UpRight:
                        hitActor = world.WorldArr[start.Y - i, start.X + i];
                        break;
                    case Direction.DownLeft:
                        hitActor = world.WorldArr[start.Y + i, start.X - i];
                        break;
                    case Direction.DownRight:
                        hitActor = world.WorldArr[start.Y + i, start.X + i];
                        break;
                }

                if (hitActor != null)
                {
                    hitResult = new HitResult(hitActor, i);
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        return false;
    }
    
    public static bool LineTrace(Vector2 start, Pawn pawn, int length, Direction direction, out HitResult hitResult)
    {
        hitResult = new HitResult();
        
        for (int i = 0; i <= length; i++)
        {
            bool hasHit = false;
            switch (direction)
            {
                case Direction.Up:
                    hasHit = pawn.Transform.Position.Y == start.Y - 1 && pawn.Transform.Position.X == start.X;
                    break;
                case Direction.Down:
                    hasHit = pawn.Transform.Position.Y == start.Y + 1 && pawn.Transform.Position.X == start.X;
                    break;
                case Direction.Left:
                    hasHit = pawn.Transform.Position.Y == start.Y && pawn.Transform.Position.X == start.X + i;
                    break;
                case Direction.Right:
                    hasHit = pawn.Transform.Position.Y == start.Y && pawn.Transform.Position.X == start.X - i;
                    break;
                case Direction.UpLeft:
                    hasHit = pawn.Transform.Position.Y == start.Y - i && pawn.Transform.Position.X == start.X + i;
                    break;
                case Direction.UpRight:
                    hasHit = pawn.Transform.Position.Y == start.Y - i && pawn.Transform.Position.X == start.X - i;
                    break;
                case Direction.DownLeft:
                    hasHit = pawn.Transform.Position.Y == start.Y + i && pawn.Transform.Position.X == start.X + i;
                    break;
                case Direction.DownRight:
                    hasHit = pawn.Transform.Position.Y == start.Y + i && pawn.Transform.Position.X == start.X - i;
                    break;
            }
            
            if (hasHit)
            {
                hitResult = new HitResult(pawn, i);
                return true;
            }
        }
        
        return false;
    }
    
    public static bool LineTrace(Vector2 start, Pawn pawn, int length, TrapDirection direction, out HitResult hitResult)
    {
        hitResult = new HitResult();
        
        for (int i = 0; i <= length; i++)
        {
            bool hasHit = false;
            switch (direction)
            {
                case TrapDirection.Left:
                    hasHit = pawn.Transform.Position.Y == start.Y && pawn.Transform.Position.X == start.X + i;
                    break;
                case TrapDirection.Right:
                    hasHit = pawn.Transform.Position.Y == start.Y && pawn.Transform.Position.X == start.X - i;
                    break;
            }
            
            if (hasHit)
            {
                hitResult = new HitResult(pawn, i);
                return true;
            }
        }
        
        return false;
    }
    
    public static bool LineTrace(Vector2 point, World world, out HitResult hitResult)
    {
        hitResult = new HitResult();
        Actor hitActor = world.WorldArr[point.Y, point.X];
        
        if (hitActor != null)
        {
            hitResult = new HitResult(hitActor, 0);
            return true;
        }
        return false;
    }
    
    public static bool LineTrace(Vector2 point, Pawn[] pawns, out HitResult hitResult)
    {
        foreach (Pawn p in pawns)
        {
            bool sameX = point.X == p.Transform.Position.X;
            bool sameY = point.Y == p.Transform.Position.Y;

            if (sameX && sameY)
            {
                hitResult = new HitResult(p, 0);
                return true;
            }
        }

        hitResult = new HitResult();
        return false;
    }
}