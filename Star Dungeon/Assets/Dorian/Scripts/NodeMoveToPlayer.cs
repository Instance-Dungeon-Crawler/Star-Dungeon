using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeMoveToPlayer : Node
{
    private Transform _transform;
    private GameObject _player;
    private float _speed = 10f;
    public NodeMoveToPlayer(Transform transform, GameObject player)
    {
        _transform = transform;
        _player = player;
    }
    public override NodeState Evaluate()
    {
        if (_transform.position != _player.transform.position)
        {
            _transform.LookAt(_player.transform);
            _transform.position = Vector3.MoveTowards(_transform.position, _player.transform.position, _speed * Time.deltaTime);
            return NodeState.RUNNING;
        }
        else if (_transform.position == _player.transform.position)
        {
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }

    }
}
