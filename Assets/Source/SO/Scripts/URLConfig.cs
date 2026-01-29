using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "URLConfig", menuName = "Config/Urls")]
public class URLConfig : ScriptableObject
{
    [SerializeField] private List<string> _urls = new List<string>();

    public IReadOnlyList<string> Urls => _urls;
}
