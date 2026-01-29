using UnityEngine;

public abstract class GameLoop : MonoBehaviour
{
    private bool _isEnable;

    private IControl[] _controls;
    private IUpdateble[] _updatebles;

    private void Update()
    {
        if (_updatebles == null)
            _updatebles = GetUpdatebles();

        for (int i = 0; i < _updatebles.Length; i++)
            _updatebles[i].Update(Time.deltaTime);
    }

    public void OnEnable()
    {
        if (_isEnable)
            return;

        if (_controls == null)
            _controls = GetControls();

        for (int i = 0; i < _controls.Length; i++)
            _controls[i].Enable();

        _isEnable = true;
    }

    public void OnDisable()
    {
        if (_isEnable == false)
            return;

        if (_controls == null)
            _controls = GetControls();

        for (int i = 0; i < _controls.Length; i++)
            _controls[i].Disable();

        _isEnable = false;
    }

    protected virtual IControl[] GetControls()
    => new IControl[0];

    protected virtual IUpdateble[] GetUpdatebles()
    => new IUpdateble[0];
}
