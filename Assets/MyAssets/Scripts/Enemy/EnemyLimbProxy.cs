using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLimbProxy : MonoBehaviour
{
    public Enemy enemyScript;

    public void TakeDamage(float damage)
    {
        enemyScript.TakeDamage(damage);
    }
}
