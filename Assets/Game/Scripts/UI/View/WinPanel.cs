using UnityEngine;

public class WinPanel : Form
{
    private ILevelLoader _levelLoader;
    private IStorage _storage;
    private int _currentLevel;
    public void Init(ILevelLoader manager, IStorage storage, int currentLevel)
    {
        _levelLoader = manager;
        _currentLevel = currentLevel;
        _storage = storage;
    }
    public void Replay()
    {
        _levelLoader.LoadLevel(_currentLevel);
    }
    public void StartNextLevel()
    {
        if (_currentLevel >= 10)
        {
            _currentLevel = -1;
        }
        _levelLoader.LoadLevel(_currentLevel + 1);
    }
    public void TurnToMenu()
    {
        _levelLoader.LoadMenu();
    }
}