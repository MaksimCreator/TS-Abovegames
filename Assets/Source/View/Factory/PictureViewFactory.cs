using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PictureViewFactory : MonoBehaviour 
{
    [SerializeField] private URLConfig _urlConfig;
    [SerializeField] private PictureView _prefab;
    [SerializeField] private GameObject _container;
    [SerializeField] private PicturesPanelView _pictrurePanelView;

    private PictureCatalog _catalog;

    private bool _isInit = false;

    [Inject]
    private void Construct(PictureCatalog puctureCatalog) 
    {
        _catalog = puctureCatalog;
    }

    public void CreatPictures()
    {
        if (_isInit)
            return;
        
        _isInit = true;

        for (int i = 1; i <= _urlConfig.Urls.Count; i++)
        {
            PictureView view = Instantiate(_prefab, _container.transform);
            Button button = view.GetComponent<Button>();
            _pictrurePanelView.AddAllPuctore(view,button);

            if (i % 4 == 0)
                view.SetPremium(true);

            if (i % 2 == 0)
                _pictrurePanelView.AddEvenPuctore(view);
            else
                _pictrurePanelView.AddOddPuctore(view);

            _catalog.Registary(view, _urlConfig.Urls[i - 1]);
        }
    }
}
