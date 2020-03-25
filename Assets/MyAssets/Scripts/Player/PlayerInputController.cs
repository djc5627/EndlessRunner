using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputController: MonoBehaviour
{
    public InputMaster inputMaster;
    
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

    private int playerNumber;
    private float moveInput;
    private bool isJumpHeld = false;
    private bool isPrimaryFireHeld = false;
    private bool isSecondaryFireHeld = false;
    private bool isAimDownSightsHeld = false;

    private void OnEnable()
    {
        inputMaster.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }

    private void Awake()
    {
        inputMaster = new InputMaster();

        //Movement
        inputMaster.Player.MoveInput.performed += ctx => { if (IsThisPlayersDevice(ctx)) OnMoveInput(ctx.ReadValue<float>()); };
        inputMaster.Player.Jump_Press.performed += ctx => { if (IsThisPlayersDevice(ctx)) OnJump_Press(ctx); };
        inputMaster.Player.Jump_Release.performed += ctx => { if (IsThisPlayersDevice(ctx)) OnJump_Release(); };

        //Combat
        inputMaster.Player.ShootPrimary_Press.performed += ctx => { if (IsThisPlayersDevice(ctx)) OnPrimaryFire_Press(); };
        inputMaster.Player.ShootPrimary_Release.performed += ctx => { if (IsThisPlayersDevice(ctx)) OnPrimaryFire_Release(); };
        inputMaster.Player.ShootSecondary_Press.performed += ctx => { if (IsThisPlayersDevice(ctx)) OnSecondaryFire_Press(); };
        inputMaster.Player.ShootSecondary_Release.performed += ctx => { if (IsThisPlayersDevice(ctx)) OnSecondaryFire_Release(); };
        inputMaster.Player.AimDownSights_Press.performed += ctx => { if (IsThisPlayersDevice(ctx)) OnAimDownSights_Press(); };
        inputMaster.Player.AimDownSights_Release.performed += ctx => { if (IsThisPlayersDevice(ctx)) OnAimDownSights_Release(); };
    }

    #region Input Receivers/Event Senders

    private void OnMoveInput(float moveInput)
    {
        this.moveInput = moveInput;
    }

    private void OnJump_Press(CallbackContext ctx)
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

    private void OnPrimaryFire_Press()
    {
        isPrimaryFireHeld = true;
        if (onPrimaryFire_Pressed != null) onPrimaryFire_Pressed();
    }

    private void OnPrimaryFire_Release()
    {
        isPrimaryFireHeld = false;
        if (onPrimaryFire_Released != null) onPrimaryFire_Released();
    }

    private void OnSecondaryFire_Press()
    {
        isSecondaryFireHeld = true;
        if (onSecondaryFire_Pressed != null) onSecondaryFire_Pressed();
    }

    private void OnSecondaryFire_Release()
    {
        isSecondaryFireHeld = false;
        if (onSecondaryFire_Released != null) onSecondaryFire_Released();
    }

    #endregion

    #region Helpers

    private bool IsThisPlayersDevice(CallbackContext ctx)
    {
        return (ctx.control.device == InputDeviceManager.GetPlayerDevice(playerNumber)) ? true : false;
    }

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

    public void SetPlayerNumber(int playerNumber)
    {
        this.playerNumber = playerNumber;
    }
}
