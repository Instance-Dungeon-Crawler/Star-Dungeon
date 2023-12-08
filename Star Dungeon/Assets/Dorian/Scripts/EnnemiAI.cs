using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiAI : MonoBehaviour
{
    public UnityEngine.Transform[] _waypoints;
    private Node NodeStart;
    public GameObject _player;

    private void Start()
    {
        NodeStart = new Selector(new List<Node>
        {
              new Sequence(new List<Node>
                {
                  new NodeSeePlayer(transform, _player),
                  new Selector(new List<Node>
                  {
                      new Sequence(new List<Node>
                      {
        //                new NodeDistanceCheck()
        //                new NodeMoveToPlayer()
        //                new NodeStartCombat()
                      }),
                  }),
              }),
            new NodePatrol(transform,_waypoints)
        }) ; 
    }

    private void Update()
    {
        NodeStart.Evaluate();
    }
}
