using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiAI : MonoBehaviour
{
    private float speed = 3.5f;
    private Transform waypoints;
    private Transform target;

    private Node NodeStart;

    private void Start()
    {
        NodeStart = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new NodSeePlayer(target,Agent,DetectionRadius)
                new Selector(new List<Node>
                {
                    new Sequence(new List<Node>
                    {
                        new NodDistanceCheck(target,agent)
                                            new NodMoveToPlayer(target,agent)
                                            new NodMoveToPlayer(target,agent)
                    }),

                })
            }),
            new Patrol(transform,speed,waypoints, agent)
        });
    }

    private void Update()
    {
        NodeStart.Evaluate();
    }
}
