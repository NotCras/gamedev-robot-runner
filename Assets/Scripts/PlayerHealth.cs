using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [FormerlySerializedAs("PlayerHealth")] [SerializeField] private float playerHealth = 100f;

    public void PlayerTakeDamage(float damage)
    {
        playerHealth -= damage;
        //Debug.Log("Ouch! I lost some health!");

        if (playerHealth <= 0)
        {
            //Debug.Log("Player is dead!! ");

            DeathHandler death = FindObjectOfType<DeathHandler>();
            death.HandleDeath();

        }
            
        
    }
}
