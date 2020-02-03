using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosionEffect;
    public LayerMask explosionMask;
    public SphereCollider refTrigger;
    public float explosionForce = 1000f;
    public float explosionRadius = 10f;
    public float explosionZOffset = 3f;
    public float upwardsModifier = 3f;

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
        if (Physics.SphereCast(refTrigger.bounds.center, refTrigger.radius, lastToCurrentPos, out hit, lastToCurrentDistance, explosionMask)) {
            Explode(hit.point);
        }
    }

    private void Explode(Vector3 origin)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, explosionMask);
        List<Rigidbody> affectedRigidbodies = new List<Rigidbody>();
        

        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            if (rb != null && !affectedRigidbodies.Contains(rb))
            {
                rb.AddExplosionForce(explosionForce, origin + (Vector3.back * explosionZOffset), explosionRadius, upwardsModifier, ForceMode.Force);
                affectedRigidbodies.Add(rb);
            }
        }

        GameObject tempEffect = Instantiate(explosionEffect, origin, Quaternion.identity);
        Destroy(tempEffect, 5f);
        Destroy(gameObject);
    }
}
