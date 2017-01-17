using UnityEngine;
using System.Collections;

public class waypointsFollower : MonoBehaviour {

    [SerializeField]
    private GameObject[] _waypoints;
    private int _waypointCounter = 0;

    private Vector3 _targetWaypoint;

    private cameraMovement _cameraMovement;
    void Start()
    {
        _cameraMovement = GetComponent<cameraMovement>();
    }
    void Update()
	{
		if (_waypointCounter < _waypoints.Length) {
			WaypointTracker ();
		}
	}

	void WaypointTracker()
	{
		
			_targetWaypoint = _waypoints [_waypointCounter].transform.position;
			float distanceToWaypoint = (this.transform.position - _targetWaypoint).magnitude;

			_cameraMovement.SetTarget (_targetWaypoint);

			if (distanceToWaypoint < 0.02)
        {
				_waypointCounter += 1;

			print ("Arrived");
			//send arrived message
			_cameraMovement.StartCoroutine();
            
            
            if (_waypointCounter >= _waypoints.Length)
            {
                _waypointCounter = 0;
            }
        }
	}
}
