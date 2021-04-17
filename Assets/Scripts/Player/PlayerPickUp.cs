using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform posPickup;
    [SerializeField] LayerMask wallLayer;

    public static bool isDrop = true;

    private Vector3 mousePosition;
    private Rigidbody rigidbody;

    private float range;

    private bool isEquip;
    private bool isHolding;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        mousePosition = new Vector3(Screen.width / 2F, Screen.height / 2F, 0F);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            range = Vector3.Distance(transform.position, player.transform.position); 
        }

        if (range >= 2F)
        {
            isEquip = false;
        }

        if (isEquip)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;

            transform.parent = player.transform;
        }
        else
        {
            DropObject();
        }
    }

    public void PickUpFunc()
    {
        if (isHolding)
        {
            DropFunc();
        }
        else
        {
            PickUp();
        }
    }

    public void DropFunc()
    {
        isEquip = false;
        isHolding = false;
        isDrop = true;
    }

    private void PickUp()
    {
        transform.position = posPickup.position;

        isEquip = true;

        rigidbody.useGravity = false;
        rigidbody.detectCollisions = true;
        isHolding = true;
        isDrop = false;
    }

    private void DropObject()
    {
        var posItem = transform.position;

        transform.parent = null;
        rigidbody.useGravity = true;
        transform.position = posItem;
    }
}
