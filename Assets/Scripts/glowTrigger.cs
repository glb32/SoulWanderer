using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowTrigger : MonoBehaviour
{
    public GameObject farTarget = null;
    public GameObject closeTarget = null;

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            farTarget.SetActive(false);
            closeTarget.SetActive(true);

        }
    }
   
    public void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            farTarget.SetActive(true);
            closeTarget.SetActive(false);

        }
    }


}
