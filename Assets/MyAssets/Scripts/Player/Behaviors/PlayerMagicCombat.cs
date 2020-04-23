using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicCombat : PlayerBehaviorBase
{
    public Transform magicFirePoint;
    public Transform projectileContainer;
    public GameObject fireballPrefab;
    public float fireballCooldown = 5f;
    public float fireballShootVelocity = 30f;
    public AudioClip fireballCastSound;

    private AudioSource audioSource;
    private float lastFireballShootTime = Mathf.NegativeInfinity;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected override void SubscribeToInputEvents()
    {
        playerInput.onMagicSpell_1_Pressed += AttemptShootFireball;
    }

    public override void Execute()
    {

    }

    private void AttemptShootFireball()
    {
        if (lastFireballShootTime + fireballCooldown <= Time.time)
        {
            ShootFireball();
        }
    }

    private void ShootFireball()
    {
        GameObject tempFireball = Instantiate(fireballPrefab, magicFirePoint.position, Quaternion.identity, projectileContainer);
        Rigidbody fireballRb = tempFireball.GetComponent<Rigidbody>();
        fireballRb.velocity = magicFirePoint.forward * fireballShootVelocity;
        lastFireballShootTime = Time.time;

        if (fireballCastSound != null) audioSource.PlayOneShot(fireballCastSound);
    }
}
