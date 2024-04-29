namespace DungeonCrawler;

public class SkeletalMesh : Mesh
{
    public string Name { get; private set; }
    public string Voice { get; private set; }
    public int Volume { get; private set; }

    public SkeletalMesh(string name, string ascii, string voice, int volume = 100) : base(ascii)
    {
        Name = name;
        Voice = voice;
        Volume = volume;
    }
}