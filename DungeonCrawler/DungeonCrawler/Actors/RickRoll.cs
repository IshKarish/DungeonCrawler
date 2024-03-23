using System.Diagnostics;

namespace DungeonCrawler;

public class RickRoll : Item
{
    public void OpenRickRoll()
    {
        string target = "https://www.youtube.com/watch?v=dQw4w9WgXcQ&pp=ygUIcmlja3JvbGw%3D";
        Process.Start(new ProcessStartInfo(target) {UseShellExecute = true});
    }
}