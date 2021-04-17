using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject red;
    [SerializeField] GameObject blue;
    [SerializeField] GameObject green;

    [SerializeField] Animation trapOne;
    [SerializeField] Animation trapTwo;
    [SerializeField] Animation trapThree;

    [SerializeField] Text counter;

    public GameObject trapAnim;

    public static float currentTimer;
    private float startTimer = 50F;

    public static bool isSwitchOn;
    private bool isDead;

    void OnTriggerEnter(Collider other)
    {
        if (!isSwitchOn && !isDead && !Button.isOpen)
        {
            isSwitchOn = true;
            currentTimer = startTimer;

            trapAnim.GetComponent<Animation>().Play("TrapAnim");

            counter.gameObject.SetActive(true);
            button.SetActive(true);
            red.SetActive(true);
            blue.SetActive(true);
            green.SetActive(true);
        }
    }

    void Update()
    {
        if (isSwitchOn)
        {
            counter.text = (currentTimer -= 1 * Time.deltaTime).ToString("0");

            if (currentTimer <= 0)
            {
                currentTimer = -1;
                counter.gameObject.SetActive(false);

                trapOne.Play();
                trapTwo.Play();
                trapThree.Play();
            } 
        }
    }
}
