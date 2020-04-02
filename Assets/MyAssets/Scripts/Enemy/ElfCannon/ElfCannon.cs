using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public class ElfCannon : Enemy
{
    public Animator cannonAnim;
    public AudioSource shootSource;
    public GameObject explosionEffect;
    public GameObject smokeParticles;
    public GameObject cannonShootParticles;
    public Transform firePoint;
    public Transform ammoContainer;
    public GameObject ammo;
    public AudioClip shootClip;
    public float viewDistance = 50f;
    public float shootViewDistance = 30f;
    public float shootDelay = 3f;
    public float shootForce = 1000f;
    public float maxTurnSpeed = 3f;
    public float shootTurnDelay = .5f;
    public float deathExplodeForce = 5000f;
    public float deathExplodeRaidus = 3f;
    public float deathExplosionDelay = .05f;

    private Transform playerTrans;
    private Rigidbody[] puppetRbs;
    private float lastShootTime = Mathf.NegativeInfinity;
    private bool isPlayerInViewDistance = false;
    private bool isPlayerInShootDistance = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerTrans = FindObjectOfType<PlayerController>().transform;
        puppetRbs = ragdollRoot.GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerInSight();
        if (!isDead)
        {
            if (isPlayerInViewDistance) AimAtPlayer();
            if (isPlayerInShootDistance) HandleShooting();
        }
    }

    private void AimAtPlayer()
    {
        if (lastShootTime + shootTurnDelay > Time.time)
        {
            if (audioSource.isPlaying) audioSource.Stop();
            return;
        }

        if (!audioSource.isPlaying) audioSource.Play();

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
        Instantiate(cannonShootParticles, firePoint.position, firePoint.rotation);
        shootSource.PlayOneShot(shootClip);

        lastShootTime = Time.time;
    }

    private void CheckPlayerInSight()
    {
        float distanceToPlayer = (playerTrans.position - transform.position).magnitude;
        isPlayerInViewDistance = (distanceToPlayer <= viewDistance) ? true : false;
        isPlayerInShootDistance = (distanceToPlayer <= shootViewDistance) ? true : false;
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
        cannonAnim.SetTrigger("Death");
        audioSource.Stop();
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        smokeParticles.SetActive(true);
        StartCoroutine(DeathExplosionRoutine());
    }
}
