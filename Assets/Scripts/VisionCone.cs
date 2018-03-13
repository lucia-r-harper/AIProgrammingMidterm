﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class VisionCone : MonoBehaviour
{
    AIStateManager aiCharacter;
    private void Start()
    {
        aiCharacter = GetComponentInParent<AIStateManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && aiCharacter.CurrentAIState != AIState.Chasing)
        {
            //Change AIState once a player is in the Vision field of vision
            aiCharacter.SetAIState(AIState.Chasing);
            GetComponentInParent<AIChasing>().SetTargetToChase(other.transform);
        }
    }
}
