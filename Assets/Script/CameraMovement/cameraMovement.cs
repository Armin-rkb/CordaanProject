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

	[SerializeField]
    private bool _canIMove = false;

    public bool canIMove
    {
        set { _canIMove = value; }
    }
	// Use this for initialization
	void Start () {
        _currentPosition = transform.position;
	}

    public void SetTarget(Vector3 target)
    {
        _currentTarget = target;

    }

	public void StartCoroutine()
	{
        StartCoroutine(LookingTime(3f));

    }
	void Update () {
		if (_canIMove) {
			Movement();
		}
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

	IEnumerator LookingTime(float waitTime)
	{
		print ("LookingTime");
	//	yield return new WaitForSeconds (0.2f);
		_canIMove = false;
		print ("Stopped");
		yield return new WaitForSeconds (waitTime);
		_canIMove = true;
		print ("Moving Again");
	}
}
