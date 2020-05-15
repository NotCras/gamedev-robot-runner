using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private int amountOfAmmo = 10;

    private void OnTriggerEnter(Collider other)
    {
        Ammo collidedWith = other.gameObject.GetComponent<Ammo>();
        
        if (collidedWith == null)
        {
            return;
        }
        else
        {
            Debug.Log("I have collided with player!");
            AddAmmo();
            Destroy(this.gameObject, 0.5f);
        }
        
        
    }

    private void AddAmmo()
    {
        Ammo ammo = FindObjectOfType<Ammo>();
        ammo.AddCurrentAmmo(ammoType, amountOfAmmo);
    }
}
