using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyAI : MonoBehaviour
{
    
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float turnSpeed = 4f;
    
    private Transform target;
    private NavMeshAgent navMeshAgent;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;
    private Animator anim;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        RigidbodyFirstPersonController player = FindObjectOfType<RigidbodyFirstPersonController>();
        target = player.transform;
        
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GetComponent<EnemyHealth>().AmIDead())
        {
            //do nothing
            navMeshAgent.enabled = false;
        }
        else
        {
            SeekAndDestroy();
        }
    }

    private void SeekAndDestroy()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            FaceTarget();
            ChaseTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            EngageTarget(distanceToTarget);
            isProvoked = true;
        }
        else
        {
            anim.SetBool("attack", false);
            anim.SetTrigger("idle");
            navMeshAgent.SetDestination(transform.position);
        }
    }

    private void EngageTarget(float dist)
    {
        FaceTarget();
        if (navMeshAgent.stoppingDistance < dist)
        {
            ChaseTarget();
        }
        else if (navMeshAgent.stoppingDistance >= dist)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        anim.SetBool("attack", false);
        anim.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        anim.SetBool("attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    public void HasDied()
    {
        anim.SetTrigger("die");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, navMeshAgent.stoppingDistance);
    }
    
}