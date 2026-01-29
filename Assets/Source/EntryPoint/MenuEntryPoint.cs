using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuEntryPoint : MonoBehaviour
{
    private const float CONVERT_INCHES_TO_CM = 2.54f;

    [SerializeField] private Image _firstBaner;
    [SerializeField] private Image _secondBaner;
    [SerializeField] private Image _thirdBaner;

    [SerializeField] private RectTransform _mainPosition;
    [SerializeField] private RectTransform _leftPosition;
    [SerializeField] private RectTransform _rightPosition;

    [SerializeField] private GridLayoutGroup _layoutGroup;
    [SerializeField] private GameplayConfig _gameplayConfig;

    [SerializeField] private PictureViewFactory _pictureViewFactory;

    [SerializeField] private MainPanel _mainPanel;
    [SerializeField] private SplashPanel _splashPanel;

    private ScrolViewContainer _container;

    [Inject]
    private void Construct(ScrolViewContainer container) 
    {
        _container = container;
    }

    private async void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;

        float heightContainer = 0;
        int column = 0;
        int screenWidth = Screen.width;
        float dpi = Screen.dpi;

        if (dpi == 0)
            dpi = 96;

        float screenWidthInches = screenWidth / dpi;
        float screenWidthCm = screenWidthInches * CONVERT_INCHES_TO_CM;
        float oneDivision, devision;

        if (screenWidthCm >= _gameplayConfig.MinLengthTablet)
        {
            oneDivision = screenWidth / _gameplayConfig.ScaleFactoryTablet;
            devision = 0.5f;
            column = _gameplayConfig.Count—olumnTablet;
        }
        else
        {
            oneDivision = screenWidth / _gameplayConfig.ScaleFactoryPhone;
            devision = 0.47f;
            column = _gameplayConfig.Coun—olumnPhone;
        }

        _layoutGroup.padding.left = (int)(oneDivision / 4.6f);
        _layoutGroup.padding.right = (int)(oneDivision / 4.6f);
        _layoutGroup.cellSize = new Vector2(oneDivision / devision, _layoutGroup.cellSize.y);
        _layoutGroup.spacing = new Vector2((int)(oneDivision / 4.6f), _layoutGroup.spacing.y);


        heightContainer += _layoutGroup.padding.top + _layoutGroup.padding.bottom;
        heightContainer += _layoutGroup.cellSize.y * _gameplayConfig.CountPicture / column;
        heightContainer += _layoutGroup.spacing.y * _gameplayConfig.CountPicture / column;
        heightContainer += _gameplayConfig.CountPicture % column * _layoutGroup.spacing.y;

        RectTransform container = _layoutGroup.GetComponent<RectTransform>();
        Vector2 sizeDeltaContainer = container.sizeDelta;
        Vector2 sizeDeltaHalfContainer = container.sizeDelta;

        sizeDeltaContainer.y = heightContainer;
        sizeDeltaHalfContainer.y = heightContainer / 2 + (heightContainer % 2 * _layoutGroup.spacing.y);

        container.sizeDelta = sizeDeltaContainer;

        _container.Init(sizeDeltaContainer, sizeDeltaHalfContainer);

        _firstBaner.rectTransform.position = _mainPosition.position;
        _secondBaner.rectTransform.position = _rightPosition.position;
        _thirdBaner.rectTransform.position = _leftPosition.position;

        _splashPanel.Show();

        await UniTask.Delay(_gameplayConfig.TimeSplashPanelToMilisecond);

        _splashPanel.Hide();
        _mainPanel.Show();
        _pictureViewFactory.CreatPictures();
    }
}