using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrossbowBolt : ProjectileBase
{
    public float damage = 20f;
    public AudioClip impactSound;
    public GameObject hitParticles;

    protected override void HandleCollision(RaycastHit hit)
    {
        EnemyLimbProxy enemyProxy = hit.collider.GetComponent<EnemyLimbProxy>();
        if (enemyProxy != null)
        {
            enemyProxy.TakeDamage(damage);

            Vector3 particlePosition = enemyProxy.enemyScript.transform.position;
            particlePosition.y = transform.position.y;
            Instantiate(hitParticles, particlePosition, Quaternion.identity);
        }

        GlobalAudioPlayer.Instance.PlayClipAt(impactSound, transform.position, 1f);
        Destroy(gameObject);
    }
}
