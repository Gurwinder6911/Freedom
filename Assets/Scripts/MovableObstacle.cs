using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MovableObstacle : MonoBehaviour
{
    [SerializeField]
    Vector3 movementVector;

    [SerializeField]
    [Range(0, 1)]
    float movementPerc;

    [SerializeField]
    float period = 2F;

    Vector3 startingPos;


    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period != 0)
        {
            float cycles = Time.time / period;
            float tau = Mathf.PI / 2F;
            float sineWave = Mathf.Sin(cycles * tau);

            movementPerc = sineWave / 2F + 0.5F;

            Vector3 offset = movementVector * movementPerc;
            transform.position = startingPos + offset;
        }
    }
}
