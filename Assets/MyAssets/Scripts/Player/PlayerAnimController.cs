﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    public Animator anim;
    public GameObject swordTrailObj;

    public void SetIsGrounded(bool isGrounded)
    {
        anim.SetBool("isGrounded", isGrounded);
    }

    public void JumpTrigger()
    {
        anim.SetTrigger("Jump");
    }

    public void SetInvincibility(bool isInvincible)
    {
        anim.SetBool("isInvincible", isInvincible);
    }

    public void SetADSPercent(float ADSPercent)
    {
        anim.SetFloat("ADSPercent", ADSPercent);
    }

    public void SetIsUsingRocket(bool isUsingRocket)
    {
        anim.SetBool("isUsingRocket", isUsingRocket);
    }

    public void MeleeAttackTrigger()
    {
        anim.SetTrigger("MeleeAttack");
    }

    public void EnableSwordTrail()
    {
        if (swordTrailObj != null) swordTrailObj.SetActive(true);
    }

    public void DisableSwordTrail()
    {
        if (swordTrailObj != null) swordTrailObj.SetActive(false);
    }
}
