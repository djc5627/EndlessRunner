using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class JoinMenuController : MonoBehaviour
{
    public EndlessRunnerInputActions inputActions;

    public GameObject[] playerProps;

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Awake()
    {
        inputActions = new EndlessRunnerInputActions();

        inputActions.Menu.JoinGame.performed += ctx => OnJoinGame(ctx);
        inputActions.Menu.LeaveGame.performed += ctx => OnLeaveGame(ctx);
        inputActions.Menu.StartGame.performed += ctx => OnStartGame();

        //Hide props
        foreach(var playerProp in playerProps)
        {
            playerProp.SetActive(false);
        }
    }

    private void OnJoinGame(CallbackContext ctx)
    {
        if (InputDeviceManager.AddPlayer(ctx.control.device))
        {
            int playerNumber = InputDeviceManager.GetPlayerNumber(ctx.control.device);
            playerProps[playerNumber-1].SetActive(true);
            Debug.Log("Player " + playerNumber + " joined game");
        }
    }

    private void OnLeaveGame(CallbackContext ctx)
    {
        int playerNumber = InputDeviceManager.GetPlayerNumber(ctx.control.device);
        if (InputDeviceManager.RemovePlayer(ctx.control.device))
        {
            playerProps[playerNumber - 1].SetActive(false);
            Debug.Log("Player " + playerNumber + " left game");
        }
    }

    private void OnStartGame()
    {
        SceneManager.LoadScene("Main");
    }
}
