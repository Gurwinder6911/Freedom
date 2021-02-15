using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] LayerMask groundCheck;
    [SerializeField] LayerMask playerCheck;
    [SerializeField] Vector3 walkPoint;
    [SerializeField] Transform player;

    [SerializeField] float walkPointRange;
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] float sightRange;
    [SerializeField] float attackRange;

    NavMeshAgent agent;

    bool isWalkPointSet;
    bool isAttacked;
    bool isPlayerInRange;
    bool isPlayerInAttackRange;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerInRange = Physics.CheckSphere(transform.position, sightRange, playerCheck);
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerCheck);

        if (!isPlayerInRange && !isPlayerInAttackRange)
        {
            Searching();
        }

        if (isPlayerInRange && !isPlayerInAttackRange)
        {
            ChasePlayer();
        }

        if (isPlayerInRange && isPlayerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Searching()
    {
        if (!isWalkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distance = transform.position - walkPoint;

        if (distance.magnitude < 1F) // if walkpoint reached
        {
            isWalkPointSet = false;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
    }

    private void SearchWalkPoint()
    {
        float randHorizontal = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
        float randVertical = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randHorizontal, transform.position.y, transform.position.z + randVertical);

        if (Physics.Raycast(walkPoint, -transform.up, 2F, groundCheck))
        {
            isWalkPointSet = true;
        }
    }
}
