using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using System;

public class BanerMover : IControl
{
    private readonly Vector2 _positionLeftBaner;
    private readonly Vector2 _positionRightBaner;
    private readonly Vector2 _positionMainBaner;

    private readonly float _timeMove;

    private Tween _moveMainBaner;
    private Tween _moveNextBaner;

    public BanerMover(BanerConfig config,Vector2 positionLeftBaner,Vector2 positionRightBaner,Vector2 positionMainBaner) 
    {
        _positionLeftBaner = positionLeftBaner;
        _positionMainBaner = positionMainBaner;
        _positionRightBaner = positionRightBaner;
        _timeMove = config.TimeMove;
    }

    public void Disable() 
    {
        _moveMainBaner.Pause();
        _moveNextBaner.Pause();
    }

    public void Enable() 
    {
        _moveMainBaner.Play();
        _moveNextBaner.Play();
    }

    public async UniTask LeftMove(RectTransform mainBaner, RectTransform rightBaner, RectTransform nextRightBaner) 
    {
        nextRightBaner.position = _positionRightBaner;
        _moveMainBaner = mainBaner.DOMove(_positionLeftBaner,_timeMove)
            .SetEase(Ease.Linear)
            .Pause();

        _moveNextBaner = rightBaner.DOMove(_positionMainBaner,_timeMove)
            .SetEase(Ease.Linear)
            .Pause();

        await ApplayMove();
    }

    public async UniTask RightMove(RectTransform mainBaner, RectTransform LeftBaner, RectTransform nextLeftBaner) 
    {
        nextLeftBaner.position = _positionLeftBaner;

        _moveMainBaner = mainBaner.DOMove(_positionRightBaner, _timeMove)
            .SetEase(Ease.Linear)
            .Pause();

        _moveNextBaner = LeftBaner.DOMove(_positionMainBaner, _timeMove)
            .SetEase(Ease.Linear)
            .Pause();

        await ApplayMove();
    }

    private async UniTask ApplayMove() 
    {
        _moveMainBaner.Play();
        _moveNextBaner.Play();

        await _moveMainBaner.AsyncWaitForCompletion();
    }
}