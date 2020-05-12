using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float hitPoints = 100;

    public void takeDamage(float damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            print(name + " is killed.");
            Destroy(this.gameObject);
        }
    }
}
