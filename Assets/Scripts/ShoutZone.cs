using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutZone : MonoBehaviour
{
    private SphereCollider shoutZoneTrigger;
    private List<AIStateManager> nearbyAIAgents;
	// Use this for initialization
	void Start ()
    {
        shoutZoneTrigger = GetComponent<SphereCollider>();
        nearbyAIAgents = new List<AIStateManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void AlertNearbyAgents(Transform t)
    {
        foreach (AIStateManager agent in nearbyAIAgents)
        {
            agent.SetAIState(AIState.Chasing);
            agent.GetComponent<AIChasing>().SetTargetToChase(t);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<AIStateManager>())
        {
            nearbyAIAgents.Add(collision.gameObject.GetComponent<AIStateManager>());
            //Debug.Log("Agent added!");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<AIStateManager>())
        {
            nearbyAIAgents.Remove(collision.gameObject.GetComponent<AIStateManager>());
            //Debug.Log("Agent removed!");
        }
    }
}
