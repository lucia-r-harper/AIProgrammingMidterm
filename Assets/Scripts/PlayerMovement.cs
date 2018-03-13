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

    private float speed = 10f;
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
        Move();
    }

    private void FixedUpdate()
    {
        
    }

    private void UpdateInputValues()
    {
        horizontalInputValue = (Input.GetAxis(HorizontalInputAxis));
        verticalInputValue = (Input.GetAxis(VerticalInputAxis));

        inputVector.x = horizontalInputValue * speed;
        inputVector.z = verticalInputValue *speed;
        inputVector.y = 0;

        angle = Mathf.Atan2(inputVector.x, inputVector.z) * Mathf.Rad2Deg;
        this.transform.eulerAngles = new Vector3(0, angle, 0);
    }

    private void Move()
    {
        //transform.Translate(horizontalInputValue * speed, 0, verticalInputValue * speed);

        //Vector3 direction = (inputVector).normalized;

        //rigidbody.MovePosition(direction * speed * Time.deltaTime);

        rigidbody.MovePosition(Vector3.Lerp((this.transform.position), (this.transform.position + inputVector), Time.deltaTime * speed));
    }
}
