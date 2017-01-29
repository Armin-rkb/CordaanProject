using UnityEngine;
using System.Collections;

public class waypointsFollower : MonoBehaviour {

    [SerializeField]
    private GameObject[] _waypoints;
    private int _waypointCounter = 0;

    private Vector3 _targetWaypoint;
    private Quaternion _targetWaypointRotation;
    private cameraMovement _cameraMovement;
    private CameraBehaviour _cameraBehaviour;

    [SerializeField] private GameObject _sceneSwitchGameObj;
    
    private int _amountOfRounds = 0;
    [SerializeField] private int _maxRounds = 5;
    [SerializeField] private string _sceneName = "RecognitionScene";

    void Start()
    {
        _cameraMovement = GetComponent<cameraMovement>();
        _cameraBehaviour = GetComponent<CameraBehaviour>();
    }
    void Update()
	{
			WaypointTracker ();
	}

	void WaypointTracker()
	{
	    if (_cameraBehaviour.arrived != true)
	    {
	        _targetWaypoint = _waypoints[_waypointCounter].transform.position;
	        _targetWaypointRotation = _waypoints[_waypointCounter].transform.rotation;

	        float distanceToWaypoint = (this.transform.position - _targetWaypoint).magnitude;

	        _cameraMovement.SetTarget(_targetWaypoint);
	        _cameraMovement.GetComponent<CameraRotation>().SetTarget(_targetWaypointRotation);

	        if (distanceToWaypoint < 0.1f)
	        {
	            _cameraBehaviour.arrived = true;

	            _waypointCounter += 1;
	            if (_waypointCounter >= _waypoints.Length)
	            {
	                _amountOfRounds++;
	                _waypointCounter = 0;


                    if (_amountOfRounds >= _maxRounds)
                        _sceneSwitchGameObj.GetComponent<SceneSwitch>().TransitionToScene(_sceneName,true,false,2f);
                        
	            }
	        }
	    }
	}
}
