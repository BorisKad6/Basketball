internal class LevelWinPanelPresenter : IWinPanelPresenter
{
    private readonly ILevelLoader _levelLoader;

    private readonly int _lastLevel;
    private readonly int _levelsCount;

    public LevelWinPanelPresenter(ILevelLoader levelLoader, int lastLevel, int levelsCount)
    {
        _levelLoader = levelLoader;
        _lastLevel = lastLevel;
        _levelsCount = levelsCount;
    }

    public void LoadNext()
    {
        int next = _lastLevel + 1;
        if(_lastLevel < _levelsCount)
        {

            _levelLoader.LoadLevel(_lastLevel);
        }
        else
        {
            _levelLoader.LoadLevel(0);
        }
    }

    public void Replay()
    {
        _levelLoader.LoadLevel(_lastLevel);
    }

    public void ToMenu()
    {
        _levelLoader.LoadMenu();
    }
}