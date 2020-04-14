using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : ProjectileBase
{
    public GameObject explosionEffect;
    public LayerMask explosionMask;
    public AudioClip explosionSound;
    public float explosionSoundScale = 1f;
    public float damage = 100f;
    public float explosionForceDelay = .05f;
    public float explosionForce = 1000f;
    public float explosionRadius = 10f;
    public float explosionZOffset = 3f;
    public float upwardsModifier = 3f;


    protected override void HandleCollision(RaycastHit hit)
    {
        Explode(hit.point);
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
            //Dont add force to hurt colliders
            if (rb != null && !affectedRigidbodies.Contains(rb) && col.gameObject.layer != LayerMask.NameToLayer("EnemyHurtCollider"))
            {
                affectedRigidbodies.Add(rb);
            }
        }

        //Deal damage to all the enemies hit
        foreach (Enemy enemyScript in affectedEnemies)
        {
            if(enemyScript != null) enemyScript.TakeDamage(damage);
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
