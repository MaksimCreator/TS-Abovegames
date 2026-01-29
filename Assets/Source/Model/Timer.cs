using System;

public class Timer
{
    private readonly Action _onEnd;
    private readonly float _cooldown;
    private float _timer;

    private bool _isEnable = true;

    public Timer(Action onEnd, float cooldown)
    {
        if (cooldown <= 0)
            throw new InvalidOperationException();

        _onEnd = onEnd;
        _cooldown = cooldown;
        _timer = cooldown;
    }

    public void Reset()
    => _timer = _cooldown;

    public void Stop() 
    => _isEnable = false;

    public void Start()
    => _isEnable = true;

    public void Tick(float delta) 
    {
        if (delta <= 0)
            throw new InvalidOperationException();

        if (_isEnable == false)
            return;

        _timer -= delta;

        if (_timer <= 0) 
        {
            _timer = _cooldown;
            _onEnd.Invoke();
        }
    }
}