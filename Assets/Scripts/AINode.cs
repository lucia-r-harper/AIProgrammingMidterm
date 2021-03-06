﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINode : MonoBehaviour {

    //public bool wasPlayerOccupyingThisNode;
    //public List<AINode> NeighbourNodes = new List<AINode>();
    //public AINode nextNodeInPath;
    public AINode NextNodeInPath;
    public AINode PreviousNodeInPath;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    void DirectActionToNode()
    {
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //if (nextNodeInPath != null)
        //{
        //    Gizmos.DrawLine(transform.position, nextNodeInPath.transform.position);
        //}
        if (NextNodeInPath != null)
        {
            Gizmos.DrawLine(transform.position, NextNodeInPath.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AIPatrolling>())
        {
            //if (nextNodeInPath != null)
            //{
            //    other.GetComponent<AIPatrolling>().SetNewTargetNode(nextNodeInPath);
            //}
            //else
            //{
            //    other.GetComponent<AIPatrolling>().SetNewTargetNode(NextNodeInPath);
            //}
            if (NextNodeInPath == null)
            {
                other.GetComponent<AIPatrolling>().GoHome();
            }
            other.GetComponent<AIPatrolling>().SetNewTargetNode(NextNodeInPath);
        }
    }
}
