using UnityEngine;
using UnityEngine.AI;

public class NodeMoveToPlayer : Node
{
    private Transform _transform;
    private Animator _animator;
    private GameObject _player;
    private NavMeshAgent _agent;
    private float _speed = 10f;
    private PlayerMovement _playerMovements;
    public NodeMoveToPlayer(Transform transform, GameObject player, Animator _Animator, NavMeshAgent _Agent)
    {
        _transform = transform;
        _player = player;
        _animator = _Animator;
        _agent = _Agent;
    }
    public override NodeState Evaluate()
    {
        //make the AI look at the player and move to him
        Vector3 targetDir = _player.transform.position - _transform.position;
        if (_transform.position != _player.transform.position && !_playerMovements._canMove)
        {
            _transform.LookAt(_player.transform);
            _transform.position = Vector3.MoveTowards(_transform.position, _player.transform.position, _speed * Time.deltaTime);
            return NodeState.RUNNING;
        }
        //return SUCCESS if player is reached
        else if (Vector3.Distance(_transform.position, _player.transform.position) <= 1f)
        {
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }

    }
}
