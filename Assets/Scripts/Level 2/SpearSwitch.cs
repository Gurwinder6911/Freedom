using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpearSwitch : MonoBehaviour
{
    [SerializeField] Text counter;
    [SerializeField] Animation spearAnim;

    private float currentTimer;
    private float startTimer = 3F;

    private bool isSwitchOn;
    private bool isShoot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isShoot)
        {
            isSwitchOn = true;
            currentTimer = startTimer;
            counter.gameObject.SetActive(true);
        }
    }


    private void Update()
    {
        if (isSwitchOn)
        {
            counter.text = (currentTimer -= 1 * Time.deltaTime).ToString("0");

            if (currentTimer <= 0 && !isShoot)
            {
                spearAnim.Play();
                isShoot = true;
                counter.gameObject.SetActive(false);
                isSwitchOn = false;
            }
        }
    }
}
