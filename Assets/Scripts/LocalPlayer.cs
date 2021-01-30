using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LocalPlayer : MonoBehaviour
{

    private bool isAlive = true;
    private int soulAshCollected = 0;
    public float groundedHeight = 1f; // the height above ground to determine if the player is grounded
    public float checkRate = 1.0f; // how often in seconds we check to see if we are grounded
    public bool grounded = false;// is grounded or not
    public LayerMask groundLayer;//the layer on which we can be grounded
    public static float CountdownTime = 3.5f;
    public float TimerTime = CountdownTime;
    public Transform prefab = null;
    public float movementSpeed = 3f;
    private Rigidbody2D rigidbody2d;
    public Transform RespawnLocation = null;
    private bool soulAshCreated = false;
    public GUIStyle LabelStyle;

    private void Awake()
    {
        if (RespawnLocation == null)
        {
            RespawnLocation = GameObject.FindWithTag("Respawn").transform;


        }
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
    }
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
    void Timer()
        
    {

        if (grounded == false)
        {

            if (TimerTime > 0)
            {
                TimerTime -= Time.deltaTime;
            }
            if (TimerTime <= 0)
            {
                Debug.Log("Timer Invoked KillPlayer()");
                KillPlayer();
            }
        }
    }

    void KillPlayer()
    {
        if (isAlive && !soulAshCreated)
        {
            Debug.Log("Killed Player");
            isAlive = false;
        }
    
    }
    void Respawn()
    {
        Debug.Log("Respawned");
        TimerTime = CountdownTime;
        isAlive = true;
        transform.position = RespawnLocation.position;
        soulAshCreated = false;
    }
    void OnGUI()
    {

        if(!isAlive)
	    {
            GUI.Label(new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 50, 400, 100), "You Died",LabelStyle);

        }
    }

    void FixedUpdate()
	{
        if (!isAlive)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log("KeyDown");
                Respawn();
            }
        }

        if (!isAlive && soulAshCreated == false)
		{

            soulAshCreated = true;
            Instantiate(prefab, transform.position, Quaternion.identity);
           

        }
    if(isAlive)
	    {
            Timer();   
            if (TimerTime < CountdownTime && grounded == true)
            {
               
                TimerTime = CountdownTime;
                Debug.Log("Timer has been reset!");
            }


            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed);
		    
	    }

	}

}