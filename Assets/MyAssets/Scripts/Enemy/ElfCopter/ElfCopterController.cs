using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RootMotion.Dynamics;

public class ElfCopterController : Enemy
{
    public Animator copterElfAnim;
    public NavMeshAgent agent;
    public Transform firePoint;
    public GameObject elfCopterObj;
    public GameObject elfCopterRagdollPrefab;
    public Transform ammoContainer;
    public GameObject ammo;
    public float shootDelay = 3f;
    public float shootForce = 1000f;
    public float followPlayerOffset = 10f;
    public float shootViewDistance = 60f;

    private float lastShootTime = Mathf.NegativeInfinity;
    private bool isPlayerInShootDistance = false;

    protected override void Start()
    {
        base.Start();
        agent.updateRotation = false;
    }

    private void Update()
    {
        CheckPlayerInSight();
        if (!isDead)
        {
            LookAtPlayer();
            PursuePlayer();
            if (isPlayerInShootDistance) HandleShooting();
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

    private void HandleShooting()
    {
        if (lastShootTime + shootDelay > Time.time)
        {
            return;
        }

        Vector3 vecToPlayer = (playerTrans.position - transform.position).normalized;
        GameObject tempAmmo = Instantiate(ammo, firePoint.position, Quaternion.LookRotation(vecToPlayer), ammoContainer);
        Rigidbody ammoRb = tempAmmo.GetComponent<Rigidbody>();
        ammoRb.AddForce(vecToPlayer * shootForce);

        lastShootTime = Time.time;
    }

    private void CheckPlayerInSight()
    {
        float distanceToPlayer = (playerTrans.position - transform.position).magnitude;
        //isPlayerInViewDistance = (distanceToPlayer <= viewDistance) ? true : false;
        isPlayerInShootDistance = (distanceToPlayer <= shootViewDistance) ? true : false;
    }

    protected override IEnumerator KnockbackRoutine()
    {
        yield return null;
    }


    protected override void OnDeath()
    {
        if (isDead)
        {
            return;
        }
        base.OnDeath();
        copterElfAnim.enabled = false;
        elfCopterObj.SetActive(false);
        Instantiate(elfCopterRagdollPrefab, transform.position, transform.rotation);
        agent.isStopped = true;
    }
}
