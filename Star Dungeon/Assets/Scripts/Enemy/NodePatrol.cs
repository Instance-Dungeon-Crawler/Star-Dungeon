using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.UI.Image;

public class NodePatrol : Node
{
    private Transform _transform;
    private Animator _Animator;
    private float _timer = 0; 
    private NavMeshAgent _Agent;
    RaycastHit hit;
    

    public NodePatrol(Transform transform, Animator _animator, NavMeshAgent agent)
    {
        _transform = transform;
        _Animator = _animator;
        _Agent = agent;
    }

    public override NodeState Evaluate()
    {
        _timer -= Time.deltaTime;
        if (Physics.Raycast(new Vector3(_transform.position.x, _transform.position.y + 2, _transform.position.z), _transform.forward, out hit,5))
        {
            if ((hit.collider.name == "Wall" || hit.collider.name == "Door" ||hit.collider.name == "CloseDoor") && _Agent.velocity.magnitude <= 0)
            {
                _transform.rotation = Quaternion.Euler(0, _transform.eulerAngles.y + 90f,0);
            }
        }
        if (_timer <= 0 && _Agent.velocity.magnitude <= 0)
        {
            float _forx = Mathf.Round(_transform.forward.x*5*10)*0.1f;
            float _fory = Mathf.Round(_transform.forward.y * 5 * 10) * 0.1f;
            float _forz = Mathf.Round(_transform.forward.z * 5 * 10) * 0.1f;
            Vector3 _tarforward = new Vector3(_forx, _fory, _forz);
            _Agent.SetDestination(_transform.position + _tarforward);
            _Animator.SetBool("IsWalking", true);
            _timer = 2;
        }
        else if (_Agent.velocity.magnitude <= 0)
        {
            _Animator.SetBool("IsWalking", false);
        }
        return NodeState.RUNNING;
    } 
}