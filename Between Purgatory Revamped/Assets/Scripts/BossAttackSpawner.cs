using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnerPosition;
    // Start is called before the first frame update
    void OnEnable()
    {
        Instantiate(projectilePrefab, spawnerPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
