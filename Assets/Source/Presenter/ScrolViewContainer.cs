using System;
using UnityEngine;

public class ScrolViewContainer
{
    public Vector2 SizeAllPicturs { get; private set; }
    public Vector2 SizeHalfPicturs { get; private set; }

    private bool _isInit = false;

    public void Init(Vector2 sizeAllPicturs,Vector2 sizeHalfPicturs) 
    {
        if (_isInit)
            throw new InvalidOperationException(nameof(_isInit));

        SizeAllPicturs = sizeAllPicturs;
        SizeHalfPicturs = sizeHalfPicturs;

        _isInit = true;
    }
}