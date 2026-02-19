using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{

    public GameObject[] attack;

    public float timeBetweenAttacks;

    public BossHealth health;
    // Start is called before the first frame update
    void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(BossAttacks());
    }
    IEnumerator BossAttacks() 
    {
        while (health.isAlive) 
        {
            int i = Random.Range(0, attack.Length);

            attack[i].SetActive(true);
            yield return new WaitForSeconds(timeBetweenAttacks);
            attack[i].SetActive(false);

            yield return new WaitForSeconds(timeBetweenAttacks);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
