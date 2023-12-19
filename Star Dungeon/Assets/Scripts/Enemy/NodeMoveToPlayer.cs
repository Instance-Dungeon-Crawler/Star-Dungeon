using UnityEngine;
using UnityEngine.AI;

public class NodeMoveToPlayer : Node
{
    private Transform _transform;
    private Animator _animator;
    private GameObject _player;
    private NavMeshAgent _agent;
    private float _timer;
    private PlayerMovement _playerMovements;
    public NodeMoveToPlayer(Transform transform, GameObject player, Animator _Animator, NavMeshAgent _Agent)
    {
        _transform = transform;
        _player = player;
        _animator = _Animator;
        _agent = _Agent;
    }

    private void Move()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Debug.Log("hello");
            float _forx = Mathf.Round(_transform.forward.x * 5 * 10) * 0.1f;
            float _fory = Mathf.Round(_transform.forward.y * 5 * 10) * 0.1f;
            float _forz = Mathf.Round(_transform.forward.z * 5 * 10) * 0.1f;
            Vector3 _tarforward = new Vector3(_forx, _fory, _forz);
            _agent.SetDestination(_transform.position + _tarforward);
            _animator.SetBool("IsWalking", true);
            _timer = 2;
        }
        else if (_agent.velocity.magnitude <= 0)
        {
            _animator.SetBool("IsWalking", false);
        }
    }
    public override NodeState Evaluate()
    {
        //make the AI look at the player and move to him
        Vector3 targetDir = _player.transform.position - _transform.position;
        if (_transform.position != _player.transform.position)
        {
            if (_player.transform.position.x != _transform.position.x) 
            {
                if (_player.transform.position.x < _transform.position.x && _agent.velocity.magnitude <= 0)
                {
                    _transform.rotation = Quaternion.Euler(0, -90f, 0);
                    Move();
                }
                else if (_player.transform.position.x > _transform.position.x && _agent.velocity.magnitude <= 0)
                {
                    _transform.rotation = Quaternion.Euler(0, 90f, 0);
                    Move();
                }
            }
            
            else if(_player.transform.position.z != _transform.position.z) 
            {
                if (_player.transform.position.z < _transform.position.z && _agent.velocity.magnitude <= 0)
                {
                    Debug.Log("test");
                    _transform.rotation = Quaternion.Euler(0, 180f, 0);
                    Move();
                }
                else if (_player.transform.position.z > _transform.position.z && _agent.velocity.magnitude <= 0)
                {
                    _transform.rotation = Quaternion.Euler(0, 0, 0);
                    Move();
                }

            }
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
