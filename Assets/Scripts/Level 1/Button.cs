using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject trapAnim;
    [SerializeField] GameObject red;
    [SerializeField] GameObject blue;
    [SerializeField] GameObject green;
    [SerializeField] GameObject door;

    [SerializeField] Text counter;

    public static bool isOpen;


    // Update is called once per frame
    void Update()
    {
        if (red.GetComponent<Red>().isRedOn && blue.GetComponent<Blue>().isBlueOn && green.GetComponent<Green>().isGreenOn)
        {
            if (!isOpen)
            {
                trapAnim.GetComponent<Animation>().Play("CloseTrapAnim");
                counter.gameObject.SetActive(false);

                Switch.currentTimer = 10F;
                Switch.isSwitchOn = false;
                isOpen = true;

                Destroy(door.gameObject);
            }
        }
    }
}
