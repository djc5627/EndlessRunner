using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : ProjectileBase
{
    public GameObject explosionEffect;
    public LayerMask explosionMask;
    public AudioClip explosionSound;
    public float explosionSoundScale = 1f;
    public float explosionRadius = 20f;
    public float impactDamage = 100f;
    public float igniteTotalDamage = 20f;
    public float igniteDuration = 5f;

    protected override void HandleCollision(RaycastHit hit)
    {
        Explode(hit.point);
    }

    private void Explode(Vector3 origin)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, explosionMask);
        List<Enemy> affectedEnemies = new List<Enemy>();

        foreach (Collider col in colliders)
        {
            EnemyLimbProxy enemyProxy = col.GetComponent<EnemyLimbProxy>();
            if (enemyProxy != null && !affectedEnemies.Contains(enemyProxy.enemyScript))
            {
                affectedEnemies.Add(enemyProxy.enemyScript);
            }
        }

        //Deal damage to all the enemies hit
        foreach (Enemy enemyScript in affectedEnemies)
        {
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(impactDamage);
                enemyScript.Ignite(igniteTotalDamage, igniteDuration);
            }
        }

        //Play explosion sound and effect
        if (explosionSound != null)
        {
            GlobalAudioPlayer.Instance.PlayClipAt(explosionSound, origin, explosionSoundScale);
        }
        if (explosionEffect != null)
        {
            GameObject tempEffect = Instantiate(explosionEffect, origin, Quaternion.identity);
            Destroy(tempEffect, 5f);
        }
        Destroy(gameObject);
            
    }
}
