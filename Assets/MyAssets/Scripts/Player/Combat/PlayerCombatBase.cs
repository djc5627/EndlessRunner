using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCombatBase : MonoBehaviour
{
    protected bool primaryFireHeld = false;
    protected bool secondaryFireHeld = false;

    public abstract void Execute();

    public virtual void OnPrimaryFirePressed()
    {
        primaryFireHeld = true;
    }

    public virtual void OnPrimaryFireReleased()
    {
        primaryFireHeld = false;
    }

    public virtual void OnSecondaryFirePressed()
    {
        secondaryFireHeld = true;
    }

    public virtual void OnSecondaryFireReleased()
    {
        secondaryFireHeld = false;
    }
}
