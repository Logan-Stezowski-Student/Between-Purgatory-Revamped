using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour, IWeapon
{
    public int damage = 5;
    public Animator animator;
    private bool isSwinging;

    public Player player;

    public Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void FireWeapon()
    {
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        AudioManager swordFiring = audioManager.GetComponent<AudioManager>();
        ammoText.text = Convert.ToString("Shots Left: Infinite");

        swordFiring.PlaySFX(8);
        if (!isSwinging) 
        {
            isSwinging = true; 
            animator.SetBool("Activate", true);
            animator.SetBool("isWalking", false);
        }
    }

    public void StopWeapon()
    {
        if (isSwinging)
        {
            isSwinging = false;
            animator.SetBool("Activate", false);
        }
    }

    public void DoDamage() 
    {
        if (player.current != null) 
        {
            player.current.TakePlayerDamage(damage);
            Debug.Log("Dude");
        }
        if (player.current2 != null)
        {
            player.current2.TakeDamage(damage);
            Debug.Log("Dude");
        }
    }
}
