using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ElfController : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;
    public BoxCollider elfCollider;
    public LayerMask groundCheckMask;
    public float groundCheckDistance = .1f;
    public float groundCheckOriginYOffset = .05f;

    private Transform playerTrans;
    private bool reachedGround = false;

    private void Awake()
    {
        agent.enabled = false;
        playerTrans = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (reachedGround)
        {
            agent.SetDestination(playerTrans.position);
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
            agent.enabled = true;
            anim.SetTrigger("Landed");
        }
        else
        {
            reachedGround = false;
        }
    }
}
