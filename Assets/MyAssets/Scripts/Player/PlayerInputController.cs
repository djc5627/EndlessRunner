using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputController: MonoBehaviour
{
    public delegate void _OnJump_Pressed();
    public delegate void _OnJump_Released();
    public delegate void _OnPrimaryFire_Pressed();
    public delegate void _OnPrimaryFire_Released();
    public delegate void _OnSecondaryFire_Pressed();
    public delegate void _OnSecondaryFire_Released();
    public delegate void _OnAimDownSights_Pressed();
    public delegate void _OnAimDownSights_Released();

    public event _OnJump_Pressed onJump_Pressed;
    public event _OnJump_Released onJump_Released;
    public event _OnPrimaryFire_Pressed onPrimaryFire_Pressed;
    public event _OnPrimaryFire_Released onPrimaryFire_Released;
    public event _OnSecondaryFire_Pressed onSecondaryFire_Pressed;
    public event _OnSecondaryFire_Released onSecondaryFire_Released;
    public event _OnAimDownSights_Pressed onAimDownSights_Pressed;
    public event _OnAimDownSights_Released onAimDownSights_Released;

    private int playerIndex = -1;
    private float moveInput;
    private bool isJumpHeld = false;
    private bool isPrimaryFireHeld = false;
    private bool isSecondaryFireHeld = false;
    private bool isAimDownSightsHeld = false;

    private void OnTest()
    {
        Debug.LogError("shiieet");
    }

    #region Input Receivers/Event Senders

    private void OnMoveInput(InputValue value)
    {
        this.moveInput = value.Get<float>();
    }

    private void OnJump_Press()
    {
        isJumpHeld = true;
        if(onJump_Pressed != null) onJump_Pressed();
    }

    private void OnJump_Release()
    {
        isJumpHeld = false;
        if (onJump_Released != null) onJump_Released();
    }

    private void OnAimDownSights_Press()
    {
        isAimDownSightsHeld = true;
        if (onAimDownSights_Pressed != null) onAimDownSights_Pressed();
    }

    private void OnAimDownSights_Release()
    {
        isAimDownSightsHeld = false;
        if (onAimDownSights_Released != null) onAimDownSights_Released();
    }

    private void OnShootPrimary_Press()
    {
        isPrimaryFireHeld = true;
        if (onPrimaryFire_Pressed != null) onPrimaryFire_Pressed();
    }

    private void OnShootPrimary_Release()
    {
        isPrimaryFireHeld = false;
        if (onPrimaryFire_Released != null) onPrimaryFire_Released();
    }

    private void OnShootSecondary_Press()
    {
        isSecondaryFireHeld = true;
        if (onSecondaryFire_Pressed != null) onSecondaryFire_Pressed();
    }

    private void OnShootSecondary_Release()
    {
        isSecondaryFireHeld = false;
        if (onSecondaryFire_Released != null) onSecondaryFire_Released();
    }

    #endregion

    #region Helpers

    private float RoundMoveInput(float moveInput)
    {
        if (moveInput < Mathf.Epsilon && moveInput > -Mathf.Epsilon)
        {
            moveInput = 0f;
        }
        else if (moveInput > 0f)
        {
            moveInput = 1f;
        }
        else if (moveInput < 0f)
        {
            moveInput = -1f;
        }

        return moveInput;
    }

    #endregion

    #region Public Getters

    public int GetPlayerIndex()
    {
        return this.playerIndex;
    }

    public float GetMoveInput()
    {
        return this.moveInput;
    }

    public float GetRoundedMoveInput()
    {
        return RoundMoveInput(this.moveInput);
    }

    public bool GetIsJumpHeld()
    {
        return this.isJumpHeld;
    }

    public bool GetIsPrimaryFireHeld()
    {
        return this.isPrimaryFireHeld;
    }

    public bool GetIsSecondaryFireHeld()
    {
        return this.isSecondaryFireHeld;
    }

    public bool GetIsAimDownSightHeld()
    {
        return this.isAimDownSightsHeld;
    }

    #endregion

    public void SetPlayerIndex(int playerIndex)
    {
        this.playerIndex = playerIndex;
    }
}
