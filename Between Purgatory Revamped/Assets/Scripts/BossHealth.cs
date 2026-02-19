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
        bossMusic.SetActive(false);
        Destroy(gameObject);
    }
    public void UpdateBossHealth() 
    {
        healthText.text = Convert.ToString("Health: " + health);
    }
}
