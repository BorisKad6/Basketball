using UnityEngine;

public class LosePanel : Form
{
    private ILevelLoader _manager;
    private int _currentLevel;
    public void Init(ILevelLoader manager, int currentLevel)
    {
        _manager = manager;
        _currentLevel = currentLevel;
    }
    public void LoseGame()
    {
        Open();
        GameLoop.StopGame();
    }
    public void TurnToMenu()
    {
        _manager.LoadMenu();
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        _manager.LoadLevel(_currentLevel);
    }
}
