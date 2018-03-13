using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState { Chasing, Patroling}
public class AIStateManager : MonoBehaviour
{
    public AINode Home;
    public AINode Away;

    public List<AINode> NodesToPatrol;

    private AIState currentAIState;
    public AIState CurrentAIState
    {
        get
        {
            return currentAIState;
        }
    }
	// Use this for initialization
	void Start ()
    {
        SetAIState(AIState.Patroling);

    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (currentAIState)
        {
            case AIState.Chasing:
                break;
            case AIState.Patroling:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Removes all associated AI behaviours
    /// </summary>
    private void RemoveAIBehaviours()
    {
        Destroy(GetComponent<AIMovement>());
    }

    /// <summary>
    /// Adds a movement behaviour determined by the newStateOfMovement parameter
    /// </summary>
    /// <param name="newStateOfMovement"></param>
    private void AddMovementBehaviour(AIState newStateOfMovement)
    {
        switch (newStateOfMovement)
        {
            case AIState.Chasing:
                this.gameObject.AddComponent<AIChasing>();
                break;
            case AIState.Patroling:
                this.gameObject.AddComponent<AIPatrolling>();
                this.gameObject.GetComponent<AIPatrolling>().SetHomeAndAwayNodes(Home, Away);
                break;
            default:
                break;
        }
    }

    public void SetAIState(AIState newState)
    {
        currentAIState = newState;
        RemoveAIBehaviours();
        AddMovementBehaviour(newState);
    }

}
