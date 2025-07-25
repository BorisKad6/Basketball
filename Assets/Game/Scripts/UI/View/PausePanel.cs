using UnityEngine;

internal class PausePanel : Form
{
    private IPausePanelPresenter _presenter;
    public void Init(IPausePanelPresenter presenter)
    {
        _presenter = presenter;
    }
    public void PauseGame()
    {
        Open();
        _presenter.Open();
    }
    public void TurnToMenu()
    {
        _presenter.ReturnToMenu();
    }
    public void Restart()
    {
        _presenter.Replay();
    }
    public void Resume()
    {
        Close();
        _presenter.Resume();
    }
}
