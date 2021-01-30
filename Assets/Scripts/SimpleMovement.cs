using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour {

    public float movementSpeed = 3f;
	
	private Rigidbody2D rigidbody2d;
	private void Awake()
	{
		rigidbody2d = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);
		
	}
}
