using System.Diagnostics;

namespace DungeonCrawler;

public class Cutscene
{
    private List<string> _lines = new List<string>();
    private List<SkeletalMesh> _skeletalMeshes = new List<SkeletalMesh>();
    private List<int> _volumes = new List<int>();
    
    public bool Hold { get; private set; }

    public Cutscene(List<string> lines, bool hold = true)
    {
        _lines = lines;
        Hold = hold;
    }
    
    public Cutscene() {}
    
    public void Play(GameManager gameManager)
    {
        for (int i = 0; i < _lines.Count; i++)
        {
            Utilities.Speak(_lines[i], _skeletalMeshes[i].Voice, _volumes[i]);
        }

        if (Hold) gameManager.StartEnemiesMovement = true;
    }
    
    public void Play()
    {
        for (int i = 0; i < _lines.Count; i++)
        {
            Utilities.Speak(_lines[i], _skeletalMeshes[i].Voice, _volumes[i]);
        }
    }

    public void AddLine(string line, SkeletalMesh skeletalMesh)
    {
        _lines.Add(line);
        _skeletalMeshes.Add(skeletalMesh);
        _volumes.Add(skeletalMesh.Volume);
    }
}