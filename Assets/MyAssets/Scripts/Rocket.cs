using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public LayerMask explosionMask;
    public float explosionForce = 1000f;
    public float explosionRadius = 10f;

    private void OnCollisionEnter(Collision col)
    {
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, explosionMask);
        List<Rigidbody> affectedRigidbodies = new List<Rigidbody>();

        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            if (rb != null && !affectedRigidbodies.Contains(rb))
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                affectedRigidbodies.Add(rb);
            }
        }
    }
}
