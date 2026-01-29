using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public interface IBanerPanelPresenter : IUpdateble,IControl
{
    public int MaxIndex { get; }
    public int IndexMainBaners { get; }

    public event Action onNextBaner;

    public UniTaskVoid LeftMove(RectTransform mainBaner, RectTransform rightBaner, RectTransform nextRightBaner);
    public UniTaskVoid RightMove(RectTransform mainBaner, RectTransform leftBaner, RectTransform nextLeftBaner);
    public bool CanMoveBaner(Vector2 startPosition, Vector2 endPosition, GameObject panel);
    public void SetMaxIndex(int maxIndex);
}