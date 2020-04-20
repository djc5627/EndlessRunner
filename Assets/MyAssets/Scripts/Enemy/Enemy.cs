using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public abstract class Enemy : MonoBehaviour
{
    public Collider moveCollider;
    public Rigidbody moveRb;
    public Collider hurtCollider;
    public HealthBar healthBar;
    public GameObject healthCanvas;
    public float maxHealth = 100f;
    public AudioClip deathClip;
    public AudioSource audioSource;
    public GameObject armatureRoot;
    public float deathClipScale = 1f;
    public float deathForce = 10000f;

    protected Rigidbody[] ragdollRbs;
    protected Transform playerTrans;
    protected bool isDead = false;
    protected float currentHealth;
    

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        ragdollRbs = armatureRoot.GetComponentsInChildren<Rigidbody>();
    }

    protected virtual void Start()
    {
        playerTrans = FindObjectOfType<PlayerController>().transform;
    }

    protected virtual void OnDeath()
    {
        if (isDead)
        {
            return;
        }

        moveRb.isKinematic = true;
        moveCollider.enabled = false;
        hurtCollider.enabled = false;
        audioSource.PlayOneShot(deathClip, deathClipScale);
        healthCanvas.SetActive(false);
        ActivateRagdoll();
        ApplyDeathForce();
        isDead = true;
    }

    protected void ActivateRagdoll()
    {
        foreach (var rb in ragdollRbs)
        {
            rb.isKinematic = false;
        }
    }

    protected void ApplyDeathForce()
    {
        foreach (var rb in ragdollRbs)
        {
            Vector3 dir = (transform.position - playerTrans.position).normalized;
            rb.AddForce(dir * deathForce);
            rb.AddForce(Vector3.up * deathForce/3f);
        }
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
