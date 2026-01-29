using UnityEngine;

[CreateAssetMenu(fileName = "BanerConfig", menuName = "Config/Baner")]
public class BanerConfig : ScriptableObject 
{
    [SerializeField] private float _timeMove = 1.5f;
    [SerializeField] private float _minMoveTouchForNext = 1;
    [SerializeField] private float _timeNextBaner = 5;

    public float TimeMove => _timeMove;
    public float TimeNextBaner => _timeNextBaner;
    public float MinMoveTouchForNext => _minMoveTouchForNext;
}