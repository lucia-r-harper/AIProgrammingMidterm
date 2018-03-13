using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolling : AIMovement {

    public enum PatrolState { atHome, atAway};

    //AI should patrol beteween these two home nodes
    private AINode homeNode;
    private AINode awayNode;

    private List<AINode> nodesToPatrol;
    private AINode[] nodesToPatrolArray;
    private AINode targetNode;

    private const float stepSpeed = 5;
    private const float turnSpeed = 6;

    PatrolState patrolState = PatrolState.atAway;

	// Use this for initialization
	void Start ()
    {
        nodesToPatrol = GetComponentInParent<AIStateManager>().NodesToPatrol;
        targetNode = nodesToPatrol[0];
        homeNode = nodesToPatrol[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateTargetNode();
        PatrolToNewNode(targetNode);
    }

    private void UpdateTargetNode()
    {
        foreach (AINode node in nodesToPatrol)
        {
            //Debug.Log(nodeIndex);

            if (transform.position == node.transform.position)
            {

                if ((nodesToPatrol.IndexOf(node) + 1) == nodesToPatrol.Count)
                {
                    //Debug.Log("hello!");
                    targetNode = homeNode;
                }
                else
                {
                    targetNode = nodesToPatrol[nodesToPatrol.IndexOf(node) + 1];
                }

            }
            //nodeIndex++;
        }
    }

    /// <summary>
    /// Used in the state manager to set the Nodes
    /// </summary>
    public void SetHomeAndAwayNodes(AINode home, AINode away)
    {
        homeNode = home;
        awayNode = away;
    }

    void PatrolToNewNode(AINode nodeToPatrolTo)
    {
        //first, set transform equal to the first AI node.
        //Second, move in between the two nodes, rotating between each one

        //Looks at the home node so they look where they're walking
        float step = stepSpeed * Time.deltaTime;
        float turn = turnSpeed * Time.deltaTime;

        Vector3 targetDir = nodeToPatrolTo.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, turnSpeed, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDir), Time.deltaTime * turnSpeed);

        if (transform.rotation == Quaternion.LookRotation(newDir))
        {
            Debug.Log("hello!");
            transform.position = Vector3.MoveTowards(gameObject.transform.position, nodeToPatrolTo.transform.position, step);
        }
    }
}
