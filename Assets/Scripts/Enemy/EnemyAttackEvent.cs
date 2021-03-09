using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackEvent : MonoBehaviour
{
    [SerializeField] float damage;

    private PlayerScript player;
    private EnemyScript enemy;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    public void AttackEvent()
    {
        if (player != null)
        {
            if (enemy.inSight)
            {
                player.HealthDamage(damage);
            }
        }

        enemy.isAttacked = false;
    }
}
