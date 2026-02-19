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
    public AudioClip cannonFiring;
    private void OnEnable()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    public void FireWeapon()
    {
        if (Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            Fire();
            UpdateCannonAmmo();
        }
    }

    void Fire() 
    {
        AudioSource.PlayClipAtPoint(cannonFiring, transform.position);
        if (ammoCount > 0)
        {
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
