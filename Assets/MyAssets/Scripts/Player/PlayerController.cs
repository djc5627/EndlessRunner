using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Haptics;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public PlayerInputController playerInput;
    public PlayerAnimController playerAnimController;
    public PlayerBehaviorBase[] playerBehaviors;
    public HealthBar healthBar;
    public float maxHealth = 10f;
    public float invicibilityTime = 1.5f;
    public float deathBarrierYOffset = -50f;
    [SerializeField] public SkinnedMeshRenderer playerSkinRend;
    public Material[] playerBodyMats;
    
    private float currentHealth;
    private float lastDamageTime = Mathf.NegativeInfinity;
    private bool isInvincible = false;


    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //Send references to behaviors
        foreach (var behavior in playerBehaviors)
        {
            behavior.SetPlayerInput(playerInput);
            behavior.SetPlayerAnimController(playerAnimController);
        }
    }

    private void Start()
    {
        SetBodyMaterial();
    }

    private void Update()
    {
        //Execute each behavior (in order of assignment)
        foreach (var behavior in playerBehaviors)
        {
            behavior.Execute();
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

    public void SetBodyMaterial()
    {
        int playerIndex = playerInput.GetPlayerIndex();
        if (playerIndex != -1 && playerBodyMats[playerIndex] != null)
        {
            Material[] playerMats = playerSkinRend.materials;
            playerMats[5] = playerBodyMats[playerIndex];
            playerSkinRend.materials = playerMats;
        }
        
    }
}
