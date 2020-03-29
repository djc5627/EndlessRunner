using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    public LayerMask collisionMask;
    public SphereCollider refTrigger;

    protected Vector3 lastPos;
    private bool hasCollided = false;

    protected virtual void Awake()
    {
        lastPos = transform.position;
    }

    protected virtual void FixedUpdate()
    {
        if (!hasCollided)
        {
            CheckForCollision();
            lastPos = transform.position;
        }
    }

    protected virtual void CheckForCollision()
    {
        float lastToCurrentDistance = (transform.position - lastPos).magnitude;
        Vector3 lastToCurrentPos = (transform.position - lastPos).normalized;

        RaycastHit hit;
        if (Physics.SphereCast(lastPos, refTrigger.radius, lastToCurrentPos, out hit, lastToCurrentDistance, collisionMask))
        {
            HandleCollision(hit);
            hasCollided = true;
        }
    }

    protected abstract void HandleCollision(RaycastHit hit);
}
