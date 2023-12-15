using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiAI : MonoBehaviour
{
    public PlayerMovement _playerMovement;
    public Transform[] _waypoints;
    private Node NodeStart;
    public GameObject _player;
    public Animator _animator;
    public NavMeshAgent _agent;

    private void Start()
    {
        NodeStart = new Selector(new List<Node>
        {
              new Sequence(new List<Node>
                {
                  //check if the Ennemi see the player
                  new NodeSeePlayer(transform, _player),
                  new Selector(new List<Node>
                  {
                      new Sequence(new List<Node>
                      {
                          //if player is seen move to him and start combat once player is reached
                          new NodeMoveToPlayer(transform, _player, _playerMovement),
                          new NodeStartCombat(transform, _player)
                      }),
                  }),
              }),
            //default behavior of patrolling
            new NodePatrol(transform,_player, _playerMovement, _animator, _agent)
        }) ; 
    }

    private void Update()
    {
        NodeStart.Evaluate();
    }
}
