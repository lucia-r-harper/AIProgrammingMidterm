using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChasing : AIMovement
{
    private Transform target;
    private const float stepSpeed = 7;
    private const float turnSpeed = 8;

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
    }


    public void SetTargetToChase(Transform targetToSet)
    {
        target = targetToSet;
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
