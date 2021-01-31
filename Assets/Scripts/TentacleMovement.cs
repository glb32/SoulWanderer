using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleMovement : MonoBehaviour
{
    private bool b_Chasing = false;
    private Transform target = null;
    public float f_Speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (b_Chasing && target != null)
        {
            // Move our position a step closer to the target.
            float step = f_Speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                // Swap the position of the cylinder.
                target.position *= -1.0f;
            }
        }

    }

    public void StartChase(Transform player)
    {
        b_Chasing = true;
        target = player;
        Debug.Log("activate tentacle");
    }

    public void StopChase()
    {
        b_Chasing = false;
        target = null;
        Debug.Log("stop tentacle");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LocalPlayer tempPlayer = collision.gameObject.GetComponent("LocalPlayer") as LocalPlayer;
            tempPlayer.KillPlayer();
        }
       
    }
}
