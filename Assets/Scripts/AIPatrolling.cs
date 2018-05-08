using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolling : AIMovement
 {

    public enum PatrolState { atHome, atAway};
    private enum PathFollowState { GoToNextNode, GoToPreviousNode};
    private PathFollowState pathFollowState = PathFollowState.GoToNextNode;

    //Set nodeToMoveTowards to me when there is no next node in path
    //OR
    //when moving from chasing back to patroling
    private AINode homeNode;

    //AI should patrol beteween these two home nodes
    private AINode nodeToMoveTowards;

    private AINode targetNode;

    private const float stepSpeed = 5;
    private const float turnSpeed = 6;

    PatrolState patrolState = PatrolState.atAway;

	// Use this for initialization
	void Start ()
    {
        //nodesToPatrol = GetComponentInParent<AIStateManager>().NodesToPatrol;
        nodeToMoveTowards = GetComponentInParent<AIStateManager>().Home;
        homeNode = GetComponentInParent<AIStateManager>().Home;
        targetNode = nodeToMoveTowards;
	}
	
	// Update is called once per frame
	void Update ()
    {
        IdlePatrolState();
    }

    /// <summary>
    /// Used in the state manager to set the Nodes
    /// </summary>
    public void SetHomeNode(AINode home)
    {
        nodeToMoveTowards = home;
        //awayNode = away;
    }

    public void SetNewTargetNode(AINode newTargetNode)
    {
        targetNode = newTargetNode;
    }

    public void GoHome()
    {
        nodeToMoveTowards = homeNode;
    }

    void IdlePatrolState()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, nodeToMoveTowards.transform.position, Time.deltaTime * turnSpeed);

        Vector3 targetDir = nodeToMoveTowards.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, turnSpeed, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDir), Time.deltaTime * turnSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NodeTrigger")
        {
            if (other.GetComponent<AINode>().NextNodeInPath == null)
            {
                pathFollowState = PathFollowState.GoToPreviousNode;
            }
            if (other.GetComponent<AINode>().PreviousNodeInPath == null)
            {
                pathFollowState = PathFollowState.GoToNextNode;
            } 
            switch (pathFollowState)
            {
                case PathFollowState.GoToNextNode:
                    nodeToMoveTowards = other.GetComponent<AINode>().NextNodeInPath;
                    break;
                case PathFollowState.GoToPreviousNode:
                    nodeToMoveTowards = other.GetComponent<AINode>().PreviousNodeInPath;
                    break;
                default:
                    break;
            }
        }
    }
}
