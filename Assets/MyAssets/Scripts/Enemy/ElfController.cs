using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RootMotion.Dynamics;

public class ElfController : Enemy
{
    public Animator anim;
    public AudioSource audioSource;
    public NavMeshAgent agent;
    public BoxCollider elfCollider;
    public ElfFlower elfFlower;
    public PuppetMaster puppetMaster;
    public LayerMask groundCheckMask;
    public float groundCheckDistance = .1f;
    public float groundCheckOriginYOffset = .05f;
    public float timeToNextClipMin = 3f;
    public float timeToNextClipMax = 5f;
    public float clipVolumeScale = 5f;
    public AudioClip[] elfSounds;

    private Transform playerTrans;
    private bool reachedGround = false;
    private float lastSoundTime = Mathf.NegativeInfinity;
    private float nextClipTime;

    protected override void Awake()
    {
        base.Awake();
        agent.enabled = false;
        playerTrans = FindObjectOfType<Player>().transform;
        nextClipTime = Random.Range(timeToNextClipMin, timeToNextClipMax);
    }

    private void Update()
    {
        HandleSounds();

        if (reachedGround)
        {
            //agent.SetDestination(playerTrans.position);
            agent.SetDestination(transform.position + 10f * Vector3.back);
        }
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

    protected override void OnDeath()
    {
        puppetMaster.state = PuppetMaster.State.Dead;
        puppetMaster.Kill();
        puppetMaster.muscleWeight = 0f;
        puppetMaster.pinWeight = 0f;
        elfCollider.enabled = false;
        agent.enabled = false;
        this.enabled = false;
    }
}
