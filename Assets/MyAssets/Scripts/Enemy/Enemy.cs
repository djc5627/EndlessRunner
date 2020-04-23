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
    public Vector3 damageTextOffset = new Vector3(2f, 4f, 0f);

    protected Rigidbody[] ragdollRbs;
    protected Transform playerTrans;
    protected bool isDead = false;
    protected bool isIgnited = false;
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

    protected abstract IEnumerator KnockbackRoutine();

    protected IEnumerator IgniteRoutine(float totalDamge, float duration)
    {
        int ticksPerSecond = 2;
        float tickDuration = 1f / ticksPerSecond;
        float damagePerTick = totalDamge / (duration * ticksPerSecond);
        float igniteStartTime = Time.time;

        TakeDamage(damagePerTick, Color.red, false);
        float lastDamageTime = Time.time;

        while (igniteStartTime + duration > Time.time)
        {
            isIgnited = true;
            if (lastDamageTime + tickDuration <= Time.time)
            {
                int ticksPassed = (int) Mathf.Floor((Time.time - lastDamageTime)/ tickDuration);
                for (int i = 0; i < ticksPassed; i++)
                {
                    TakeDamage(damagePerTick, Color.red, false);
                    lastDamageTime = Time.time;
                }
            }
            yield return null;
        }

        isIgnited = false;
    }

    public virtual void TakeDamage(float damage, Color? damageTextColor = null, bool hasKnockback = true)
    {
        if (isDead) return;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (hasKnockback) StartCoroutine(KnockbackRoutine());
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + damageTextOffset);
        Color textColor = damageTextColor ?? Color.white;
        GlobalUIManager.Instance.SpawnDamageText(screenPos, (int) damage, textColor);
        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }

    public virtual void Ignite(float totalDamge, float duration)
    {
        StartCoroutine(IgniteRoutine(totalDamge, duration));
    }
}
