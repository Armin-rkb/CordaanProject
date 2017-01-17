using UnityEngine;
using System.Collections;
using System;

public class ConnectServer : MonoBehaviour {

    private string _url = "http://localhost/CordaanFolder/Connection.php";

    [SerializeField]
    private string _userName = "";

    private WWW _www;
    
    private string _wwwInfo;

    private string[] _wwwInfoSplitted;

    [SerializeField]
    private GameObject[] _picturesFrames;


    public void ConnectWithServer()
    {
        WWWForm form = new WWWForm();
        form.AddField("UserName", _userName);

        _www = new WWW(_url, form);
        StartCoroutine(WaitForRequest(_www));
    }

    private IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            print("www oke: " + www.text);
            _wwwInfo = www.text;
            _wwwInfoSplitted = _wwwInfo.Split('\n');

            for (int i = 4 ; i < _wwwInfoSplitted.Length; i++)
            {
                print(_wwwInfoSplitted[i]);
                _picturesFrames[i-4].GetComponent<GetPicture>().GetURL(_wwwInfoSplitted[i]);
            }
        }
        else {
            Debug.Log("www not oke: " + www.error);
        }
        
    }
}
