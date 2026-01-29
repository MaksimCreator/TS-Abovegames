using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [Header("Configs")]
    [SerializeField] private BanerConfig _banerConfig;
    [SerializeField] private MenuButtonConfig _menuButtonConfig;

    [Header("Position")]
    [SerializeField] private RectTransform _leftPosition;
    [SerializeField] private RectTransform _mainPosition;
    [SerializeField] private RectTransform _rightPosition;
    [SerializeField] private RectTransform _positionLoadSprite;

    [Header("System")]
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GraphicRaycaster _graphicRaycaster;

    [Header("Factory")]
    [SerializeField] private PictureViewFactory _pictureViewFactory;

    [Header("Panel")]
    [SerializeField] private MainPanel _mainPanel;
    [SerializeField] private PremiumPanel _premiumPanel;
    [SerializeField] private PicturePanel _picturePanel;

    public override void InstallBindings()
    {
        RegistaryInput();
        RegistaryPanel();
        RegistaryPanle();
        RegistaryConfig();
        RegistarySystem(); 
        RegistaryCatalog();
        RegistaryPresenter();
        RegistaryAnimation();
        RegistaryViewFactory();
        RegistaryScrolViewContainer();
    }

    private void RegistaryScrolViewContainer() 
    {
        Container.Bind<ScrolViewContainer>()
               .FromNew()
               .AsSingle();
    }

    private void RegistaryViewFactory() 
    {
        Container.Bind<PictureViewFactory>()
            .FromInstance(_pictureViewFactory)
            .AsSingle();
    }

    private void RegistaryCatalog() 
    {
        Container.Bind<PictureCatalog>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryConfig()
    {
        Container.Bind<BanerConfig>()
            .FromInstance(_banerConfig)
            .AsSingle();
        
        Container.Bind<MenuButtonConfig>()
            .FromInstance(_menuButtonConfig)
            .AsSingle();
    }

    private void RegistaryInput() 
    {
        Container.Bind<ITouchInput>()
            .To<TouchInputRouter>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryPanel() 
    {
        Container.Bind<BanerPanel>()
            .FromNew()
            .AsSingle();
    }

    private void RegistarySystem() 
    {
        Container.Bind<RaycastSystem>()
        .FromInstance(new RaycastSystem(_banerConfig,_graphicRaycaster,_eventSystem))
        .AsSingle();

        Container.Bind<DownloadChecker>()
            .FromInstance(new DownloadChecker(_positionLoadSprite.position.y))
            .AsSingle();
    }

    private void RegistaryPresenter()
    {
        Container.Bind<IBanerPanelPresenter>()
            .To<BanerPanelPresenter>()
            .FromNew()
            .AsSingle();

        Container.Bind<IPicturesPanelPresenter>()
            .To<PicturesPanelPresenter>()
            .FromNew()
            .AsSingle();

        Container.Bind<IPremiumPanelPresenter>()
            .To<PremiumPanelPresenter>()
            .FromNew()
            .AsSingle();

        Container.Bind<IPicturePanelPresenter>()
            .To<PicturePanelPresenter>()
            .FromNew()
            .AsSingle();
    }

    private void RegistaryAnimation() 
    {
        Container.Bind<BanerMover>()
            .FromInstance(new BanerMover(_banerConfig,_leftPosition.position,_rightPosition.position,_mainPosition.position))
            .AsSingle();
    }

    private void RegistaryPanle() 
    {
        Container.Bind<IMainPanel>()
                .To<MainPanel>()
                .FromInstance(_mainPanel)
                .AsSingle();

        Container.Bind<IPicturePanel>()
            .To<PicturePanel>()
            .FromInstance(_picturePanel)
            .AsSingle();

        Container.Bind<IPremiumPanel>()
            .To<PremiumPanel>()
            .FromInstance(_premiumPanel)
            .AsSingle();
    }
}