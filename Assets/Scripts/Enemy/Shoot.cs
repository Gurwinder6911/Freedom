using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    PlayerScript player;

    Vector3 targetPlayer;

    float speed = 5F;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        targetPlayer = player.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(targetPlayer * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.HealthDamage(4F);
            Destroy(this.gameObject);
        }
    }
}
