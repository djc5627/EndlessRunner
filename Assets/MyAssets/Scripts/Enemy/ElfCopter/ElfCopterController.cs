using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RootMotion.Dynamics;

public class ElfCopterController : Enemy
{
    public NavMeshAgent agent;
    public GameObject elfCopterObj;
    public GameObject elfCopterRagdollPrefab;
    public float followPlayerOffset = 10f;

    private Transform playerTrans;

    protected override void Start()
    {
        base.Start();
        playerTrans = FindObjectOfType<PlayerController>().transform;
        agent.updateRotation = false;
    }

    private void Update()
    {
        if (!isDead)
        {
            LookAtPlayer();
            PursuePlayer();
        }
        
    }

    private void PursuePlayer()
    {
        Vector3 dest = playerTrans.position + Vector3.forward * followPlayerOffset;
        agent.SetDestination(dest);
    }

    private void LookAtPlayer()
    {
        Vector3 vecToPlayer = (playerTrans.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(vecToPlayer);
    }


    protected override void OnDeath()
    {
        base.OnDeath();
        elfCopterObj.SetActive(false);
        Instantiate(elfCopterRagdollPrefab, transform.position, transform.rotation);
        agent.isStopped = true;
    }
}
