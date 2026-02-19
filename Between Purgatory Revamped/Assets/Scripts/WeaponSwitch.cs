using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] weapons;
    public int index = 0;

    public IWeapon Current 
    {
        get 
        {
            if (weapons.Length == 0) return null;
            return weapons[index].GetComponent<IWeapon>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < weapons.Length; i++) 
        {
            weapons[i].SetActive(false);
        }
        if (weapons.Length > 0) 
        {
            weapons[index].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
            
        }
    }
    public void SwitchWeapon(int switchWeapon) 
    {
        if (switchWeapon != index && switchWeapon >= 0 && switchWeapon < weapons.Length) 
        {
            weapons[index].SetActive(false);
            index = switchWeapon;
            weapons[index].SetActive(true);
        }
    }
}
