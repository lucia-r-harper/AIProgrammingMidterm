using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class VisionCone : MonoBehaviour
{
    public ShoutZone shoutZone;
    AIStateManager aiCharacter;
    WaitForSeconds memory = new WaitForSeconds(3);

    Vector3 longerVisionConePosition;
    Vector3 longerVisionConeScale;

    Vector3 originalVisionConePosition;
    Vector3 originalVisionConeScale;
    private void Start()
    {
        aiCharacter = GetComponentInParent<AIStateManager>();
        longerVisionConePosition = new Vector3(transform.position.x, transform.position.y, (transform.position.z*2));
        longerVisionConeScale = new Vector3(transform.localScale.x, (transform.localScale.y * 2), transform.localScale.z);

        originalVisionConePosition = transform.position;
        originalVisionConeScale = transform.localScale;
    }

    private void ChangeToLongerCone()
    {
        transform.position = longerVisionConePosition;
        transform.localScale = longerVisionConeScale;
    }

    private void ChangeToRegularCone()
    {
        transform.position = originalVisionConePosition;
        transform.localScale = originalVisionConeScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(ForgetPlayer());
            if (aiCharacter.CurrentAIState != AIState.Chasing)
            {
                //Change AIState once a player is in the Vision field of vision
                aiCharacter.SetAIState(AIState.Chasing);
                GetComponentInParent<AIChasing>().SetTargetToChase(other.transform);
                //ChangeToLongerCone();
                shoutZone.AlertNearbyAgents(other.transform);
            }
            //the AI is still chasing, but checking to see if player is still within their visioncone
            else
            {
                GetComponentInParent<AIChasing>().IsTargetStillInView = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //GetComponentInParent<AIChasing>().MomentPlayerLeftVision = Time.deltaTime;
            StartCoroutine(ForgetPlayer());
        }
    }

    private IEnumerator ForgetPlayer()
    {
        yield return memory;
        GetComponentInParent<AIChasing>().IsTargetStillInView = false;
        //ChangeToRegularCone();
    }
}
