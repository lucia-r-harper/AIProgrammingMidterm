using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform Target;
    public Vector3 TargetFollowDistance;
    private const float followSpeed = 2;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, (Target.position + TargetFollowDistance), Time.deltaTime * followSpeed);
	}
}
