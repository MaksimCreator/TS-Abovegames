using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Zenject;

public class PicturesPanelView : MonoBehaviour
{
    [SerializeField] private MenuButtonView _openAllPictore;
    [SerializeField] private MenuButtonView _openOddPictore;
    [SerializeField] private MenuButtonView _openEvenPictore;
    [SerializeField] private RectTransform _container;

    private List<PictureView> _allPictore = new();
    private List<Button> _allButtonPictory = new();
    
    private List<PictureView> _oddPictore = new();
    private List<PictureView> _evenPictore = new();

    private List<PictureView> _activePictory = new();

    private IPicturesPanelPresenter _picturePanelPresenter;

    [Inject]
    private void Construct(IPicturesPanelPresenter presenter)
    {
        _picturePanelPresenter = presenter;
    }

    private void Awake()
    => OpenAllPicture();

    private void OnEnable()
    {
        int index = 0;
        foreach (var button in _allButtonPictory) 
        {
            int indexView = index;
            index++;
            button.onClick.AddListener(() => OnClick(_allPictore[indexView]));
        }

        _openAllPictore.onClick += OpenAllPicture;
        _openOddPictore.onClick += OpenOddPicture;
        _openEvenPictore.onClick += OpenEvenPicture;
    }

    private void OnDisable()
    {
        foreach (var button in _allButtonPictory)
            button.onClick.RemoveAllListeners();

        _openAllPictore.onClick -= OpenAllPicture;
        _openOddPictore.onClick -= OpenOddPicture;
        _openEvenPictore.onClick -= OpenEvenPicture;
    }

    private void Update()
    {
        foreach (var item in _activePictory)
            _picturePanelPresenter.CheakPuctoreLoad(item);
    }

    public void AddOddPuctore(PictureView picture)
    => _oddPictore.Add(picture);

    public void AddAllPuctore(PictureView picture, Button button)
    {
        _allPictore.Add(picture);
        _allButtonPictory.Add(button);
        button.onClick.AddListener(() => OnClick(picture));
    }

    public void AddEvenPuctore(PictureView picture)
    => _evenPictore.Add(picture);

    private void DisableButtonEffects() 
    {
        _openAllPictore.SetColorText(_picturePanelPresenter.ColorDisable);
        _openAllPictore.SetActiveStripeActive(false);

        _openEvenPictore.SetColorText(_picturePanelPresenter.ColorDisable);
        _openEvenPictore.SetActiveStripeActive(false);

        _openOddPictore.SetColorText(_picturePanelPresenter.ColorDisable);
        _openOddPictore.SetActiveStripeActive(false);
    }

    private void OpenAllPicture() 
    {
        DisableButtonEffects();
        DisableActivePictory();

        _openAllPictore.SetActiveStripeActive(true);
        _openAllPictore.SetColorText(_picturePanelPresenter.ColorEnable);
        _activePictory = _allPictore;
        _container.sizeDelta = _picturePanelPresenter.SizeAllPicturs;

        EnableActivePictory();
    }

    private void OpenOddPicture() 
    {
        DisableButtonEffects();
        DisableActivePictory();

        _openOddPictore.SetActiveStripeActive(true);
        _openOddPictore.SetColorText(_picturePanelPresenter.ColorEnable);
        _activePictory = _oddPictore;
        _container.sizeDelta = _picturePanelPresenter.SizeHalfPicturs;

        EnableActivePictory();
    }

    private void OpenEvenPicture()
    {
        DisableButtonEffects();
        DisableActivePictory();

        _openEvenPictore.SetActiveStripeActive(true);
        _openEvenPictore.SetColorText(_picturePanelPresenter.ColorEnable);
        _activePictory = _evenPictore;
        _container.sizeDelta = _picturePanelPresenter.SizeHalfPicturs;

        EnableActivePictory();
    }

    private void EnableActivePictory() 
    {
        foreach (var pictory in _activePictory)
            pictory.gameObject.SetActive(true);
    }

    private void DisableActivePictory() 
    {
        foreach (var pictory in _activePictory)
            pictory.gameObject.SetActive(false);
    }

    private void OnClick(PictureView view)
    {
        if (view.Sprite == null)
            return;

        if (view.IsPremium)
            _picturePanelPresenter.EnterPremiumPanel();
        else
            _picturePanelPresenter.EnterPicturePanel(view.Sprite);
    }
}