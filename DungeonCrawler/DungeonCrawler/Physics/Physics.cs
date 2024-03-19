namespace DungeonCrawler;

public static class Physics
{
    public static bool LineTrace(Vector2 start, Map map, int length, Direction direction, out HitResult hitResult)
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
                        hitActor = map.WorldArr[start.Y - i - 1, start.X];
                        break;
                    case Direction.Down:
                        hitActor = map.WorldArr[start.Y + i + 1, start.X];
                        break;
                    case Direction.Left:
                        hitActor = map.WorldArr[start.Y, start.X - i - 1];
                        break;
                    case Direction.Right:
                        hitActor = map.WorldArr[start.Y, start.X + i + 1];
                        break;
                    case Direction.UpLeft:
                        hitActor = map.WorldArr[start.Y - i, start.X - i];
                        break;
                    case Direction.UpRight:
                        hitActor = map.WorldArr[start.Y - i, start.X + i];
                        break;
                    case Direction.DownLeft:
                        hitActor = map.WorldArr[start.Y + i, start.X - i];
                        break;
                    case Direction.DownRight:
                        hitActor = map.WorldArr[start.Y + i, start.X + i];
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
}