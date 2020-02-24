using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosionEffect;
    public LayerMask explosionMask;
    public SphereCollider refTrigger;
    public AudioClip explosionSound;
    public float explosionSoundScale = 1f;
    public float damage = 100f;
    public float explosionForceDelay = .05f;
    public float explosionForce = 1000f;
    public float explosionRadius = 10f;
    public float explosionZOffset = 3f;
    public float upwardsModifier = 3f;

    private Vector3 lastPos;
    private bool hasCollided = false;

    private void Awake()
    {
        lastPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (!hasCollided)
        {
            CheckForCollision();
            lastPos = transform.position;
        }
        
    }

    private void CheckForCollision()
    {
        float lastToCurrentDistance = (transform.position - lastPos).magnitude;
        Vector3 lastToCurrentPos = (transform.position - lastPos).normalized;

        RaycastHit hit;
        if (Physics.SphereCast(refTrigger.bounds.center, refTrigger.radius, lastToCurrentPos, out hit, lastToCurrentDistance, explosionMask)) {
            Explode(hit.point);
            hasCollided = true;
        }
    }

    private void Explode(Vector3 origin)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, explosionMask);
        List<Enemy> affectedEnemies = new List<Enemy>();
        List<Rigidbody> affectedRigidbodies = new List<Rigidbody>();
        

        foreach (Collider col in colliders)
        {
            EnemyLimbProxy enemyProxy = col.GetComponent<EnemyLimbProxy>();
            if (enemyProxy != null && !affectedEnemies.Contains(enemyProxy.enemyScript))
            {
                affectedEnemies.Add(enemyProxy.enemyScript);
            }
            Rigidbody rb = col.attachedRigidbody;
            if (rb != null && !affectedRigidbodies.Contains(rb))
            {
                affectedRigidbodies.Add(rb);
            }
        }

        //Deal damage to all the enemies hit
        foreach (Enemy enemyScript in affectedEnemies)
        {
            enemyScript.TakeDamage(damage);
        }

        //Add the force with delay after rigidbodies are registered and damage delt
        StartCoroutine(ExecuteQueuedExplosion(affectedRigidbodies, origin));

        //Play explosion sound and effect
        GlobalAudioPlayer.Instance.PlayClipAt(explosionSound, origin, explosionSoundScale);
        GameObject tempEffect = Instantiate(explosionEffect, origin, Quaternion.identity);
        Destroy(tempEffect, 5f);
    }

    private IEnumerator ExecuteQueuedExplosion(List<Rigidbody> rigidbodies, Vector3 origin)
    {
        yield return new WaitForSeconds(explosionForceDelay);
        foreach (Rigidbody rb in rigidbodies)
        {
            rb.AddExplosionForce(explosionForce, origin + (Vector3.back * explosionZOffset), explosionRadius, upwardsModifier, ForceMode.Force);
        }

        Destroy(gameObject);
        yield return null;
    }
}
