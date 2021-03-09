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
    [SerializeField] float rotateSpeed;

    public NavMeshAgent agent;

    Animator animator;

    public bool inSight;
    public bool isAttacked;

    bool isWalkPointSet;
    bool isPlayerInRange;
    bool isPlayerInAttackRange;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerInRange = Physics.CheckSphere(transform.position, sightRange, playerCheck);
        isPlayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerCheck);
        inSight = isPlayerInAttackRange;

        animator.SetFloat("walkPoint", agent.velocity.magnitude);

        if (!isPlayerInRange && !isPlayerInAttackRange)
        {
            Searching();
        }

        if (isPlayerInRange && !isPlayerInAttackRange && !isAttacked)
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
            agent.stoppingDistance = 0F;
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
        animator.SetBool("IsAttack", false);

        agent.stoppingDistance = 1.4F;
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        isAttacked = true;
        animator.SetBool("IsAttack", true);
        
        Vector3 direction = (player.position - transform.position).normalized;
        var rotateToTarget = Quaternion.LookRotation(new Vector3(direction.x, 0F, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateToTarget, rotateSpeed * Time.deltaTime);
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