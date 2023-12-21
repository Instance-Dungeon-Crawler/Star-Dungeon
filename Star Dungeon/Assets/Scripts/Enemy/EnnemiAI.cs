using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiAI : MonoBehaviour
{
    private Node NodeStart;
    public GameObject _player;
    public Animator _animator;
    public NavMeshAgent _agent;
    public Transform _startPos;

    private void Awake()
    {
        _startPos = transform;
    }
    private void Start()
    {
        NodeStart = new Selector(new List<Node>
        {
              new Sequence(new List<Node>
              {
                  //check if the Ennemi see the player
                new NodeSeePlayer(transform, _player),

                new Sequence(new List<Node>
                {
                //if player is seen move to him and start combat once player is reached
                    new NodeMoveToPlayer(transform, _player, _animator, _agent),
                    new NodeStartCombat(transform, _player),
                }),
              }),
            //default behavior of patrolling
            new NodePatrol(transform, _animator, _agent)
        }) ; 
    }

    private void Update()
    {
        NodeStart.Evaluate();
    }
}
