using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Haptics;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public InputMaster inputMaster;
    public PlayerMovementBase playerMovement;
    public HealthBar healthBar;
    public Transform firePoint;
    public GameObject rocketPrefab;
    public GameObject bulletPrefab;
    public GameObject rocketLauncherObj;
    public GameObject assaultRifleObj;
    public float maxHealth = 10f;
    public float invicibilityTime = 1.5f;
    public float deathBarrierYOffset = -50f;
    public float shootForce_Rocket = 100f;
    public float shootDelay_Rocket = .5f;
    public float shootForce_Bullet = 100f;
    public float shootDelay_Bullet = .5f;
    public AudioClip shootClip_Rocket;
    public float shootClipScale_Rocket = 1f;
    public AudioClip shootClip_Bullet;
    public float shootClipScale_Bullet = 1f;
    
    private InputDevice controller;
    private float currentHealth;
    private float lastShootTime_Rocket = Mathf.NegativeInfinity;
    private float lastShootTime_Bullet = Mathf.NegativeInfinity;
    private float lastDamageTime = Mathf.NegativeInfinity;
    private bool secondaryShootHeld = false;
    private bool isInvincible = false;

    private void OnEnable()
    {
        inputMaster.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //Movement
        inputMaster = new InputMaster();
        inputMaster.Player.MoveInput.performed += ctx => playerMovement.OnMoveInput(ctx.ReadValue<float>());
        inputMaster.Player.Jump.performed += ctx => playerMovement.OnJump();
        inputMaster.Player.JumpRelease.performed += ctx => playerMovement.OnJumpReleased();

        //Combat
        inputMaster.Player.Shoot.performed += ctx =>
        {
            if (controller == null) controller = ctx.control.device;
            ShootRocket();
        };
        inputMaster.Player.ShootSecondary_Press.performed += ctx =>
        {
            if (controller == null) controller = ctx.control.device;
            secondaryShootHeld = true;
        };
        inputMaster.Player.ShootSecondary_Release.performed += ctx => secondaryShootHeld = false;
        

    }

    private void Update()
    {
        playerMovement.Move();

        if (secondaryShootHeld)
        {
            ShootBullet();
        }
        CheckDeathBarrier();
        HandleInvincibility();
    }

    private void CheckDeathBarrier()
    {
        if (transform.position.y < deathBarrierYOffset)
        {
            Death();
        }
    }

    private void ShootRocket()
    {
        if (lastShootTime_Rocket + shootDelay_Rocket > Time.time)
        {
            return;
        }

        //Rumble
        RumbleManager.Instance.StartRumble(controller, .5f, .3f, .1f);

        GameObject tempRocket = Instantiate(rocketPrefab, firePoint.position, Quaternion.LookRotation(firePoint.forward));
        Rigidbody rocketRb = tempRocket.GetComponent<Rigidbody>();
        rocketRb.AddForce(firePoint.forward * shootForce_Rocket);
        lastShootTime_Rocket = Time.time;

        GlobalAudioPlayer.Instance.PlayClipAt(shootClip_Rocket, transform.position, shootClipScale_Rocket);
        rocketLauncherObj.SetActive(true);
        assaultRifleObj.SetActive(false);
    }

    private void ShootBullet()
    {
        if (lastShootTime_Bullet + shootDelay_Bullet > Time.time)
        {
            return;
        }

        //Rumble
        RumbleManager.Instance.StartRumble(controller, .1f, .15f, .015f);

        GameObject tempBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(firePoint.forward));
        Rigidbody bulletRb = tempBullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(firePoint.forward * shootForce_Bullet);
        lastShootTime_Bullet = Time.time;

        GlobalAudioPlayer.Instance.PlayClipAt(shootClip_Bullet, transform.position, shootClipScale_Bullet);
        rocketLauncherObj.SetActive(false);
        assaultRifleObj.SetActive(true);
    }

    private void Death()
    {
        ResetLevel();
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage(float damage)
    {
        if (isInvincible)
        {
            return;
        }

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        lastDamageTime = Time.time;
        if (currentHealth <= 0f)
        {
            Death();
        }
    }

    private void HandleInvincibility()
    {
        if (lastDamageTime + invicibilityTime > Time.time)
        {
            isInvincible = true;
        }
        else
        {
            isInvincible = false;
        }
        PlayerAnimController.Instance.SetInvincibility(isInvincible);
    }
}
