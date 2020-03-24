using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MenuInputManager : MonoBehaviour
{
    public InputMaster inputMaster;

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

        inputMaster.Menu.JoinGame.performed += ctx => OnJoinGame(ctx);
        inputMaster.Menu.LeaveGame.performed += ctx => OnLeaveGame(ctx);
    }

    private void OnJoinGame(CallbackContext ctx)
    {
        if (InputDeviceManager.AddPlayer(ctx.control.device))
        {
            int playerNumber = InputDeviceManager.GetPlayerNumber(ctx.control.device);
            Debug.Log("Player " + playerNumber + " joined game");
        }
    }

    private void OnLeaveGame(CallbackContext ctx)
    {
        int playerNumber = InputDeviceManager.GetPlayerNumber(ctx.control.device);
        if (InputDeviceManager.RemovePlayer(ctx.control.device))
        {
            Debug.Log("Player " + playerNumber + " left game");
        }
    }
}
