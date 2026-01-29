using UnityEngine;

public class MainPanel : MonoBehaviour, IMainPanel
{
    [SerializeField] private GameObject _panel;

    public void Show() 
    => _panel.SetActive(true);

    public void Hide() 
    => _panel.SetActive(false);
}
