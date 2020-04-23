using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLimbProxy : MonoBehaviour
{
    public Enemy enemyScript;

    public void TakeDamage(float damage, Color? damageTextColor = null, bool hasKnockback = true)
    {
        enemyScript.TakeDamage(damage, damageTextColor, hasKnockback);
    }
}
