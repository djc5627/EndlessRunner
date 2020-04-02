using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public abstract class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    public GameObject healthCanvas;
    public float maxHealth = 100f;
    public string deadLayerName = "DeadEnemyRagdoll";
    public Transform ragdollRoot;
    public AudioClip deathClip;
    public AudioSource audioSource;
    public float deathClipScale = 1f;

    protected PuppetMaster puppetMaster;
    protected bool isDead = false;
    protected float currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    protected virtual void Start()
    {
        puppetMaster = ragdollRoot.GetComponentInChildren<PuppetMaster>();
    }

    protected virtual void OnDeath()
    {
        if (isDead)
        {
            return;
        }

        audioSource.PlayOneShot(deathClip, deathClipScale);
        ragdollRoot.ChangeLayerRecursively(deadLayerName);
        puppetMaster.state = PuppetMaster.State.Dead;
        puppetMaster.Kill();
        puppetMaster.muscleWeight = 0f;
        puppetMaster.pinWeight = 0f;
        healthCanvas.SetActive(false);
        isDead = true;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }
}
