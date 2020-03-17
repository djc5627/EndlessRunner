using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public abstract class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;
    public string deadLayerName = "DeadEnemyRagdoll";
    public Transform ragdollRoot;
    public AudioClip deathClip;
    public AudioSource audioSource;
    public float deathClipScale = 1f;


    private bool isDead = false;

    private float currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    protected virtual void OnDeath()
    {
        if (isDead)
        {
            return;
        }

        audioSource.PlayOneShot(deathClip, deathClipScale);
        ragdollRoot.ChangeLayerRecursively(deadLayerName);
        isDead = true;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }
}
