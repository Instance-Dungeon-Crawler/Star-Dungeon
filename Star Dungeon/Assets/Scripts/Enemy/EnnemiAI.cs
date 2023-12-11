using System.Collections.Generic;
using UnityEngine;

public class EnnemiAI : MonoBehaviour
{
    public Transform[] _waypoints;
    private Node NodeStart;
    public GameObject _player;

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
                          new NodeMoveToPlayer(transform, _player),
                          new NodeStartCombat(transform, _player)
                      }),
                  }),
              }),
            //default behavior of patrolling between waypoints
            new NodePatrol(transform,_waypoints)
        }) ; 
    }

    private void Update()
    {
        NodeStart.Evaluate();
    }
}
