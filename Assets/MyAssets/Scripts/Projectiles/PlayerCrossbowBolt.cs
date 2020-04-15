using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrossbowBolt : ProjectileBase
{
    public float damage = 20f;

    protected override void HandleCollision(RaycastHit hit)
    {
        EnemyLimbProxy enemyProxy = hit.collider.GetComponent<EnemyLimbProxy>();
        if (enemyProxy != null)
        {
            enemyProxy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
