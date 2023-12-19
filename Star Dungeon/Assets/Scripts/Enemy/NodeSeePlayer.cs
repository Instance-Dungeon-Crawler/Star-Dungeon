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
        RaycastHit hit;
        if (angle < 90 && Physics.Raycast(new Vector3(_transform.position.x, _transform.position.y + 2, _transform.position.z), targetDir,out hit,15))
        {
            if (hit.collider.tag == "Player")
            {
                return NodeState.SUCCESS;
            }
            else
            {
                return NodeState.FAILURE;
            }
        }
        else
        {
            return NodeState.FAILURE;
        }
    }
}
