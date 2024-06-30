namespace DungeonCrawler;

public class Sequence
{
    private List<string> _lines = new List<string>();
    private List<SkeletalMesh> _skeletalMeshes = new List<SkeletalMesh>();
    private List<int> _volumes = new List<int>();

    public bool HoldMovement { get; private set; }

    public Sequence(List<string> lines)
    {
        _lines = lines;
    }

    public Sequence() {}
    
    public void Play(GameManager gameManager)
    {
        gameManager.StartMovement = false;
        
        foreach (string s in _lines)
        {
            Utilities.Play(s); 
        }

        gameManager.IsPlaying = false;

        gameManager.StartMovement = true;
    }
    
    public void Play()
    {
        foreach (string s in _lines)
        {
            Utilities.Play(s);
        }
    }
    
    public void AddLine(string line)
    {
        _lines.Add(line);
    }

    public void AddLine(string line, SkeletalMesh skeletalMesh)
    {
        _lines.Add(line);
        _skeletalMeshes.Add(skeletalMesh);
        _volumes.Add(skeletalMesh.Volume);
    }
}