using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera fpcamera;
    [SerializeField] private float range = 30f;
    [SerializeField] private float weaponDamage = 10f;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private GameObject impactFlash;
    
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
        
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        bool madehit = Physics.Raycast(fpcamera.transform.position, fpcamera.transform.forward, out hit, range);

        
        
        try
        {
            if (madehit)
            {
                CreateHitImpact(hit);
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

    private void CreateHitImpact(RaycastHit r)
    {
        GameObject impact = Instantiate(impactFlash, r.point, Quaternion.LookRotation(r.normal));
        Destroy(impact, 0.5f);
    }
}
