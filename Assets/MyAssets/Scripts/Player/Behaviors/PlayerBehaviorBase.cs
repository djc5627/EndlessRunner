using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehaviorBase : MonoBehaviour
{
    protected PlayerAnimController playerAnimController;
    protected PlayerInputController playerInput;

    protected abstract void SubscribeToInputEvents();

    public virtual void SetPlayerInput(PlayerInputController playerInput)
    {
        this.playerInput = playerInput;
        SubscribeToInputEvents();
    }

    public virtual void SetPlayerAnimController(PlayerAnimController playerAnimController)
    {
        this.playerAnimController = playerAnimController;
    }

    public abstract void Execute();
}
