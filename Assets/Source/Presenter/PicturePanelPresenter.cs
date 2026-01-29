using Zenject;

public class PicturePanelPresenter : IPicturePanelPresenter
{
    private readonly IMainPanel _mainPanel;
    private readonly IBanerPanelPresenter _banerPanelPresenter;

    [Inject]
    public PicturePanelPresenter(IMainPanel mainPanel, IBanerPanelPresenter banerPanelPresenter) 
    {
        _mainPanel = mainPanel;
        _banerPanelPresenter = banerPanelPresenter;
    }

    public void Back()
    {
        _banerPanelPresenter.Enable();
        _mainPanel.Show();
    }
}
