using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

    [SerializeField]
    private float _maxSpeed = 5;
    [SerializeField]
    private float _mass = 20;

    private Vector3 _currentVelocity = new Vector3(0,0,0);
    private Vector3 _currentPosition;
    private Vector3 _currentTarget;
    private Quaternion _currentRotation;


	// Use this for initialization
	void OnEnable () {
        _currentPosition = transform.position;

	    CameraBehaviour.onMoveCamera += Movement;
	}

    public void SetTarget(Vector3 target)
    {
        _currentTarget = target;
    }

    void Movement()
    {
        Vector3 desiredStep = _currentTarget - _currentPosition;

        desiredStep.Normalize();

        Vector3 desiredVelocity = desiredStep * _maxSpeed;

        Vector3 steeringForce = desiredVelocity - _currentVelocity;

        _currentVelocity += steeringForce / _mass;

        _currentPosition += _currentVelocity * Time.deltaTime;

        transform.position = _currentPosition;

    }

}
