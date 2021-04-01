using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private PlayerScript player;
    private Vector3 targetPlayer;

    private float speed = 2F;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        targetPlayer = player.transform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(targetPlayer * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                player.HealthDamage(4F);
                Destroy(this.gameObject);
                break;
            default:
                Destroy(this.gameObject);
                break;
        }
    }
}
