using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _stripeActive;
    [SerializeField] private TextMeshProUGUI _text;

    public event Action onClick;

    private void OnEnable()
    => _button.onClick.AddListener(OnClick);

    private void OnDisable()
    => _button.onClick.RemoveListener(OnClick);

    public void SetColorText(Color color)
    => _text.color = color;

    public void SetActiveStripeActive(bool value)
    => _stripeActive.gameObject.SetActive(value);

    private void OnClick()
    => onClick.Invoke();
}