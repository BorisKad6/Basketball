using UnityEngine;

public class PausePanel : Form
{
    private ILevelLoader _manager;
    private int _currentLevel;
    public void Init(ILevelLoader manager, int currentLevel)
    {
        _manager = manager;
        _currentLevel = currentLevel;
    }
    public void PauseGame()
    {
        GameLoop.StopGame();
        Open();
    }
    public void TurnToMenu()
    {
        _manager.LoadMenu();
    }
    public void Restart()
    {
        _manager.LoadLevel(_currentLevel);
    }
    public void Resume()
    {
        GameLoop.ResumeGame();
        Close();
    }
}
