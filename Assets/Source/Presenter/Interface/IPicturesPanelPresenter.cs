using Cysharp.Threading.Tasks;
using UnityEngine;

public interface IPicturesPanelPresenter 
{
    Color ColorDisable { get; }
    Color ColorEnable { get; }
    public Vector2 SizeAllPicturs { get; }
    public Vector2 SizeHalfPicturs { get; }
    UniTaskVoid CheakPuctoreLoad(PictureView picture);
    void EnterPremiumPanel();
    void EnterPicturePanel(Sprite sprite);
}