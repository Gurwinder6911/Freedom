using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class MovableObstacle : MonoBehaviour
{
    [SerializeField]
    Vector3 movementVector;

    [SerializeField]
    LayerMask playerMask;

    [SerializeField]
    Transform playerCheck;

    [SerializeField]
    [Range(0, 1)]
    float movementPerc;

    [SerializeField]
    float period = 2F;

<<<<<<< HEAD
    private Vector3 startingPos;
=======
    [SerializeField]
    float playerDistance;

    private Vector3 startingPos;
    private Vector3 offset;
>>>>>>> b7d611a51f21907299fb966ab890efe9c48a7fbd
    private PlayerScript player;

    private bool isHitPlayer;


    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
=======
        CheckingPlayer();

>>>>>>> b7d611a51f21907299fb966ab890efe9c48a7fbd
        if (period != 0)
        {
            float cycles = Time.time / period;
            float tau = Mathf.PI / 2F;
            float sineWave = Mathf.Sin(cycles * tau);

            movementPerc = sineWave / 2F + 0.5F;

<<<<<<< HEAD
            Vector3 offset = movementVector * movementPerc;
=======
            offset = movementVector * movementPerc;
>>>>>>> b7d611a51f21907299fb966ab890efe9c48a7fbd
            transform.position = startingPos + offset;
        }
    }

    void CheckingPlayer()
    {
<<<<<<< HEAD
        isHitPlayer = Physics.CheckSphere(playerCheck.position, 1.5F, playerMask);

        if (isHitPlayer)
=======
        isHitPlayer = Physics.CheckSphere(playerCheck.position, playerDistance, playerMask);

        if (isHitPlayer && offset.magnitude > 1.5F)
>>>>>>> b7d611a51f21907299fb966ab890efe9c48a7fbd
        {
            player.HealthDamage(10F);
        }
    }
}
