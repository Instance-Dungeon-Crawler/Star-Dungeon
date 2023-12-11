using UnityEngine;

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
        //check if the player is line of sight
        Vector3 targetDir = _player.transform.position - _transform.position;
        float angle = Vector3.Angle(targetDir, _transform.forward);
        if (angle < 90 && Vector3.Distance(_transform.position, _player.transform.position) < 15)
        {
            return NodeState.SUCCESS;
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
