using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    public string objectTag;
    public AudioSource pickupSound = null;
    public bool respawn = false;
    public GameObject respawnObject = null;
    private bool despawned = false;
    public float respawnTimer = 10.0f;

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player"&& despawned==false)
        {            
            LocalPlayer inventory = other.gameObject.GetComponent("LocalPlayer") as LocalPlayer;
            inventory.AddToInventory(objectTag);
            if (pickupSound != null)
            {
                pickupSound.Play();
            }

            if (respawn)
            {
                despawned = true;
                respawnObject.SetActive(false);
                Invoke("Respawn", respawnTimer);
            }
            else
            {
                Destroy(gameObject);
            }

            
        }
    }

    public void Respawn()
    {
        despawned = false;
        respawnObject.SetActive(true);
    }
    
}
