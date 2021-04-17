using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    public bool isBlueOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Renderer>().material.color == Color.blue)
        {
            if (!isBlueOn)
            {
                isBlueOn = true;
            }
        }
    }
}
