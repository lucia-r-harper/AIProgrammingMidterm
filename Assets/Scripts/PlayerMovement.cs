using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string HorizontalInputAxis;
    public string VerticalInputAxis;

    private float horizontalInputValue;
    private float verticalInputValue;
    private Vector3 inputVector = new Vector3();

    private float speed = 1;
    private float angle;

    private Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateInputValues();
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void UpdateInputValues()
    {
        horizontalInputValue = (Input.GetAxis(HorizontalInputAxis));
        verticalInputValue = (Input.GetAxis(VerticalInputAxis));

        inputVector.x = horizontalInputValue * speed;
        inputVector.z = verticalInputValue * speed;
        inputVector.y = 0;

        angle = Mathf.Atan2(inputVector.x, inputVector.z) * Mathf.Rad2Deg;
        this.transform.eulerAngles = new Vector3(0, angle, 0);
    }

    private void Move()
    {
        //transform.Translate(horizontalInputValue * speed, 0, verticalInputValue * speed);
        rigidbody.MovePosition(this.transform.position + inputVector);
    }
}
