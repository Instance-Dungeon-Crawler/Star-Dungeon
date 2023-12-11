using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeStartCombat : Node
{
    private Transform _transform;
    private GameObject _player;

    public NodeStartCombat(Transform transform, GameObject player)
    {
        _transform = transform;
        _player = player;
    }

    //load the scene where the fight will happen
    public override NodeState Evaluate()
    {
        if (_transform.position == _player.transform.position)
        {
            SceneManager.LoadScene("Battle");
        }
        return nodeState;
    }
}
