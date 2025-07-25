internal class SurvivalLosePanelPresenter : ILosePanelPresenter
{
    private readonly ISurvivalLoader _loader;
    public SurvivalLosePanelPresenter(ISurvivalLoader loader)
    {
        _loader = loader;
    }
    public void Replay()
    {
        _loader.LoadSurvival();
    }

    public void ToMenu()
    {
        _loader.LoadMenu();
    }
}