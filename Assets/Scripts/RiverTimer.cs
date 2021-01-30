using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverTimer : MonoBehaviour
{
	
	public float TimerTime = 2.5f;
	void update(bool onGround) {
		if (onGround == false)
		{
			if (TimerTime > 0)
			{
				TimerTime -= Time.deltaTime;
			}
			else
			{
				Debug.Log("Time Has Run Out!");
			}
		}
	}

}
