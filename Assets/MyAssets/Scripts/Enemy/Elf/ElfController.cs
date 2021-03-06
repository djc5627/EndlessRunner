﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RootMotion.Dynamics;

public class ElfController : Enemy
{
    public Animator anim;
    public NavMeshAgent agent;
    public BoxCollider elfCollider;
    public ElfFlower elfFlower;
    public LayerMask groundCheckMask;
    public float groundCheckDistance = .1f;
    public float groundCheckOriginYOffset = .05f;
    public BoxCollider meleeCollider;
    public LayerMask attackMask;
    public float attackRadius = 3f;
    public float meleeDamage = 20f;
    public float timeToNextClipMin = 3f;
    public float timeToNextClipMax = 5f;
    public float clipVolumeScale = 5f;
    public float knockBackVelocity = 10f;
    public float knockBackDuration = 1f;
    public AudioClip[] elfSounds;

    private bool reachedGround = false;
    private bool isAttacking = false;
    private float lastSoundTime = Mathf.NegativeInfinity;
    private float nextClipTime;
    private float knockbackStartTime = Mathf.NegativeInfinity;

    protected override void Awake()
    {
        base.Awake();
        agent.enabled = false;
        nextClipTime = Random.Range(timeToNextClipMin, timeToNextClipMax);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (reachedGround)
        {
            agent.SetDestination(playerTrans.position);
        }

        HandleSounds();
        HandleAttacking();
    }

    private void FixedUpdate()
    {
        if (!reachedGround)
        {
            CheckGrounded();
        }
    }

    private void CheckGrounded()
    {
        Vector3 origin = elfCollider.bounds.center + (Vector3.up * groundCheckOriginYOffset);
        if (Physics.BoxCast(origin, elfCollider.bounds.extents, Vector3.down, transform.rotation, groundCheckDistance, groundCheckMask))
        {
            reachedGround = true;
            OnLand();
        }
        else
        {
            reachedGround = false;
        }
    }

    private void OnLand()
    {
        agent.enabled = true;
        anim.SetTrigger("Landed");
        elfFlower.Detatch();
    }

    private void HandleAttacking()
    {
        if (isAttacking)
        {
            return;
        }

        Vector3 vectorToPlayer = playerTrans.position - transform.position;
        vectorToPlayer.y = 0f;
        float distanceToPlayer = vectorToPlayer.magnitude;

        if (distanceToPlayer <= attackRadius)
        {
            anim.SetTrigger("Attack");
        }
    }

    private void HandleSounds()
    {
        if (lastSoundTime + nextClipTime < Time.time)
        {
            audioSource.PlayOneShot(PickRandomClip(elfSounds), clipVolumeScale);
            lastSoundTime = Time.time;
            nextClipTime = Random.Range(timeToNextClipMin, timeToNextClipMax);
        }
        
    }

    private AudioClip PickRandomClip(AudioClip[] clipArray)
    {
        int randIndex = Random.Range(0, clipArray.Length);
        return clipArray[randIndex];
    }

    protected override IEnumerator KnockbackRoutine()
    {
        if (!reachedGround) yield return null;
        anim.SetBool("isKnockedback", true);
        agent.updateRotation = false;
        knockbackStartTime = Time.time;
        Vector3 dir = (transform.position - playerTrans.position).normalized;

        while (knockbackStartTime + knockBackDuration > Time.time)
        {
            agent.velocity = dir * knockBackVelocity;
            yield return null;
        }

        anim.SetBool("isKnockedback", false);
        agent.velocity = Vector3.zero;
        agent.updateRotation = true;
    }

    protected override void OnDeath()
    {
        if (isDead)
        {
            return;
        }
        base.OnDeath();
        anim.enabled = false;
        elfCollider.enabled = false;
        agent.enabled = false;
        this.enabled = false;
    }

    #region Anim Events

    public void StartAttacking()
    {
        isAttacking = true;
    }

    public void StopAttacking()
    {
        isAttacking = false;
    }

    public void ExecuteMeleeAttack()
    {
        Collider[] overlappingColliders = Physics.OverlapBox(meleeCollider.bounds.center, meleeCollider.bounds.extents, meleeCollider.transform.rotation, attackMask);
        List<PlayerController> playersHit = new List<PlayerController>();
        foreach (Collider col in overlappingColliders)   //Get players in range
        {
            PlayerController playerScript = col.GetComponent<PlayerController>();
            if (playerScript != null && !playersHit.Contains(playerScript)) //Check if already hit player
            {
                playerScript.TakeDamage(meleeDamage);
                playersHit.Add(playerScript);
            }

        }
    }

    #endregion


}
