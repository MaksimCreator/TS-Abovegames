using System;
using UnityEngine;

public interface ITouchInput : IControl
{
    event Action<Vector2, Vector2> onEndTouch;
}