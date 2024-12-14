using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    protected void OnTriggerStay(Collider other)
    {
            if (other.CompareTag("Tsunami"))
            {
                Debug.Log("Player triggered by Tsunami!");
            } 
    }
}
