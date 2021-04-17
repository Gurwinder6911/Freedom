using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : MonoBehaviour
{
    public bool isGreenOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Renderer>().material.color == Color.green)
        {
            if (!isGreenOn)
            {
                isGreenOn = true;
            }
        }
    }
}
