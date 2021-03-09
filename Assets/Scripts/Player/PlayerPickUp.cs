using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform posPickup;
    [SerializeField] LayerMask wallLayer;


    private Vector3 mousePosition;
    private Rigidbody rigidbody;

    private float range;

    private bool isEquip;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        mousePosition = new Vector3(Screen.width / 2F, Screen.height / 2F, 0F);
    }

    // Update is called once per frame
    void Update()
    {

        range = Vector3.Distance(transform.position, player.transform.position);

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

    void OnMouseDown()
    {
        var rayCast = Camera.main.ScreenPointToRay(mousePosition);

        if (range <= 2F && Physics.Raycast(rayCast))
        {
            PickUp();
        }
    }

    void OnMouseUp()
    {
        isEquip = false;
    }

    private void PickUp()
    {
        transform.position = posPickup.position;

        isEquip = true;

        rigidbody.useGravity = false;
        rigidbody.detectCollisions = true;
    }

    private void DropObject()
    {
        var posItem = transform.position;

        transform.parent = null;
        rigidbody.useGravity = true;
        transform.position = posItem;
    }
}
