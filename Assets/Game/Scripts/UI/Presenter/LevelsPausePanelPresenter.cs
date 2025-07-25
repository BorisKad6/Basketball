internal class LevelsPausePanelPresenter : IPausePanelPresenter
{
    private readonly ILevelLoader _levelLoader;
    private readonly IGameLoop _gameLoop;
    private readonly int _lastLevel;
    public LevelsPausePanelPresenter(ILevelLoader loader, IGameLoop gameLoop, int lastLevel)
    {
        _gameLoop = gameLoop;
        _levelLoader = loader;
        _lastLevel = lastLevel;
    }
    public void Replay()
    {
        _levelLoader?.LoadLevel(_lastLevel);
    }
    public void Open()
    {
        _gameLoop.StopGame();
    }
    public void Resume()
    {
        _gameLoop.ResumeGame();
    }

    public void ReturnToMenu()
    {
        _levelLoader.LoadMenu();
    }
}