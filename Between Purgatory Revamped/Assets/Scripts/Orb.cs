
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb : MonoBehaviour, IWeapon
{
    public int range = 10;

    public float fireRate = 0.2f;
    public int damage = 2;
    public GameObject projectilePrefab;

    public Transform point;
    public float nextFire = 0.2f;

    public int ammoCount = 0;
    private bool canFire = true;

    public Text ammoText;

    public AudioClip orbFiring;
    // Update is called once per frame
    // No more raycasting

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
            UpdateOrbAmmo();
        }
    }


    void Fire()
    {
        AudioSource.PlayClipAtPoint(orbFiring, transform.position);
        if (ammoCount > 0)
        {
            canFire = true;
            GameObject proj = Instantiate(projectilePrefab, point.position, point.rotation);
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
    public void UpdateOrbAmmo() 
    {
        ammoText.text = Convert.ToString("Shots Left: " + ammoCount);
    }
}


