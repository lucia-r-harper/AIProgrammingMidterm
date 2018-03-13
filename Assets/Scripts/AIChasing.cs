using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChasing : AIMovement
{
    private Transform target;
    private const float stepSpeed = 7;
    private const float turnSpeed = 8;

    //this value is set in order to count the frame when the player was caught so after a certain amount of time, the target will be set to null
    private float momentPlayerLeftVision;
    private float timeSincePlayerLeftVision;
    private const float secondsUntilAIMustResumePatroling = 2;

    private bool isTargetStillInView = true;

    public bool IsTargetStillInView
    {
        set
        {
            isTargetStillInView = value;
        }
    }

    public float MomentPlayerLeftVision
    {
        set
        {
            momentPlayerLeftVision = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target != null)
        {
            Chase();
        }
        if (isTargetStillInView == false)
        {
            UpdateTimeOutOfVision();
        }
    }

    private void UpdateTimeOutOfVision()
    {
        timeSincePlayerLeftVision = (Time.deltaTime + timeSincePlayerLeftVision);
        Debug.Log((timeSincePlayerLeftVision));
        if (timeSincePlayerLeftVision >= secondsUntilAIMustResumePatroling)
        {
            GetComponent<AIStateManager>().SetAIState(AIState.Patroling);
        }
    }

    public void SetTargetToChase(Transform targetToSet)
    {
        target = targetToSet;
        momentPlayerLeftVision = Time.deltaTime;
    }

    private void Chase()
    {
        float step = stepSpeed * Time.deltaTime;
        float turn = turnSpeed * Time.deltaTime;

        Vector3 targetDir = target.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, turnSpeed, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newDir), Time.deltaTime);

        //transform.LookAt(nodeToPatrolTo.transform);

        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, step);
    }
}
