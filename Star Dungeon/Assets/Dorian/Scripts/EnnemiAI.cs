using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiAI : MonoBehaviour
{
    public UnityEngine.Transform[] waypoints;
    private Node NodeStart;

    private void Start()
    {
        NodeStart = new Selector(new List<Node>
        {
            /*new Sequence(new List<Node>
            {
                new NodeSeePlayer(),
                new Selector(new List<Node>
                {
                    new Sequence(new List<Node>
                    {
                        new NodeDistanceCheck()
                        new NodeMoveToPlayer()
                        new NodeStartCombat()
                    }),

                })
            }),*/
            new NodePatrol(transform,waypoints)
        }) ; 
    }

    private void Update()
    {
        NodeStart.Evaluate();
    }
}
