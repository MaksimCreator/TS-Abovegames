using System;
using Zenject;

public class BanerPanel : IUpdateble
{
    private Timer _timer;

    public event Action onNextBaner;

    public bool CanTickTimer { get; private set; }

    [Inject]
    public BanerPanel(BanerConfig config) 
    {
        _timer = new Timer(OnNextBaner, config.TimeNextBaner);
    }

    public void Update(float delta)
    {
        _timer.Tick(delta);
    }

    public void ResetTimer()
    => _timer.Reset();

    public void StopTimer()
    => _timer.Stop();

    public void StartTimer()
    => _timer.Start();

    private void OnNextBaner()
    => onNextBaner.Invoke();
}
