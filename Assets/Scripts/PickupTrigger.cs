using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    public string objectTag;
    public void OnTriggerEnter(Collider other)
    {
		Debug.Log("Touched Coin!");
        if (other.tag == "Player")
        {
            
            LocalPlayer inventory = other.gameObject.GetComponent("LocalPlayer") as LocalPlayer;
            inventory.AddToInventory(objectTag);
            Destroy(gameObject);
        }
    }
    
}
