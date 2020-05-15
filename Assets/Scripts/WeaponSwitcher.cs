using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    
    void Start()
    {
        SetWeaponActive();
    }
    
    void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
        
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyPress();
        ProcessScrollWheel();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }
        
    }

    private void ProcessKeyPress()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }
    
    private void ProcessScrollWheel()
    {
        if (CrossPlatformInputManager.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWeapon >= transform.childCount - 1)
            {
                currentWeapon = 0;
            }
            else
            {
                currentWeapon++;
                Debug.Log("Scroll wheel forward!");
            }
        }
        else if (CrossPlatformInputManager.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
            }
            else
            {
                currentWeapon--;
                Debug.Log("Scroll wheel backward!");
            }
        }
    }
}
