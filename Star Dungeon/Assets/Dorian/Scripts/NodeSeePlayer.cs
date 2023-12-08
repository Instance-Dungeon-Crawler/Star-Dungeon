using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class NodeSeePlayer : Node
{
    private Transform _transform;
    private GameObject _player;
    public NodeSeePlayer(Transform transform, GameObject player)
    {
        _transform = transform;
        _player = player;
    }

    public override NodeState Evaluate()
    {
        Vector3 targetDir = _player.transform.position - _transform.position;
        float angle = Vector3.Angle(targetDir, _transform.forward);
        if (angle < 90 && Vector3.Magnitude(targetDir)<15)
        {
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
