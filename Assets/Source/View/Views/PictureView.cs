using UnityEngine;
using UnityEngine.UI;

public class PictureView : MonoBehaviour
{
    [SerializeField] private Image _pictureImage;
    [SerializeField] private Image _premium;

    public bool IsPremium { get; private set; } = false;
    public Sprite Sprite { get; private set; }

    private void Awake()
    => _premium.gameObject.SetActive(false);

    public void SetSprite(Sprite sprite)
    {
        _pictureImage.sprite = sprite;
        Sprite = sprite;
    }

    public void SetPremium(bool value)
    { 
        _premium.gameObject.SetActive(value);
        IsPremium = value;
    }
}
