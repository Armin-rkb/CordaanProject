using UnityEngine;
using System.Collections;

public class StartAnimation : MonoBehaviour {

    [SerializeField]
    private GameObject _canvasObj;

    [SerializeField]
    private GameObject _cameraObj;

    private cameraMovement _cameramovement;

    void Start()
    {
        _cameramovement = _cameraObj.GetComponent<cameraMovement>();
    }

    public void StartButtonAction()
    {
        //_cameramovement.canIMove = true;
        _canvasObj.SetActive(false);


    }
}
