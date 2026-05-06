using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Enemy_SO enemyType;

    public GameObject projectilePrefab;

    public Transform fireSocket;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer, whatIsWall;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, meleeRange, projectileRange;
    public bool playerInSightRange, playerInMeleeRange, playerBehindWall, playerInProjectileRange;

    Animator animator;

    public int damageAmount = 7;

    bool chase1Played, chase2Played, chase3Played;
    void Awake() 
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        agent.updateRotation = false;
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInMeleeRange = Physics.CheckSphere(transform.position, meleeRange, whatIsPlayer);
        playerInProjectileRange = Physics.CheckSphere(transform.position, projectileRange, whatIsPlayer);

        CheckWallBetweenPlayer();
        if (!playerInSightRange && !playerInMeleeRange) Patroling();
        if (playerInSightRange && !playerInMeleeRange && !playerBehindWall) 
        {
            animator.SetBool("isChasing", true);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isProjectile", false);
            animator.SetBool("isMelee", false);
            ChasePlayer(); 
        }
        if (playerInSightRange) 
        {
            
            if (enemyType.isBasic && playerInMeleeRange) 
            {
                animator.SetBool("isChasing", false);
                animator.SetBool("isAttacking", true);
            }
            if (enemyType.isProjectile && playerInProjectileRange) 
            {
                animator.SetBool("isChasing", false);
                animator.SetBool("isAttacking", true);

                agent.SetDestination(transform.position);

                Vector3 lookAt = player.position;

                lookAt.y = transform.position.y;

                transform.LookAt(lookAt);
            }
            if (enemyType.isTank) 
            {
                if (playerInProjectileRange && !playerInMeleeRange)
                {
                    animator.SetBool("isMelee", false);
                    animator.SetBool("isProjectile", true);
                }
                if (playerInMeleeRange)
                {
                    animator.SetBool("isProjectile", false);
                    animator.SetBool("isMelee", true);
                }
            }
        }
    }

    void Patroling () 
    {
        if(!walkPointSet) SearchWalkPoint();
    }

    void SearchWalkPoint() 
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if  (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround)) 
        {
            walkPointSet = true;
        }
    }

    void ChasePlayer()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager enemySight = audioManager.GetComponent<AudioManager>();
        if (!playerBehindWall) 
        {
            if (enemyType.isBasic && chase1Played == false) 
            {
                if (!enemySight.sfx[0].isPlaying)
                {
                    enemySight.PlaySFX(0);
                }
                chase1Played = true;
            }
            if (enemyType.isProjectile && chase2Played == false) 
            {
                if (!enemySight.sfx[1].isPlaying)
                {
                    enemySight.PlaySFX(1);
                }
                chase2Played = true;
            }
            if (enemyType.isTank && chase3Played == false)
            {
                if (!enemySight.sfx[2].isPlaying)
                {
                    enemySight.PlaySFX(2);
                }
                chase3Played = true;
            }

            Vector3 lookAt = player.position;

            lookAt.y = transform.position.y;

            transform.LookAt(lookAt);
            agent.SetDestination(player.position);
            
        }
    }

    void MeleeAttack() 
    {
        agent.SetDestination(transform.position);

        Vector3 lookAt = player.position;

        lookAt.y = transform.position.y;

        transform.LookAt(lookAt);
        if (!alreadyAttacked) 
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    public void RangedAttack()
    {
        if (!alreadyAttacked)
        {
            GameObject projectileSFX = GameObject.FindGameObjectWithTag("AudioManager");
            AudioManager audioManager = projectileSFX.GetComponent<AudioManager>();
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                audioManager.PlaySFX(22);
                GameObject proj = Instantiate(projectilePrefab, fireSocket.position, fireSocket.rotation);
                EnemyProjectile projScript = proj.GetComponent<EnemyProjectile>();
            }
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    void ResetAttack() 
    {
        alreadyAttacked = false;
    }
    void CheckWallBetweenPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        if (Physics.Raycast(transform.position, direction, distance, whatIsWall))
            playerBehindWall = true;
        else
            playerBehindWall = false;
    }
}
