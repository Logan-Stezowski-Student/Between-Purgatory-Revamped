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
            if (isSword == true) 
            {
                weaponSwitch.AddWeapon(sword, 0);
                sword.SetActive(true);
            }
            if (isOrb == true)
            {
                weaponSwitch.AddWeapon(orb, 1);
                orb.SetActive(true);
            }
            if (isCannon == true)
            {
                weaponSwitch.AddWeapon(cannon, 2);
                cannon.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
    

}
