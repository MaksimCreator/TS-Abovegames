using UnityEngine;

[CreateAssetMenu(fileName = "MenuButtonConfig", menuName = "Config/MenuButton")]
public class MenuButtonConfig : ScriptableObject
{
    [SerializeField] private Color _colorEnable;
    [SerializeField] private Color _colorDisable;

    public Color ColorEnable => _colorEnable;

    public Color ColorDisable => _colorDisable;
}
