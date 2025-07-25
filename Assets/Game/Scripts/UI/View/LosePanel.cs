using UnityEngine;

public class LosePanel : Form
{
    private ILosePanelPresenter _presenter;
    public void Init(ILosePanelPresenter presenter)
    {
        _presenter = presenter;
    }
    public void TurnToMenu()
    {
        _presenter.ToMenu();
    }
    public void Restart()
    {
        _presenter.Replay();
    }
}
