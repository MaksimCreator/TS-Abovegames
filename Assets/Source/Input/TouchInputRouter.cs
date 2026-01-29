using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchInputRouter : IControl, ITouchInput
{
    private readonly TouchInput _input = new TouchInput();

    private Vector2 _startPosition;
    private Vector2 _endPosition;

    public event Action<Vector2,Vector2> onEndTouch;

    public void Disable()
    {
        _input.Disable();
        _input.Touch.Touch.started -= SetStartPosition;
        _input.Touch.Touch.canceled -= OnEndTouch;
    }

    public void Enable()
    {
        _input.Enable();
        _input.Touch.Touch.started += SetStartPosition;
        _input.Touch.Touch.canceled += OnEndTouch;
    }

    private void SetStartPosition(InputAction.CallbackContext context) 
    => _startPosition = Touchscreen.current.primaryTouch.position.value;

    private void OnEndTouch(InputAction.CallbackContext context)
    {
        _endPosition = Touchscreen.current.primaryTouch.position.value;
        onEndTouch?.Invoke(_startPosition, _endPosition);
    }
}