using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnerPosition;
    // Start is called before the first frame update
    void OnEnable()
    {
        Instantiate(enemyPrefab, spawnerPosition.position, spawnerPosition.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
