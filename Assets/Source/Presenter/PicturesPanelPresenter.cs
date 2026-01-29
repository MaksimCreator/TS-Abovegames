using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PicturesPanelPresenter : IPicturesPanelPresenter
{
    private readonly MenuButtonConfig _menuButtonConfig;
    private readonly DownloadChecker _downloadChecker;
    private readonly PictureCatalog _catalog;
    private readonly IBanerPanelPresenter _banerPanelPresenter;
    private readonly IMainPanel _mainPanel;
    private readonly IPicturePanel _picturePanel;
    private readonly IPremiumPanel _premiumPanel;
    private readonly ScrolViewContainer _container;

    public Color ColorDisable => _menuButtonConfig.ColorDisable;
    public Color ColorEnable => _menuButtonConfig.ColorEnable;
    public Vector2 SizeAllPicturs => _container.SizeAllPicturs;
    public Vector2 SizeHalfPicturs => _container.SizeHalfPicturs;

    [Inject]
    public PicturesPanelPresenter(MenuButtonConfig menuButtonConfig,
        DownloadChecker downloadChecker,
        PictureCatalog pictureCatalog,
        ScrolViewContainer container,
        IBanerPanelPresenter banerPanelPresenter,
        IMainPanel mainPanel,
        IPicturePanel picturePanel,
        IPremiumPanel premiumPanel)
    {
        _menuButtonConfig = menuButtonConfig;
        _downloadChecker = downloadChecker;
        _catalog = pictureCatalog;
        _banerPanelPresenter = banerPanelPresenter;
        _mainPanel = mainPanel;
        _picturePanel = picturePanel;
        _premiumPanel = premiumPanel;
        _container = container;
    }

    public async UniTaskVoid CheakPuctoreLoad(PictureView picture) 
    {
        if (_downloadChecker.CanStartLoad(picture)) 
        {
            string Url = _catalog.GetURL(picture);
            picture.SetSprite(await RestApi.DownloadPNG(Url));
        }
    }

    public void EnterPremiumPanel() 
    {
        _banerPanelPresenter.Disable();
        _mainPanel.Hide();
        _premiumPanel.Show();
    }

    public void EnterPicturePanel(Sprite sprite)
    {
        _banerPanelPresenter.Disable();
        _mainPanel.Hide();
        _picturePanel.Show(sprite);
    }
}
