using UnityEngine;
using System.Collections;
using System;

public class GetPicture : MonoBehaviour {

    private string _url = "http://rj-zoetigheid.nl/CordaanFolder/";
    private string _newUrl = "";

    private WWW _www;

    public void GetURL(string url)
    {
        _newUrl = _url + url;
        _newUrl = _newUrl.Replace("\\","/");

        _www = new WWW(_newUrl);
        StartCoroutine(WaitForRequest(_www));
    }
    

    private IEnumerator WaitForRequest(WWW www)
    {

        yield return www;
        Texture2D tex;
        tex = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
        
        Sprite newSprite = Sprite.Create(tex,new Rect(0,0,tex.width,tex.height),new Vector2(0.5f, 0.5f));

        www.LoadImageIntoTexture(tex);
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
