using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 30f;
    private PlayerHealth target;
    
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null)
        {
            return;
        }
        Debug.Log("I hit you!");
        
        if (target == null)
        {
            Debug.Log("I can't find player!");
            return;
        }

        target.PlayerTakeDamage(damage);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
