using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponPickup : MonoBehaviour
{
    public WeaponSwitch weaponSwitch;

    public GameObject sword;
    public GameObject orb;
    public GameObject cannon;

    public bool isSword, isOrb, isCannon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            WeaponSwitch swap = other.gameObject.GetComponent<WeaponSwitch>();
            if (isSword == true) 
            {
                Sword sword1 = sword.GetComponent<Sword>();
                weaponSwitch.AddWeapon(sword, 0);
                sword.SetActive(true);
                swap.SwitchWeapon(0);
                sword1.ammoText.text = Convert.ToString("Shots Left: Infinite");
            }
            if (isOrb == true)
            {
                Orb orb1 = orb.GetComponent<Orb>();
                weaponSwitch.AddWeapon(orb, 1);
                orb.SetActive(true);
                swap.SwitchWeapon(1);
                orb1.UpdateOrbAmmo();
            }
            if (isCannon == true)
            {
                Cannon cannon1 = cannon.GetComponent<Cannon>();
                weaponSwitch.AddWeapon(cannon, 2);
                cannon.SetActive(true);
                swap.SwitchWeapon(2);
                cannon1.UpdateCannonAmmo();
            }
            Destroy(gameObject);
        }
    }
    

}
