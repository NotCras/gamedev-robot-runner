using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100;
    private bool isDead = false;
    
    public void TakeDamage(float damage)
    {
        if (isDead)
        {
            return;
        }
 
        hitPoints -= damage;
        BroadcastMessage("OnDamageTaken");

        if (hitPoints <= 0)
        {
            Die();
        }
        
    }

    private void Die()
    {
        print(name + " is killed.");
        isDead = true;

        BroadcastMessage("HasDied");
        //Destroy(this.gameObject);
    }

    public bool AmIDead()
    {
        return isDead;
    }
    
}
