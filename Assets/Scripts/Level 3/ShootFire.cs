using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFire : MonoBehaviour
{
    public ParticleSystem fire;
    public GameObject light;
    public GameObject damageFire;

    private float currentTimer;
    private float startTimer = 4F;
    private float breakTimer;
    private float startBreakTimer = 2F;


    private void Start()
    {
        currentTimer = startTimer;
        breakTimer = startBreakTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimer >= startTimer)
        {
            if (!fire.isPlaying)
            {
                fire.Play();
                light.SetActive(true);
                damageFire.SetActive(true);
            }
        }

        currentTimer -= 1 * Time.deltaTime;

        if (currentTimer <= 0)
        {
            if (!fire.isStopped)
            {
                fire.Stop();
                light.SetActive(false);
                damageFire.SetActive(false);
            }
            breakTimer -= 1 * Time.deltaTime;
        }

        if (breakTimer <= 0)
        {
            currentTimer = startTimer;
            breakTimer = startBreakTimer;
        }
    }
}
