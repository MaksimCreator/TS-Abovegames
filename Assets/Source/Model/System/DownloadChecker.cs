using System.Collections.Generic;

public class DownloadChecker 
{
    private HashSet<PictureView> _loadedImage = new();
    private float _loadStartPosition;

    public DownloadChecker(float loadStartPosition) 
    {
        _loadStartPosition = loadStartPosition;
    }

    public bool CanStartLoad(PictureView pucture) 
    {
        if (_loadedImage.TryGetValue(pucture, out PictureView activeValue))
            return false;

        if (pucture.transform.position.y >= _loadStartPosition) 
        {
            _loadedImage.Add(pucture);
            return true;
        }

        return false;
    }
}