using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask collisionMask;
    public SphereCollider refTrigger;
    public AudioClip impactSound_Flesh;
    public AudioClip impactSound_Object;
    public float impactSoundScale_Flesh = 1f;
    public float impactSoundScale_Object = 1f;
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
        EnemyLimbProxy enemyProxy = hit.collider.attachedRigidbody.GetComponent<EnemyLimbProxy>();
        if (enemyProxy != null)
        {
            enemyProxy.TakeDamage(damage);
        }

        //Audio
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("EnemyMovCol") ||
            hit.collider.gameObject.layer == LayerMask.NameToLayer("EnemyRagdoll"))
        {
            GlobalAudioPlayer.Instance.PlayClipAt(impactSound_Flesh, hit.point, impactSoundScale_Flesh);
        }
        else
        {
            GlobalAudioPlayer.Instance.PlayClipAt(impactSound_Object, hit.point, impactSoundScale_Object);
        }

        
        Destroy(gameObject);
    }
}
