public class PremiumPanelPresenter : IPremiumPanelPresenter
{
    private readonly IBanerPanelPresenter _banerPresenter;
    private readonly IMainPanel _mainPanel;

    public PremiumPanelPresenter(IBanerPanelPresenter banerPanelPresenter,IMainPanel mainPanel) 
    {
        _banerPresenter = banerPanelPresenter;
        _mainPanel = mainPanel;
    }

    public void Back() 
    {
        _banerPresenter.Enable();
        _mainPanel.Show();
    }
}
