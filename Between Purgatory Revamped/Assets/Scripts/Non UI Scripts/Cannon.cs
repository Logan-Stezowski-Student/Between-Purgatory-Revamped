using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour, IWeapon
{
    public int damage = 30;
    public int range = 15;
    public float fireRate = 2.5f;
    public GameObject projectilePrefab;
    public Transform fireSocket;

    private float nextFire = 0f;
    public int ammoCount = 0;
    private bool canFire = true;

    public Text ammoText;

    public Animator animator;
    private void OnEnable()
    {
        nextFire = Time.time;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void FireWeapon()
    {
        if (Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            Fire();
            UpdateCannonAmmo();
            animator.SetBool("Shoot", true);
            animator.SetBool("isWalking", false);
        }
    }

    void Fire() 
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager cannonFiring = audioManager.GetComponent<AudioManager>();
        if (ammoCount > 0)
        {
            cannonFiring.PlaySFX(12);
            canFire = true;
            GameObject proj = Instantiate(projectilePrefab, fireSocket.position, fireSocket.rotation);
            Projectile projScript = proj.GetComponent<Projectile>();
            if (projScript != null)
                projScript.damage = damage;
            ammoCount--;
            if (ammoCount == 0)
            {
                canFire = false;    
            }
        }
    }
    public void UpdateCannonAmmo()
    {
        ammoText.text = Convert.ToString("Shots Left: " + ammoCount);
    }
}
