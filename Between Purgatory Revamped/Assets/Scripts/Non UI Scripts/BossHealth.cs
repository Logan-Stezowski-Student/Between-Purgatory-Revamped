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

    public GameObject redSun;

    public GameObject attackindicator;

    public GameObject bossDeco;

    public GameObject explosion;

    public GameObject redSunExplosion;
    public GameObject redSunWave;

    public UnityEvent OnBossDeath = new UnityEvent();
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
        GameObject[] eyes = GameObject.FindGameObjectsWithTag("Eye");
        StartCoroutine(DeathAnim());
        foreach (GameObject eyeball in eyes) 
        {
            Eyeball eye = eyeball.GetComponent<Eyeball>();
            eye.RollEye();
            Destroy(eyeball, 1.5f);
        }
        
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
        OnBossDeath.Invoke();
        Destroy(attackindicator, 1.5f);
        Destroy(gameObject, 1.5f);
        Destroy(bossDeco, 1.5f);
        Destroy(redSun, 1.5f);
    }
    IEnumerator DeathAnim() 
    {
        yield return new WaitForSeconds(1.49f);
        explosion.SetActive(true);
        redSunExplosion.SetActive(true);
        redSunWave.SetActive(true);
    }
    public void UpdateBossHealth() 
    {
        healthText.text = Convert.ToString("Health: " + health);
    }
}
