using Melanchall.DryWetMidi.Multimedia;

namespace DungeonCrawler;

public class CutsceneLevel : Level
{
    private Mesh _mesh;
    
    private string _path;
    private Level _nextLevel;
    private GameManager _gameManager;

    private Playback _playback;
    
    public CutsceneLevel(string path, Level nextLevel, GameManager gameManager)
    {
        _path = path;
        _nextLevel = nextLevel;
        _gameManager = gameManager;
    }

    public CutsceneLevel(Mesh mesh, string path, Level nextLevel, GameManager gameManager)
    {
        _path = path;
        _nextLevel = nextLevel;
        _gameManager = gameManager;
        _mesh = mesh;
    }
    
    public CutsceneLevel(Mesh mesh, Level nextLevel, GameManager gameManager)
    {
        _nextLevel = nextLevel;
        _gameManager = gameManager;
        _mesh = mesh;
    }

    public void Play()
    {
        if (_mesh != null) Console.WriteLine(_mesh.Ascii);

        if (_playback != null)
        {
            _playback = Utilities.PlayMidi(_path);
            _playback.Start();

            _playback.Finished += SwitchLevel;
        }
        else
        {
            Thread.Sleep(1000);
            SwitchLevel();
        }
    }

    private void SwitchLevel(object? sender, EventArgs e)
    {
        _gameManager.SwitchLevel(_nextLevel);
    }
    
    private void SwitchLevel()
    {
        _gameManager.SwitchLevel(_nextLevel);
    }
}