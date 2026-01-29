using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

public class BanerPanelPresenter : IBanerPanelPresenter
{
    private readonly BanerMover _mover;
    private readonly BanerPanel _panel;
    private readonly RaycastSystem _checker;
    private readonly ITouchInput _touchInput;

    private bool _wasTimerActive = true;

    public int MaxIndex { get; private set; }

    public int IndexMainBaners { get; private set; } = 0;

    public event Action onNextBaner;

    [Inject]
    public BanerPanelPresenter(RaycastSystem checker,BanerMover banerMover,BanerPanel banerPanel,ITouchInput touchInput) 
    {
        _mover = banerMover;
        _panel = banerPanel;
        _touchInput = touchInput;
        _checker = checker;
    }

    public void Enable() 
    {
        _mover.Enable();
        _panel.onNextBaner += NextBaner;

        if (_wasTimerActive)
            _panel.StartTimer();
    }

    public void Disable() 
    {
        _panel.onNextBaner -= NextBaner;
        _mover.Disable();

        if(_wasTimerActive)
            _panel.StopTimer();
    }

    public void Update(float delta) 
    {
        _panel.Update(delta);
    }

    public async UniTaskVoid LeftMove(RectTransform mainBaner,RectTransform rightBaner,RectTransform nextRightBaner) 
    {
        _touchInput.Disable();
        _panel.StopTimer();
        _panel.ResetTimer();
        _wasTimerActive = false;

        await _mover.LeftMove(mainBaner,rightBaner,nextRightBaner);

        _touchInput.Enable();
        _panel.StartTimer();
        _wasTimerActive = true;

        if (IndexMainBaners + 1 >= MaxIndex)
            IndexMainBaners = 0;
        else
            IndexMainBaners++;
    }

    public async UniTaskVoid RightMove(RectTransform mainBaner, RectTransform leftBaner, RectTransform nextLeftBaner)
    {
        _touchInput.Disable();
        _panel.StopTimer();
        _panel.ResetTimer();
        _wasTimerActive = false;

        await _mover.RightMove(mainBaner,leftBaner,nextLeftBaner);

        _touchInput.Enable();
        _panel.StartTimer();
        _wasTimerActive = true;

        if (IndexMainBaners - 1 < 0)
            IndexMainBaners = MaxIndex - 1;
        else
            IndexMainBaners--;
    }

    private void NextBaner()
    => onNextBaner.Invoke();

    public void SetMaxIndex(int maxIndex)
    => MaxIndex = maxIndex;

    public bool CanMoveBaner(Vector2 startPosition,Vector2 endPosition,GameObject panel)
    => _checker.CanMoveBaner(startPosition,endPosition,panel);
}
