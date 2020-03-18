using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Singelton class
/// </summary>
public class PlayerAnimController : MonoBehaviour
{
    public static PlayerAnimController Instance;

    public Animator anim;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
            
        else
        {
            Destroy(this);
        }
    }

    public void SetIsGrounded(bool isGrounded)
    {
        anim.SetBool("isGrounded", isGrounded);
    }

    public void JumpTrigger()
    {
        anim.SetTrigger("Jump");
    }
}
