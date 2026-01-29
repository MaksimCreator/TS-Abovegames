using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RaycastSystem 
{
    private readonly BanerConfig _config;
    private readonly GraphicRaycaster _graphicRaycaster;
    private readonly PointerEventData _pointerData;

    private List<RaycastResult> _results = new();
    private float _way;
    private bool _canMove = true;

    public RaycastSystem(BanerConfig config, GraphicRaycaster graphicRaycaster, EventSystem eventSystem) 
    {
        _config = config;
        _graphicRaycaster = graphicRaycaster;
        _pointerData = new PointerEventData(eventSystem);
    }

    public bool CanMoveBaner(Vector2 startTouch, Vector2 endTouch,GameObject panel)
    {
        _way = endTouch.x - startTouch.x;
        _way = _way < 0 ? _way * -1 : _way;

        if (_way < _config.MinMoveTouchForNext)
            return false;

        _pointerData.position = startTouch;

        _graphicRaycaster.Raycast(_pointerData, _results);

        for (int i = 0; i < _results.Count; i++)
        {
            if (_results[i].gameObject.name == panel.name)
            {
                _canMove = false;
                break;
            }
        }

        if (_canMove)
            return false;


        return true;
    }
}