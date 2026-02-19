using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public WeaponSwitch weaponSwitch;

    public Player player;

    PlayerInteraction playerInteraction;

    public Sword sword;
    public Orb orb;
    public Cannon cannon;

    public AudioClip swordSelect;
    public AudioClip orbSelect;
    public AudioClip cannonSelect;
    private void Start()
    {
        playerInteraction = GetComponent<PlayerInteraction>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
        }
        if (Input.GetMouseButton(0))
        {
            if (weaponSwitch.Current != null)
            {
                weaponSwitch.Current.FireWeapon();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (weaponSwitch.Current is Sword sword)
            {
                sword.StopWeapon();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            sword.ammoText.text = Convert.ToString("Shots Left: Infinite");
            weaponSwitch.SwitchWeapon(0);
            AudioSource.PlayClipAtPoint(swordSelect, transform.position);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            orb.UpdateOrbAmmo();
            weaponSwitch.SwitchWeapon(1);
            AudioSource.PlayClipAtPoint(orbSelect, transform.position);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) 
        {
            cannon.UpdateCannonAmmo();
            weaponSwitch.SwitchWeapon(2);
            AudioSource.PlayClipAtPoint(cannonSelect, transform.position);
        }
        HandleInteractInput();
    }

    void HandleInteractInput() 
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            playerInteraction.TryInteract();
        }
    }
}
