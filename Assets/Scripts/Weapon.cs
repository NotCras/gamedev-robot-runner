using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera fpcamera;
    [SerializeField] private float range = 30f;
    [SerializeField] private float weaponDamage = 10f;
    
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    private void Shoot()
    {
        RaycastHit hit;
        bool madehit = Physics.Raycast(fpcamera.transform.position, fpcamera.transform.forward, out hit, range);

        //TODO: add some visual hit effect

        try
        {
            if (madehit)
            {
                print("I hit " + hit.transform.name);
            }
        }
        catch
        {
            print("I didn't hit anything.");
        }

        EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
        if (enemy == null)
        {
            return;
        }
        enemy.takeDamage(weaponDamage);

    }
}
