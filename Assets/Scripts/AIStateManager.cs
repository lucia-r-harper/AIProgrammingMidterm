﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState { Chasing, Patroling}
public class AIStateManager : MonoBehaviour
{
    private AIState aiState;
	// Use this for initialization
	void Start ()
    {
        SetAIState(AIState.Patroling);

    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (aiState)
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
                break;
            default:
                break;
        }
    }

    public void SetAIState(AIState newState)
    {
        aiState = newState;
        RemoveAIBehaviours();
        AddMovementBehaviour(newState);
    }

}