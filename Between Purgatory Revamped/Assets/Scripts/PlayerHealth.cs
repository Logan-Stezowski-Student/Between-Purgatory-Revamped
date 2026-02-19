using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;

    public Text healthText;

    public GameObject gameOverUI;

    public InputHandler inputHandler;

    public FirstPersonCamera firstPersonCamera;
    void Start()
    {
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (int damageAmount) 
    {
        if (health != 0) 
        {
            health -= damageAmount;
            UpdateHealth();
        }

        if (health <= 0) 
        {
            healthText.text = "Dead";
            PlayerDeath();
        }
    }

    void PlayerDeath() 
    {
        gameOverUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        firstPersonCamera.enabled = false;
        inputHandler.enabled = false;
        Debug.Log("Player is dead");
    }

    public void UpdateHealth() 
    {
        healthText.text = Convert.ToString("Health: " + health);
    }
}
