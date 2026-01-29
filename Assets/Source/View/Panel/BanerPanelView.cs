using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BanerPanelView : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField] private Sprite _activeIndicator;
    [SerializeField] private Sprite _inactiveIndicator;

    [Header("Indicator")]
    [SerializeField] private List<Image> _indicators;

    [Header("Baners")]
    [SerializeField] private List<Image> _baners;

    [Header("Panel")]
    [SerializeField] private GameObject _panel;

    private RectTransform _mainBaners;
    private RectTransform _leftBaners;
    private RectTransform _nextLeftBaners;
    private RectTransform _rightBaners;
    private RectTransform _nextRightBaners;

    private IBanerPanelPresenter _presenter;
    private ITouchInput _touchInput;

    [Inject]
    private void Consruct(IBanerPanelPresenter banerPanelPresenter,ITouchInput touchInput) 
    {
        _presenter = banerPanelPresenter;
        _touchInput = touchInput;
        _presenter.SetMaxIndex(_baners.Count);

        if (_indicators.Count != _baners.Count)
            throw new InvalidOperationException();
    }

    private void OnEnable()
    {
        _touchInput.onEndTouch += TryApplayMoveBaner;
        _presenter.onNextBaner += LeftMove;
    }

    private void OnDisable()
    {
        _touchInput.onEndTouch -= TryApplayMoveBaner;
        _presenter.onNextBaner -= LeftMove;
    }

    private void Update()
    {
        for (int i = 0; i < _indicators.Count; i++) 
        {
            if (_presenter.IndexMainBaners == i)
                _indicators[i].sprite = _activeIndicator;
            else
                _indicators[i].sprite = _inactiveIndicator;
        }
    }

    private void LeftMove()
    {
        _mainBaners = _baners[_presenter.IndexMainBaners].rectTransform;

        if (_presenter.IndexMainBaners + 1 == _presenter.MaxIndex)
        {
            _rightBaners = _baners[0].rectTransform;
            _nextRightBaners = _baners[1].rectTransform;
        }
        else if (_presenter.IndexMainBaners + 2 == _presenter.MaxIndex)
        {
            _rightBaners = _baners[_presenter.IndexMainBaners + 1].rectTransform;
            _nextRightBaners = _baners[0].rectTransform;
        }
        else 
        {
            _rightBaners = _baners[_presenter.IndexMainBaners + 1].rectTransform;
            _nextRightBaners = _baners[_presenter.IndexMainBaners + 2].rectTransform;
        }

            _presenter.LeftMove(_mainBaners, _rightBaners, _nextRightBaners);
    }

    private void RightMove() 
    {
        _mainBaners = _baners[_presenter.IndexMainBaners].rectTransform;

        if (_presenter.IndexMainBaners - 1 < 0)
        {
            _leftBaners = _baners[_presenter.MaxIndex - 1].rectTransform;
            _nextLeftBaners = _baners[_presenter.MaxIndex - 2].rectTransform;
        }
        else if (_presenter.IndexMainBaners - 2 < 0)
        {
            _leftBaners = _baners[_presenter.IndexMainBaners - 1].rectTransform;
            _nextLeftBaners = _baners[_presenter.MaxIndex - 1].rectTransform;
        }
        else
        {
            _leftBaners = _baners[_presenter.IndexMainBaners - 1].rectTransform;
            _nextLeftBaners = _baners[_presenter.IndexMainBaners - 2].rectTransform;
        }

        _presenter.RightMove(_mainBaners, _leftBaners, _nextLeftBaners);
    }

    private void TryApplayMoveBaner(Vector2 startPosition,Vector2 endPosition) 
    {
        if (_presenter.CanMoveBaner(startPosition,endPosition,_panel) == false)
            return;

        if (endPosition.x > startPosition.x)
            RightMove();
        else
            LeftMove();
    }
}