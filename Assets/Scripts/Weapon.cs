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
    [SerializeField] private Ammo ammoSlot;
    [SerializeField] private float timeBetweenShots = 0.5f;

    private bool canShoot = true;

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
        
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo();
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
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

        enemy.TakeDamage(weaponDamage);
    }

    private void CreateHitImpact(RaycastHit r)
    {
        GameObject impact = Instantiate(impactFlash, r.point, Quaternion.LookRotation(r.normal));
        Destroy(impact, 0.5f);
    }
}
