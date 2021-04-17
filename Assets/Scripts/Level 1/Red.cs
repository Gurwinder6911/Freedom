using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    public bool isRedOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Renderer>().material.color == Color.red)
        {
            if (!isRedOn)
            {
                isRedOn = true; 
            }
        }
    }
}
