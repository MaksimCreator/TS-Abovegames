using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PremiumPanel : MonoBehaviour, IPremiumPanel
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _back;
    [SerializeField] private MainPanel _mainPanel;

    private IPremiumPanelPresenter _premiumPanelPresenter;

    [Inject]
    private void Construct(IPremiumPanelPresenter premiumPanelPresenter) 
    {
        _premiumPanelPresenter = premiumPanelPresenter;
    }

    private void OnEnable()
    => _back.onClick.AddListener(Back);

    private void OnDisable()
    => _back.onClick.RemoveListener(Back);

    public void Show() 
    => _panel.SetActive(true);

    public void Hide() 
    => _panel.SetActive(false);

    private void Back() 
    {
        Hide();
        _premiumPanelPresenter.Back();
    }
}
