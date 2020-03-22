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
    public PlayerCombatBase playerCombat;
    public HealthBar healthBar;
    public float maxHealth = 10f;
    public float invicibilityTime = 1.5f;
    public float deathBarrierYOffset = -50f;
    
    private float currentHealth;
    private float lastDamageTime = Mathf.NegativeInfinity;
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
        inputMaster.Player.ShootPrimary_Press.performed += ctx => playerCombat.OnPrimaryFirePressed();
        inputMaster.Player.ShootPrimary_Release.performed += ctx => playerCombat.OnPrimaryFireReleased();
        inputMaster.Player.ShootSecondary_Press.performed += ctx => playerCombat.OnSecondaryFirePressed();
        inputMaster.Player.ShootSecondary_Release.performed += ctx => playerCombat.OnSecondaryFireReleased();
    }

    private void Update()
    {
        playerMovement.Execute();
        playerCombat.Execute();

        
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
