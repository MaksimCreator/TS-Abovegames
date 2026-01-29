using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Networking;

public static class RestApi
{
    public static async UniTask<Sprite> DownloadPNG(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
        {
            await www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
                throw new InvalidOperationException();

            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }
}
