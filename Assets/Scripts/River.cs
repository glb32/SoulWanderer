using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public float thrust = 1.0f;
    public Rigidbody rb;
    public bool isInCurrent = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Entered Collider!");
            isInCurrent = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInCurrent = false;

        }
    }
    void FixedUpdate()
	{
        if(isInCurrent == true)
		{
            Debug.Log("applying force!");
            rb.AddForce(transform.forward * thrust);

        }

	}
}