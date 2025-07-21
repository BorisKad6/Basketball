using UnityEngine;

public class WinPanel : Form
{
    private ILevelLoader _manager;
    private IStorage _storage;
    private int _currentLevel;
    public void Init(ILevelLoader manager, IStorage storage, int currentLevel)
    {
        _manager = manager;
        _currentLevel = currentLevel;
        _storage = storage;
    }
    public void WinGame()
    {
        _storage.SaveBool("LevelPassed" + (_currentLevel), true);
        Open();
        GameLoop.StopGame();
    }
    public void Replay()
    {
        _manager.LoadLevel(_currentLevel);
    }
    public void StartNextLevel()
    {
        if (_currentLevel >= 10)
        {
            _currentLevel = -1;
        }
        _manager.LoadLevel(_currentLevel + 1);
    }
    public void TurnToMenu()
    {
        Time.timeScale = 1f;
        _manager.LoadMenu();
    }
}