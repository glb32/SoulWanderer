using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleTrigger : MonoBehaviour
{

    public TentacleMovement tentacle;
    public AudioSource agroSound = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            tentacle.StartChase(other.transform);

            if (agroSound != null)
            {
                agroSound.Play();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            tentacle.StopChase();


            if (agroSound != null)
            {
                if(agroSound.isPlaying)
                    agroSound.Stop();
            }
        }
    }
}
