using System.Collections.Generic;
using UnityEngine.UI;

public class PictureCatalog 
{
    private readonly Dictionary<PictureView, string> _imageUrl = new();

    public void Registary(PictureView image, string Url)
    => _imageUrl.Add(image, Url);

    public string GetURL(PictureView image)
    => _imageUrl[image];
}