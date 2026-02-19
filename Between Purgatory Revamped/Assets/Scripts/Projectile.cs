using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float forceAmount;
    public GameObject explosionPrefab;
    public int damage;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        Vector3 forceDirection = transform.forward;

        rigidBody.AddForce(forceDirection * forceAmount, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode() 
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider c in hits) 
        {
            if (c.CompareTag("Enemy") || c.CompareTag("Boss"))
            {
                EnemyHealth current = c.GetComponent<EnemyHealth>();
                BossHealth current2 = c.GetComponent<BossHealth>();
                if (current != null)
                {
                    current.TakePlayerDamage(damage);
                }
                if (current2 != null)
                {
                    current2.TakeDamage(damage);
                }
            }
        }
        Destroy(gameObject);
    }
    void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall") || 
            other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss"))
       {
            Explode();
       }
    }
}
