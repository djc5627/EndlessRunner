using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Haptics;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public InputMaster inputMaster;
    public PlayerAnimController playerAnimController;
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

        //Send references to behaviors
        playerMovement.SetPlayerAnimController(playerAnimController);
        playerCombat.SetPlayerAnimController(playerAnimController);

        //Movement
        inputMaster = new InputMaster();
        inputMaster.Player.MoveInput.performed += ctx => playerMovement.OnMoveInput(ctx.ReadValue<float>());
        inputMaster.Player.Jump_Press.performed += ctx => playerMovement.OnJump();
        inputMaster.Player.Jump_Release.performed += ctx => playerMovement.OnJumpReleased();

        //Combat
        inputMaster.Player.ShootPrimary_Press.performed += ctx => playerCombat.OnPrimaryFire_Pressed();
        inputMaster.Player.ShootPrimary_Release.performed += ctx => playerCombat.OnPrimaryFire_Released();
        inputMaster.Player.ShootSecondary_Press.performed += ctx => playerCombat.OnSecondaryFire_Pressed();
        inputMaster.Player.ShootSecondary_Release.performed += ctx => playerCombat.OnSecondaryFire_Released();

        inputMaster.Player.AimDownSights_Press.performed += ctx => playerCombat.OnAimDownSights_Pressed();
        inputMaster.Player.AimDownSights_Release.performed += ctx => playerCombat.OnAimDownSights_Released();
    }

    private void Update()
    {
        playerMovement.Execute();
        playerCombat.Execute();

        
        CheckDeathBarrier();
        HandleInvincibility();

        //Debug.Log(inputMaster.Player.AimDownSights.ReadValue<float>());
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
        playerAnimController.SetInvincibility(isInvincible);
    }
}
