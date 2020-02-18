using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask collisionMask;
    public SphereCollider refTrigger;
    public float damage = 15f;
    public float impactForce = 200f;

    private Vector3 lastPos;

    private void Awake()
    {
        lastPos = transform.position;
    }

    private void FixedUpdate()
    {
        CheckForCollision();
        lastPos = transform.position;
    }

    private void CheckForCollision()
    {
        float lastToCurrentDistance = (transform.position - lastPos).magnitude;
        Vector3 lastToCurrentPos = (transform.position - lastPos).normalized;

        RaycastHit hit;
        if (Physics.SphereCast(refTrigger.bounds.center, refTrigger.radius, lastToCurrentPos, out hit, lastToCurrentDistance, collisionMask))
        {
            HandleImpact(hit);
        }
    }

    private void HandleImpact(RaycastHit hit)
    {
        Rigidbody otherRb = hit.collider.attachedRigidbody;
        if (otherRb != null)
        {
            Vector3 dir = (transform.position - lastPos).normalized;
            otherRb.AddForceAtPosition(dir * impactForce, hit.point);
        }
        ElfController elfScript = hit.collider.attachedRigidbody.GetComponent<ElfController>();
        if (elfScript != null)
        {
            elfScript.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
