using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfAnimEventSender : MonoBehaviour
{
    public ElfController elfScript;

    public void StartAttacking()
    {
        elfScript.StartAttacking();
    }

    public void StopAttacking()
    {
        elfScript.StopAttacking();
    }

    public void ExecuteMeleeAttack()
    {
        elfScript.ExecuteMeleeAttack();
    }
}
