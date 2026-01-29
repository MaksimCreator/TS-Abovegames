using Zenject;

public class MenuLoop : GameLoop 
{
    private IControl[] _controls;
    private IUpdateble[] _updatebles;

    [Inject]
    private void Construct(ITouchInput touchInput,IBanerPanelPresenter banerPanelPresenter) 
    {
        _controls = new IControl[]
        {
            touchInput,
            banerPanelPresenter
        };

        _updatebles = new IUpdateble[]
        {
            banerPanelPresenter
        };
    }

    protected override IControl[] GetControls()
    => _controls;

    protected override IUpdateble[] GetUpdatebles()
    => _updatebles;
}