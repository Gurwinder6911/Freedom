using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEvent : MonoBehaviour
{
    [SerializeField] GameObject shoot;
    [SerializeField] Transform shootPosition;

    float damage = 3;

    private PlayerScript player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    public void AttackEvent()
    {
        if (player != null)
        {
            if (GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>().inSight)
            {
                player.HealthDamage(damage);
            }
        }

        GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>().isAttacked = false;
    }

    public void ShootEvent()
    {
        if (player != null)
        {
            if (GameObject.FindGameObjectWithTag("Strong").GetComponent<EnemyScript>().inSight)
            {
                Instantiate(shoot, shootPosition.position, Quaternion.identity);
            }
        }

        GameObject.FindGameObjectWithTag("Strong").GetComponent<EnemyScript>().isAttacked = false;
    }
}
