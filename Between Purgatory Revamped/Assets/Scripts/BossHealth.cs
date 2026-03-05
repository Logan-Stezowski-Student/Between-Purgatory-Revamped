using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BossHealth : MonoBehaviour
{
    public int health;

    public Text bossName;

    public Text healthText;

    public bool isAlive = true;

    public GameObject bossMusic;
    public GameObject enemySpawners;
    public GameObject healthSpawners;
    public GameObject ammoSpawners;
    // Start is called before the first frame update
    void Start()
    {
        UpdateBossHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damageAmount)
    {
        if (health != 0)
        {
            health -= damageAmount;
            UpdateBossHealth();
        }
        if (health <= 0)
        {
            healthText.text = "";
            isAlive = false;
            BossDeath();
        }
    }
    public void BossDeath() 
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");
        GameObject[] ui = GameObject.FindGameObjectsWithTag("UI to be Destroyed");
        foreach (GameObject enemy in enemies) 
        {
            Destroy(enemy);
        }
        foreach (GameObject weapon in weapons) 
        {
            Destroy(weapon);    
        }
        foreach(GameObject text in ui) 
        {
            Destroy(text);
        }
        bossMusic.SetActive(false);
        enemySpawners.SetActive(false);
        healthSpawners.SetActive(false);
        ammoSpawners.SetActive(false);
        Destroy(gameObject);
    }
    public void UpdateBossHealth() 
    {
        healthText.text = Convert.ToString("Health: " + health);
    }
}
