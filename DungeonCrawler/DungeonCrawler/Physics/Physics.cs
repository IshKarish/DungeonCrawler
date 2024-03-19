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
                        hitActor = world.WorldArr[start.Y - i - 1, start.X];
                        break;
                    case Direction.Down:
                        hitActor = world.WorldArr[start.Y + i + 1, start.X];
                        break;
                    case Direction.Left:
                        hitActor = world.WorldArr[start.Y, start.X - i - 1];
                        break;
                    case Direction.Right:
                        hitActor = world.WorldArr[start.Y, start.X + i + 1];
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

                return false;
            }
            catch (Exception e)
            {
                return false;
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
}