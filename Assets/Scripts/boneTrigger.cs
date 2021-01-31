using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boneTrigger : MonoBehaviour
{
    public float slowingSpeed = 2.0f;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LocalPlayer slowdown = other.gameObject.GetComponent("LocalPlayer") as LocalPlayer;
            slowdown.SlowDown(slowingSpeed);
        }
    }
    void OnTriggerExit(Collider other)
	{
        if (other.tag == "Player")
		{
            LocalPlayer resetspeed = other.gameObject.GetComponent("LocalPlayer") as LocalPlayer;
            resetspeed.ResetSpeed();

        }


	}
}
