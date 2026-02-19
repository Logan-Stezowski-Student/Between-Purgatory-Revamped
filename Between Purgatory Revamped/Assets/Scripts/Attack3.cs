using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack3 : MonoBehaviour
{
    public GameObject[] spawners;
    public float timeBetween;
    // Start is called before the first frame update
    void OnEnable()
    {
        StopAllCoroutines();
        StartCoroutine(WaveAttack());
    }

    IEnumerator WaveAttack() 
    {
        while (true) 
        {
            for (int i = 0; i < spawners.Length; i++) 
            {
                spawners[i].SetActive(true);
                yield return new WaitForSeconds(timeBetween);
            }

            yield return new WaitForSeconds(1f);

            for (int i = 0;i < spawners.Length; i++) 
            {
                spawners[i].SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
