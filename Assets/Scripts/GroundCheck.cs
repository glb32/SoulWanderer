using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float groundedHeight = 1f; // the height above ground to determine if the player is grounded
    public float checkRate = 1.0f; // how often in seconds we check to see if we are grounded
    public bool grounded = false;// is grounded or not
    public LayerMask groundLayer;//the layer on which we can be grounded
    public static float CountdownTime = 3.5f;
    public float TimerTime = CountdownTime;
    

    void Start()

    {
        InvokeRepeating("Groundcheck", 0, checkRate);
    }
    void Groundcheck()
    {

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.down, groundedHeight, groundLayer))
        {
            grounded = true;
            Debug.Log("Grounded");
        }
        else
        {
            grounded = false;
            Debug.Log("Not Grounded");
        }
    }
    void Update()

    {
        if (grounded == false)
        {
            Debug.Log("Timer Started");
            if (TimerTime > 0)
            {
                TimerTime -= Time.deltaTime;
            }
            if (TimerTime == 0)
            {
                Debug.Log("Time Has Run Out!");
            }
		}
		else if(TimerTime < CountdownTime && grounded == true)
		{
            TimerTime = CountdownTime;
            Debug.Log("Timer has been reset!");

		}
    }
    
}
