using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public int health;
    Animator animator;
    NavMeshAgent agent;
    bool isDead1, isDead2, isDead3;
    Enemy enemy;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakePlayerDamage(int playerDamage) 
    { 
        if (health != 0)
        {
            health -= playerDamage;
        }

        if (health <= 0)
        {
            EnemyDeath();
        }
    }

    void EnemyDeath() 
    {
        enemy = GetComponent<Enemy>();
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager enemyDeath = audioManager.GetComponent<AudioManager>();
        agent.isStopped = true;
        animator.SetBool("isDead", true);
        if (enemy.enemyType.isBasic) 
        {
            enemyDeath.PlaySFX(3);
        }
        if (enemy.enemyType.isProjectile)
        {
            enemyDeath.PlaySFX(4);
        }
        if (enemy.enemyType.isTank)
        {
            enemyDeath.PlaySFX(5);
        }
        Destroy(gameObject, 2f);
    }
}
