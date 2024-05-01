namespace DungeonCrawler;

public class Sequence
{
    private List<string> _lines = new List<string>();
    private List<SkeletalMesh> _skeletalMeshes = new List<SkeletalMesh>();
    private List<int> _volumes = new List<int>();

    public bool HoldPlayer { get; private set; }
    public bool HoldEnemies { get; private set; }

    public Sequence(List<string> lines, bool holdPlayer = false, bool holdEnemies = true)
    {
        _lines = lines;
        HoldPlayer = holdPlayer;
        HoldEnemies = holdEnemies;
    }

    public Sequence(bool holdPlayer = false, bool holdEnemies = true)
    {
        HoldPlayer = holdPlayer;
        HoldEnemies = holdEnemies;
    }
    
    public void Play(GameManager gameManager)
    {
        foreach (string s in _lines)
        {
            Utilities.Play(s); 
        }

        gameManager.IsPlaying = false;

        if (HoldPlayer) gameManager.StartPlayerMovement = true;
        if (HoldEnemies) gameManager.StartEnemiesMovement = true;
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