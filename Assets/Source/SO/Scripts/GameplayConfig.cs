using UnityEngine;

[CreateAssetMenu(fileName = "GameplayConfig", menuName = "Config/GameplayConfig")]
public class GameplayConfig : ScriptableObject
{
    [SerializeField] private float _minLengthTablet;
    [SerializeField] private int _countColumnPhone;
    [SerializeField] private int _countColumnTablet;
    [SerializeField] private URLConfig _urlConfig;
    [SerializeField] private int _timeSplashPanelToMilisecond = 2000;

    public float MinLengthTablet => _minLengthTablet;
    public int CountPicture => _urlConfig.Urls.Count;
    public int ScaleFactoryPhone => _countColumnPhone * 2 + 1;
    public int ScaleFactoryTablet => _countColumnTablet * 2 + 1;
    public int CounÑolumnPhone => _countColumnPhone;
    public int CountÑolumnTablet => _countColumnTablet;
    public int TimeSplashPanelToMilisecond => _timeSplashPanelToMilisecond;
}
