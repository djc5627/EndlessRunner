using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.Dynamics;

public abstract class Enemy : MonoBehaviour
{
    public float maxHealth = 100f;

    private float currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    protected abstract void OnDeath();

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnDeath();
        }
    }
}
