using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementBase : MonoBehaviour
{
    protected PlayerAnimController playerAnimController;
    protected bool aimDownSightsHeld = false;

    public virtual void SetPlayerAnimController(PlayerAnimController playerAnimController)
    {
        this.playerAnimController = playerAnimController;
    }

    public abstract void Execute();
    public abstract void OnMoveInput(float moveInput);
    public abstract void OnJump();
    public abstract void OnJumpReleased();

    public virtual void OnAimDownSights_Pressed()
    {
        aimDownSightsHeld = true;
    }

    public virtual void OnAimDownSights_Released()
    {
        aimDownSightsHeld = false;
    }
}
