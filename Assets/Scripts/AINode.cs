using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINode : MonoBehaviour {

    public bool wasPlayerOccupyingThisNode;
    public List<AINode> NeighbourNodes = new List<AINode>();
    public AINode nextNodeInPath;

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
        for (int i = 0; i < NeighbourNodes.Count; i++)
        {
            if (NeighbourNodes[i].wasPlayerOccupyingThisNode == true)
            {
                //return the transform of this node to the AI Actor as a waypoint to go to
            }
        }
    }

    void OnDrawGizmos()
    {
        foreach (AINode node in NeighbourNodes)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, node.transform.position);
        }
    }
}
