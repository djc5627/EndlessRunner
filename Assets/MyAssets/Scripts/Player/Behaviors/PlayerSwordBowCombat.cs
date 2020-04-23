using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwordBowCombat : PlayerBehaviorBase
{
    public Transform projectileContainer;
    public BoxCollider swordAttackCollider;
    public GameObject swordObj;
    public GameObject crossbowObj;
    public GameObject swordTrail;
    public GameObject slashParticlesPrefab;
    public float slashParticlesYOffset = 3f;
    public LayerMask swordAttackMask;
    public float swordDamage;
    public float swordDelay = .2f;
    public GameObject crossbowAmmoPrefab;
    public Transform crossbowFirepoint;
    public float crossbowShootForce = 2000f;
    public float crossbowShootDelay;
    public AudioClip swordSwingSound;
    public AudioClip swordImpactSound;
    public AudioClip crossbowShootSound;

    private AudioSource audioSource;
    private float lastSwordSwingTime = Mathf.NegativeInfinity;
    private float lastCrossbowShootTime = Mathf.NegativeInfinity;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SwitchToCrossbow();
    }

    protected override void SubscribeToInputEvents()
    {
        playerInput.onMeleeAttack_Pressed += AttemptSwingSword;
        playerInput.onRangedAttack_Pressed += AttemptShootCrossbow;
    }

    public override void Execute()
    {

    }

    private void AttemptSwingSword()
    {
        if (lastSwordSwingTime + swordDelay <= Time.time)
        {
            SwingSword();
            lastSwordSwingTime = Time.time;
        }
    }

    private void AttemptShootCrossbow()
    {
        if (lastCrossbowShootTime + crossbowShootDelay <= Time.time)
        {
            ShootCrossbow();
        }
    }

    private void SwingSword()
    {
        SwitchToSword();
        Bounds swordColBounds = swordAttackCollider.bounds;
        Collider[] hitColliders = Physics.OverlapBox(swordColBounds.center, swordColBounds.extents, swordAttackCollider.transform.rotation, swordAttackMask);
        List<Enemy> affectedEnemies = new List<Enemy>();

        foreach (Collider col in hitColliders)
        {
            EnemyLimbProxy enemyProxy = col.GetComponent<EnemyLimbProxy>();
            if (enemyProxy != null && !affectedEnemies.Contains(enemyProxy.enemyScript))
            {
                affectedEnemies.Add(enemyProxy.enemyScript);
            }
        }

        //Deal damage to all the enemies hit
        foreach (Enemy enemyScript in affectedEnemies)
        {
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(swordDamage);
                Vector3 particlesLocation = enemyScript.gameObject.transform.position + Vector3.up * slashParticlesYOffset;
                if (slashParticlesPrefab!= null) Instantiate(slashParticlesPrefab, particlesLocation, Quaternion.identity);
            }
        }

        if (affectedEnemies.Count > 0)
        {
            if (swordImpactSound != null) audioSource.PlayOneShot(swordImpactSound);
        }
        else
        {
            if (swordSwingSound != null) audioSource.PlayOneShot(swordSwingSound);
        }
        playerAnimController.MeleeAttackTrigger();
        lastSwordSwingTime = Time.time;
    }

    private void ShootCrossbow()
    {
        SwitchToCrossbow();
        if (crossbowShootSound != null) audioSource.PlayOneShot(crossbowShootSound);

        GameObject tempBolt = Instantiate(crossbowAmmoPrefab, crossbowFirepoint.position, Quaternion.LookRotation(Vector3.forward), projectileContainer);
        Rigidbody bulletRb = tempBolt.GetComponent<Rigidbody>();


        bulletRb.AddForce(tempBolt.transform.forward * crossbowShootForce);
        lastCrossbowShootTime = Time.time;
    }

    private void SwitchToSword()
    {
        crossbowObj.SetActive(false);
        swordObj.SetActive(true);
    }

    private void SwitchToCrossbow()
    {
        crossbowObj.SetActive(true);
        swordObj.SetActive(false);
    }
}
