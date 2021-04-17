using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    private GameObject item;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Selectable") && PlayerPickUp.isDrop)
        {
            item = other.gameObject;
        }
    }

    public void Pickup()
    {
        if (item != null)
        {
            item.GetComponent<PlayerPickUp>().PickUpFunc();
        }

        if (PlayerPickUp.isDrop)
        {
            item = null;
        }
    }
}
