using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PicturePanel : MonoBehaviour, IPicturePanel
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _back;
    [SerializeField] private Image _picture;

    private IPicturePanelPresenter _picturePresenter;

    [Inject]
    private void Construct(IPicturePanelPresenter picturePresenter) 
    {
        _picturePresenter = picturePresenter;
    }

    private void OnEnable()
    => _back.onClick.AddListener(Back);

    private void OnDisable()
    => _back.onClick.RemoveAllListeners();

    public void Show(Sprite sprite) 
    {
        _panel.SetActive(true);
        _picture.sprite = sprite;
    }

    public void Hide() 
    => _panel.SetActive(false);

    private void Back() 
    {
        Hide();
        _picturePresenter.Back();
    }
}
