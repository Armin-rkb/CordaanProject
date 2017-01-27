using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour
{

    private bool _arrived = false;

    public bool arrived
    {
        set { _arrived = value; }
        get { return _arrived; }
    }

    private bool _shouldIMove = false;
    private bool _shouldIRotate = false;
    private bool _shouldIZoom = false;


    public delegate void MoveCameraAction();
    public static event MoveCameraAction onMoveCamera;

    public delegate void RotationCameraAction();
    public static event RotationCameraAction onRotationCamera;

    public delegate void ZoomCameraAction();
    public static event ZoomCameraAction onZoom;

    void Start()
    {
        StartCoroutine(CameraEvents());

    }

    void Update()
    {
        if (_shouldIMove) onMoveCamera();
        if (_shouldIRotate) onRotationCamera();
        if (_shouldIZoom) onZoom();
    }

    IEnumerator CameraEvents()
    {
        _shouldIMove = true;
        _shouldIRotate = true;


        yield return new WaitUntil(() => _arrived == true);
        _shouldIMove = false;
        yield return new WaitForSeconds(1f);
        _shouldIRotate = false;
           
        _shouldIZoom = true;
        yield return new WaitForSeconds(6f);

        _shouldIZoom = false;
        _arrived = false;

        StartCoroutine(CameraEvents());
     }

}
