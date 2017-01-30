using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{

    private Quaternion _newRotation;
    [SerializeField] private float _speed = 1.3f;


    public void SetTarget(Quaternion target)
    {
     
        _newRotation = target;
    }

    void OnEnable()
    {
        CameraBehaviour.onRotationCamera += Rotation;
    }

    void Rotation()
    {
        transform.rotation = Quaternion.Lerp(this.transform.rotation, _newRotation, Time.deltaTime * _speed);

    }
    void OnDestroy()
    {
        CameraBehaviour.onRotationCamera -= Rotation;
    }
}
