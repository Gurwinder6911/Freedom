using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;

    GameObject enemy;


    void Start()
    {
        int random = Random.Range(0, 2);
        var enemySpawn = spawnEnemy(random);
        Instantiate(enemySpawn, transform.position, Quaternion.identity);
    }

    private GameObject spawnEnemy(int random)
    {
        switch (random)
        {
            case 0:
                enemy = enemies[random];
                return enemy;
            case 1:
                enemy = enemies[random];
                return enemy;

            default:
                return null;
        }
    }
}
