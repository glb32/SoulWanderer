using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winTrigger : MonoBehaviour
{
    public AudioSource winSound = null;

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            winSound.Play();

        }
    }


}
