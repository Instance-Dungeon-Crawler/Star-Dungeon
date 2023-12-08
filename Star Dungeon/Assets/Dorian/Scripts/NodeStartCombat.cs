using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public override NodeState Evaluate()
    {
        if (_transform.position == _player.transform.position)
        {
            SceneManager.LoadScene("FightScene");
        }
        return nodeState;
    }
}
