internal class LevelLosePanelPresenter : ILosePanelPresenter
{
    private readonly ILevelLoader _levelLoader;
    private readonly int _currentLevel;

    public LevelLosePanelPresenter(ILevelLoader levelLoader, int currentLevel)
    {
        _levelLoader = levelLoader;
        _currentLevel = currentLevel;
    }

    public void Replay()
    {
        _levelLoader.LoadLevel(_currentLevel);
    }

    public void ToMenu()
    {
        _levelLoader.LoadMenu();
    }
}