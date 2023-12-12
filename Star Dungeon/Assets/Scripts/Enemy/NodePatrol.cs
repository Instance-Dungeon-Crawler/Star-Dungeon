using Unity.VisualScripting;
using UnityEngine;

public class NodePatrol : Node
{
    private Transform _transform;
    private Transform[] _waypoints;
    private GameObject _player;
    private int _currentWaypointIndex = 0;
    private float _speed = 10f;
    private CameraRotation _cameraRotation;



    public NodePatrol(Transform transform, Transform[] waypoints, GameObject player,CameraRotation _camera)
    {
        _transform = transform;
        _waypoints = waypoints;
        _player = player;
        _cameraRotation = _camera;

    }

    public override NodeState Evaluate()
    {
        //make AI patrol between multiple waypoints
        Transform wp = _waypoints[_currentWaypointIndex];
        if (Vector3.Distance(_transform.position, wp.position) < 0.01f)
        {
            _transform.position = wp.position;
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
        else if(!_cameraRotation._canRotate)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, wp.position, _speed * Time.deltaTime);
            _transform.LookAt(_player.transform);
        }
        return NodeState.RUNNING;
    } 
}

    

