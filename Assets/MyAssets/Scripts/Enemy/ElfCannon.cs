﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class ElfCannon : Enemy
{
    public GameObject explosionEffect;
    public GameObject smokeParticles;
    public Transform firePoint;
    public Transform ammoContainer;
    public GameObject ammo;
    public float viewDistance = 30f;
    public float shootDelay = 3f;
    public float shootForce = 1000f;
    public float maxTurnSpeed = 3f;
    public float deathExplodeForce = 5000f;
    public float deathExplodeRaidus = 3f;
    public float deathExplosionDelay = .05f;

    private PuppetMaster puppetMaster;
    private Transform playerTrans;
    private Rigidbody[] puppetRbs;
    private float lastShootTime = Mathf.NegativeInfinity;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = FindObjectOfType<PlayerController>().transform;
        puppetRbs = ragdollRoot.GetComponentsInChildren<Rigidbody>();
        puppetMaster = ragdollRoot.GetComponentInChildren<PuppetMaster>();
        Debug.Log(puppetRbs.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            AimAtPlayer();
            HandleShooting();
        }
    }

    private void AimAtPlayer()
    {
        Vector3 vecToPlayer = playerTrans.position - transform.position;
        float distanceToPlayer = vecToPlayer.magnitude;


        Vector3 dirToPlayerOnPlane = new Vector3(vecToPlayer.x, 0f, vecToPlayer.z).normalized;

        Quaternion targetRot = Quaternion.LookRotation(dirToPlayerOnPlane, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, maxTurnSpeed);
    }

    private void HandleShooting()
    {
        if (lastShootTime + shootDelay > Time.time)
        {
            return;
        }

        GameObject tempAmmo = Instantiate(ammo, firePoint.position, Quaternion.identity, ammoContainer);
        Rigidbody ammoRb = tempAmmo.GetComponent<Rigidbody>();
        ammoRb.AddForce(firePoint.forward * shootForce);

        lastShootTime = Time.time;
    }

    private IEnumerator DeathExplosionRoutine()
    {
        yield return new WaitForSeconds(deathExplosionDelay);
        foreach (var limbRb in puppetRbs)
        {
            limbRb.AddExplosionForce(deathExplodeForce, transform.position, deathExplodeRaidus);
        }
        yield return null;

    }

    protected override void OnDeath()
    {
        base.OnDeath();
        StartCoroutine(DeathExplosionRoutine());
        puppetMaster.state = PuppetMaster.State.Dead;
        puppetMaster.Kill();
        puppetMaster.muscleWeight = 0f;
        puppetMaster.pinWeight = 0f;
    }
}