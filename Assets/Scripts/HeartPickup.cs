using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    InventorySystem inventory;

    private void Start()
    {
        inventory = GameObject.Find("Canvas").GetComponent<InventorySystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inventory.items.Add("H");
            Destroy(this.gameObject);
        }
    }
}
