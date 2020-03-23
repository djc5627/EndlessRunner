using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCombatBase : MonoBehaviour
{
    protected PlayerAnimController playerAnimController;
    protected bool primaryFireHeld = false;
    protected bool secondaryFireHeld = false;
    protected bool aimDownSightsHeld = false;

    public virtual void SetPlayerAnimController(PlayerAnimController playerAnimController)
    {
        this.playerAnimController = playerAnimController;
    }

    public abstract void Execute();

    public virtual void OnPrimaryFire_Pressed()
    {
        primaryFireHeld = true;
    }

    public virtual void OnPrimaryFire_Released()
    {
        primaryFireHeld = false;
    }

    public virtual void OnSecondaryFire_Pressed()
    {
        secondaryFireHeld = true;
    }

    public virtual void OnSecondaryFire_Released()
    {
        secondaryFireHeld = false;
    }

    public virtual void OnAimDownSights_Pressed()
    {
        aimDownSightsHeld = true;
    }

    public virtual void OnAimDownSights_Released()
    {
        aimDownSightsHeld = false;
    }
}
