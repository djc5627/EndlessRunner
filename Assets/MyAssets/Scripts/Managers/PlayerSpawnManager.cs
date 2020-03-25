using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

/// <summary>
/// Singleton Class
/// </summary>
public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager Instance;

    public InputMaster inputMaster;
    public GameObject defaultPlayer;
    public GameObject playerPrefab;
    public Transform playerContainer;
    public Transform[] playerSpawns;

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
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        inputMaster = new InputMaster();
        Destroy(defaultPlayer);
        SpawnPlayers();

        //If no devices connect, wait for first one to join
        if (InputDeviceManager.GetCurrentPlayerCount() == 0)
        {
            inputMaster.Menu.JoinGame.performed += ctx => OnJoinGame(ctx);
        }
        
    }

    private void SpawnPlayers()
    {
        //If not current players, spawn one
        if (InputDeviceManager.GetCurrentPlayerCount() == 0)
        {
            GameObject tempPlayer = Instantiate(playerPrefab, playerSpawns[0].position, Quaternion.identity, playerContainer);
            PlayerInputController inputScript = tempPlayer.GetComponentInChildren<PlayerInputController>();
            inputScript.SetPlayerNumber(1);
        }


        int maxPlayers = InputDeviceManager.GetMaxPlayerCount();
        for (int i = 0; i < maxPlayers; i++)
        {
            if (InputDeviceManager.GetPlayerDevice(i+1) != null)
            {
                GameObject tempPlayer = Instantiate(playerPrefab, playerSpawns[i].position, Quaternion.identity, playerContainer);
                PlayerInputController inputScript = tempPlayer.GetComponentInChildren<PlayerInputController>();
                inputScript.SetPlayerNumber(i + 1);
            }
        }
    }

    private void OnJoinGame(CallbackContext ctx)
    {
        InputDeviceManager.AddPlayer(ctx.control.device);
    }


}
