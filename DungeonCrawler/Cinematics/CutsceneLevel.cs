using System.Diagnostics;
using Melanchall.DryWetMidi.Multimedia;

namespace DungeonCrawler;

public class CutsceneLevel : Level
{
    private Mesh _mesh;
    private Mesh[] _meshes;
    private Mesh _endingMesh;
    
    private string _path;
    private string _url;
    private Level _nextLevel;
    private GameManager _gameManager;

    private Sequence _sequenceDialogue;

    private Playback _playback;
    
    public CutsceneLevel(string path, Level nextLevel, GameManager gameManager)
    {
        _path = path;
        _nextLevel = nextLevel;
        _gameManager = gameManager;
    }
    
    public CutsceneLevel(Mesh mesh, Level nextLevel, GameManager gameManager)
    {
        _nextLevel = nextLevel;
        _gameManager = gameManager;
        _mesh = mesh;
    }
    
    public CutsceneLevel(Mesh mesh, string path, Level nextLevel, GameManager gameManager)
    {
        _path = path;
        _nextLevel = nextLevel;
        _gameManager = gameManager;
        _mesh = mesh;
    }
    
    public CutsceneLevel(Mesh mesh, Sequence sequence, Level nextLevel, GameManager gameManager)
    {
        _sequenceDialogue = sequence;
        _nextLevel = nextLevel;
        _gameManager = gameManager;
        _mesh = mesh;
    }
    
    public CutsceneLevel(Mesh[] meshes, string path, Level nextLevel, GameManager gameManager)
    {
        _path = path;
        _nextLevel = nextLevel;
        _gameManager = gameManager;
        _meshes = meshes;
    }

    public void AddEndDialogue(Sequence sequence)
    {
        _sequenceDialogue = sequence;
    }

    public void AddEndingURL(string url)
    {
        _url = url;
    }

    public void AddEndingMesh(Mesh mesh)
    {
        _endingMesh = mesh;
    }
    
    public void Play()
    {
        Thread.Sleep(10);
        
        if (_mesh != null) Console.WriteLine(_mesh.Ascii);

        if (_path != null)
        {
            _playback = Utilities.CreatePlaybackMidi(_path);
            _playback.Start();

            if (_meshes != null && _meshes.Length > 0)
            {
                foreach (Mesh m in _meshes)
                {
                    Console.Clear();
                    Console.WriteLine(m.Ascii);
                    Thread.Sleep(5000);
                }
            }

            _playback.Finished += SwitchLevel;
        }
        else if (_sequenceDialogue != null)
        {
            _sequenceDialogue.Play();
            SwitchLevel();
        }
        else
        {
            Thread.Sleep(2000);
            SwitchLevel();
        }
    }

    private void SwitchLevel(object? sender, EventArgs e)
    {
        if (_endingMesh != null)
        {
            Console.Clear();
            Console.WriteLine(_endingMesh.Ascii);
            Thread.Sleep(5000);
        }
        
        if (_sequenceDialogue != null)
        {
            Console.Clear();
            _sequenceDialogue.Play();
            if (_url != null) Process.Start(new ProcessStartInfo(_url) {UseShellExecute = true});
        }
        
        _gameManager.SwitchLevel(_nextLevel);
    }
    
    private void SwitchLevel()
    {
        _gameManager.SwitchLevel(_nextLevel);
    }
}