using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSwordMagicCombat : PlayerBehaviorBase
{
    public Transform projectileContainer;
    public BoxCollider swordAttackCollider;
    public GameObject swordObj;
    public GameObject crossbowObj;
    public LayerMask swordAttackMask;
    public float swordDamage;
    public float swordDelay = .2f;
    public GameObject crossbowAmmoPrefab;
    public Transform crossbowFirepoint;
    public float crossbowShootForce = 2000f;
    public float crossbowShootDelay;

    private float lastSwordSwingTime = Mathf.NegativeInfinity;
    private float lastCrossbowShootTime = Mathf.NegativeInfinity;

    protected  void Start()
    {
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
            if (enemyScript != null) enemyScript.TakeDamage(swordDamage);
        }

        //Rumble
        if (affectedEnemies.Count > 0)
        {
            InputDevice device = InputDeviceManager.GetPlayerDevice(playerInput.GetPlayerIndex());
            RumbleManager.Instance.StartRumble(device, 1f, 1f, .04f);
        }

        playerAnimController.MeleeAttackTrigger();
        lastSwordSwingTime = Time.time;
    }

    private void ShootCrossbow()
    {
        SwitchToCrossbow();

        //Rumble
        InputDevice device = InputDeviceManager.GetPlayerDevice(playerInput.GetPlayerIndex());
        RumbleManager.Instance.StartRumble(device, .8f, .8f, .03f);

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
