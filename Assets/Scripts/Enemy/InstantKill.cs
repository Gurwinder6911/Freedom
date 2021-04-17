using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantKill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().HealthDamage(10F);
        }
    }
}
