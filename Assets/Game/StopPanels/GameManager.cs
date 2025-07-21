using UnityEngine;

public class GameManager
{
    private ILevelLoader _levelManager;
    private IStorage _storage;
    private LosePanel _losePanel;
    private WinPanel _winPanel;
    private readonly PausePanel _pausePanel;
    private int _currentLevel;

    public GameManager(IStorage storage, ILevelLoader levelManager, LosePanel losePanel, WinPanel winPanel, PausePanel pausePanel)
    {
        _storage = storage;
        _currentLevel = storage.GetInt("LastLevel");
        _levelManager = levelManager;
        _losePanel = losePanel;
        _winPanel = winPanel;
        this._pausePanel = pausePanel;
        _losePanel.Close();
    }
    public void TurnToMenu()
    {
        Time.timeScale = 1f;
        _levelManager.LoadMenu();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        _levelManager.LoadLevel(_currentLevel);
    }
    public void LoseGame()
    {
        _losePanel.Open();
        Time.timeScale = 0f;
    }
    public void WinGame()
    {
        _storage.SaveBool("LevelPassed" + (_currentLevel), true);
        _winPanel.Open();
        Time.timeScale = 0f;
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        _pausePanel.Open();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        _pausePanel.Close();
    }
    public void StartNextLevel()
    {
        Time.timeScale = 1;
        if(_currentLevel >= 10)
        {
            _currentLevel = -1;
        }
        _levelManager.LoadLevel(_currentLevel+1);
    }
}