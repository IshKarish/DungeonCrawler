namespace DungeonCrawler;

public static class Physics
{
    public static bool LineTrace(Vector2 start, Map map, int length, Direction direction, out char hit)
    {
        hit = ' ';
        
        for (int i = 0; i <= length; i++)
        {
            try
            {
                switch (direction)
                {
                    case Direction.Up:
                        hit = map.MapArr[start.Y - i, start.X];
                        break;
                    case Direction.Down:
                        hit = map.MapArr[start.Y + i, start.X];
                        break;
                    case Direction.Left:
                        hit = map.MapArr[start.Y, start.X - i];
                        break;
                    case Direction.Right:
                        hit = map.MapArr[start.Y, start.X + i];
                        break;
                    case Direction.UpLeft:
                        hit = map.MapArr[start.Y - i, start.X - i];
                        break;
                    case Direction.UpRight:
                        hit = map.MapArr[start.Y - i, start.X + i];
                        break;
                    case Direction.DownLeft:
                        hit = map.MapArr[start.Y + i, start.X - i];
                        break;
                    case Direction.DownRight:
                        hit = map.MapArr[start.Y + i, start.X + i];
                        break;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            
            if (hit != ' ') return true;
        }

        hit = ' ';
        return false;
    }
}