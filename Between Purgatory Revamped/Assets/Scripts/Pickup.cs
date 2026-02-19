using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Pickup_SO pickupType;
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        Cannon cannon = other.gameObject.GetComponentInChildren<Cannon>();
        Orb orb = other.gameObject.GetComponentInChildren<Orb>();

        PickupSpawner pickupSpawner = GetComponentInParent<PickupSpawner>();

        if (other.gameObject.CompareTag("Player"))
        {
            if (pickupType.isHealth == true)
            {
                if (playerHealth.health < 100)
                {
                    pickupSpawner.healthSpawnAmount++;
                    playerHealth.health += pickupType.health;
                    playerHealth.health = Mathf.Clamp(playerHealth.health, 0, 100);
                    playerHealth.UpdateHealth();
                    Destroy(gameObject);
                }
            }
            if (pickupType.isCannonAmmo == true)
            {
                if (cannon.ammoCount < 4)
                {
                    pickupSpawner.cannonSpawnAmount++;
                    cannon.ammoCount += pickupType.ammo;
                    cannon.ammoCount = Mathf.Clamp(cannon.ammoCount, 0, 4);
                    cannon.UpdateCannonAmmo();
                    Destroy(gameObject);
                }
            }
            if (pickupType.isOrbAmmo == true)
            {
                if (orb.ammoCount < 35)
                {
                    pickupSpawner.orbSpawnAmount++;
                    orb.ammoCount += pickupType.ammo;
                    orb.ammoCount = Mathf.Clamp(orb.ammoCount, 0, 35);
                    orb.UpdateOrbAmmo();
                    Destroy(gameObject);
                }
            }
        }
    }
}
