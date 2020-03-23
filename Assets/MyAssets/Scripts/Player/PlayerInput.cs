using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public InputMaster inputMaster;

    public delegate void OnJump_Pressed();
    public delegate void OnJump_Released();
    public delegate void OnPrimaryFire_Pressed();
    public delegate void OnPrimaryFire_Released();
    public delegate void OnSecondaryFire_Pressed();
    public delegate void OnSecondaryFire_Released();
    public delegate void OnAimDownSights_Pressed();
    public delegate void OnAimDownSights_Released();

    public event OnJump_Pressed onJump_Pressed;
    public event OnJump_Released onJump_Released;
    public event OnPrimaryFire_Pressed onPrimaryFire_Pressed;
    public event OnPrimaryFire_Released onPrimaryFire_Released;
    public event OnSecondaryFire_Pressed onSecondaryFire_Pressed;
    public event OnSecondaryFire_Released onSecondaryFire_Released;
    public event OnAimDownSights_Pressed onAimDownSights_Pressed;
    public event OnAimDownSights_Released onAimDownSights_Released;

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
        //Movement
        inputMaster = new InputMaster();
        inputMaster.Player.MoveInput.performed += ctx => MoveInput(ctx.ReadValue<float>());
        inputMaster.Player.Jump_Press.performed += ctx => Jump_Pressed();
        inputMaster.Player.Jump_Release.performed += ctx => Jump_Released();

        //Combat
        inputMaster.Player.ShootPrimary_Press.performed += ctx => PrimaryFire_Pressed();
        inputMaster.Player.ShootPrimary_Release.performed += ctx => PrimaryFire_Released();
        inputMaster.Player.ShootSecondary_Press.performed += ctx => SecondaryFire_Pressed();
        inputMaster.Player.ShootSecondary_Release.performed += ctx => SecondaryFire_Released();
        inputMaster.Player.AimDownSights_Press.performed += ctx => AimDownSights_Pressed();
        inputMaster.Player.AimDownSights_Release.performed += ctx => AimDownSights_Released();
    }

    #region Input Receivers/Event Senders

    private void MoveInput(float moveInput)
    {
        this.moveInput = moveInput;
    }

    private void Jump_Pressed()
    {
        isJumpHeld = true;
        if(onJump_Pressed != null) onJump_Pressed();
    }

    private void Jump_Released()
    {
        isJumpHeld = false;
        if (onJump_Released != null) onJump_Released();
    }

    private void AimDownSights_Pressed()
    {
        isAimDownSightsHeld = true;
        if (onAimDownSights_Pressed != null) onAimDownSights_Pressed();
    }

    private void AimDownSights_Released()
    {
        isAimDownSightsHeld = false;
        if (onAimDownSights_Released != null) onAimDownSights_Released();
    }

    private void PrimaryFire_Pressed()
    {
        isPrimaryFireHeld = true;
        if (onPrimaryFire_Pressed != null) onPrimaryFire_Pressed();
    }

    private void PrimaryFire_Released()
    {
        isPrimaryFireHeld = false;
        if (onPrimaryFire_Released != null) onPrimaryFire_Released();
    }

    private void SecondaryFire_Pressed()
    {
        isSecondaryFireHeld = true;
        if (onSecondaryFire_Pressed != null) onSecondaryFire_Pressed();
    }

    private void SecondaryFire_Released()
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
}
