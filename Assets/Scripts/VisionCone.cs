using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class VisionCone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Change AIState once a player is in the Vision field of vision
        GetComponentInParent<AIStateManager>().SetAIState(AIState.Chasing);
    }
}
