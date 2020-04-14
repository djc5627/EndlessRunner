using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ProjectileBase
{
    public AudioClip impactSound_Flesh;
    public AudioClip impactSound_Object;
    public float impactSoundScale_Flesh = 1f;
    public float impactSoundScale_Object = 1f;
    public float damage = 15f;
    public float impactForce = 200f;

    protected override void HandleCollision(RaycastHit hit)
    {
        EnemyLimbProxy enemyProxy = hit.collider.GetComponent<EnemyLimbProxy>();
        if (enemyProxy != null)
        {
            enemyProxy.TakeDamage(damage);
        }

        //Audio
        if (hit.collider.gameObject.layer == LayerMask.NameToLayer("EnemyHurtCollider") ||
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
