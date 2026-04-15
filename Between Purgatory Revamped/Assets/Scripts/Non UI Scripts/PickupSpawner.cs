using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickUpPrefab;
    public Transform spawnerPostition;
    public float spawnRate;
    private float spawnTimer;
    public float healthSpawnAmount;
    public float orbSpawnAmount;
    public float cannonSpawnAmount;

    public bool isHealthSpawn;
    public bool isOrbSpawn;
    public bool isCannonSpawn;
    // Start is called before the first frame update
    private void Start()
    {
        spawnTimer = spawnRate;   
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0.0f) 
        {
            if (healthSpawnAmount == 1 && isHealthSpawn)
            {
                SpawnPickup();
                healthSpawnAmount--;
            }
            else if (orbSpawnAmount == 1 && isOrbSpawn)
            {
                SpawnPickup();
                orbSpawnAmount--;
            }
            else if (cannonSpawnAmount == 1 && isCannonSpawn)
            {
                SpawnPickup();
                cannonSpawnAmount--;
            }
            spawnTimer = spawnRate;
        }
    }

    void SpawnPickup() 
    {
        Instantiate(pickUpPrefab, spawnerPostition);
    }
}
