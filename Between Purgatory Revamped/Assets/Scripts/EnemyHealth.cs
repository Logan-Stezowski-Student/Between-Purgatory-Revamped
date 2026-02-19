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
        agent.isStopped = true;
        animator.SetBool("isDead", true);
        Destroy(gameObject, 2f);
    }
}
