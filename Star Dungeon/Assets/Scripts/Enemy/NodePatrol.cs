using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;

public class NodePatrol : Node
{
    private Transform _transform;
    private GameObject _player;
    private float _speed = 5f;
    private PlayerMovement _playerMovement;
    private Animator _Animator;
    private float _timer = 0; 
    private NavMeshAgent _Agent;
    RaycastHit hit;
    

    public NodePatrol(Transform transform, GameObject player, PlayerMovement _movements, Animator _animator, NavMeshAgent agent)
    {
        _transform = transform;
        _player = player;
        _playerMovement = _movements;
        _Animator = _animator;
        _Agent = agent;
    }

    public override NodeState Evaluate()
    {
        _timer -= Time.deltaTime;
        if (Physics.Raycast(new Vector3(_transform.position.x, _transform.position.y + 2, _transform.position.z), _transform.forward, out hit,3))
        {
            if (hit.collider.name == "Wall")
            {
                _transform.Rotate(_transform.rotation.x, _transform.rotation.y+90,_transform.rotation.z);
            }
        }
        if (_timer <= 0)
        {
            _Agent.SetDestination(_transform.forward*3);
            _timer = 1;
        }
        return NodeState.RUNNING;
    } 
}