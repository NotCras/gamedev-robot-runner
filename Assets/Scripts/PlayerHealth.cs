using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour
{
    [FormerlySerializedAs("PlayerHealth")] [SerializeField] private float playerHealth = 100f;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Update()
    {
        healthText.text = playerHealth.ToString();
    }
    
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
