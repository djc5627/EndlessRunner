using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public abstract class Enemy : MonoBehaviour
{
    public Collider moveCollider;
    public Collider hurtCollider;
    public HealthBar healthBar;
    public GameObject healthCanvas;
    public float maxHealth = 100f;
    public AudioClip deathClip;
    public AudioSource audioSource;
    public float deathClipScale = 1f;
    public float deathForce = 10000f;
    public GameObject ragdollPrefab;
    public SkinnedMeshRenderer rendToDisableOnDeath;

    protected Transform playerTrans;
    protected bool isDead = false;
    protected float currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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

        moveCollider.enabled = false;
        hurtCollider.enabled = false;
        if (ragdollPrefab != null)
        {
            GameObject ragdoll = Instantiate(ragdollPrefab, transform.position, transform.rotation);
            ApplyDeathForce(ragdoll);
        }
        rendToDisableOnDeath.enabled = false;
        audioSource.PlayOneShot(deathClip, deathClipScale);
        healthCanvas.SetActive(false);
        isDead = true;
    }

    protected void ApplyDeathForce(GameObject ragdollRoot)
    {
        Rigidbody[] ragdollRbs = ragdollRoot.GetComponentsInChildren<Rigidbody>();
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
