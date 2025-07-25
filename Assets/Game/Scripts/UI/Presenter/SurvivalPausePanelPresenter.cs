internal class SurvivalPausePanelPresenter : IPausePanelPresenter
{
    private readonly ISurvivalLoader _loader;
    private readonly IGameLoop _gameLoop;
    public SurvivalPausePanelPresenter(ISurvivalLoader loader, IGameLoop gameLoop)
    {
        _gameLoop = gameLoop;
        _loader = loader;
    }
    public void Open()
    {
        _gameLoop.StopGame();
    }

    public void Replay()
    {
        _loader.LoadSurvival();
    }

    public void Resume()
    {
        _gameLoop.ResumeGame();
    }

    public void ReturnToMenu()
    {
        _loader.LoadMenu();
    }
}