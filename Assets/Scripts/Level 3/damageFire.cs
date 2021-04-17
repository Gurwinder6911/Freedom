using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageFire : MonoBehaviour
{
    private float damageTime;
    private float startDamageTime = 1.5F;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (damageTime <= 0)
            {
                other.gameObject.GetComponent<PlayerScript>().HealthDamage(2F);
                damageTime = startDamageTime;
            }

            damageTime -= 1 * Time.deltaTime;
        }
    }
}
