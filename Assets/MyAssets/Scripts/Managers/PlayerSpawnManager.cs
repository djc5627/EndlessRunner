using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

/// <summary>
/// Singleton Class
/// </summary>
public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager Instance;

    public GameObject defaultPlayer;
    public GameObject playerPrefab;
    public Transform playerContainer;
    public Transform[] playerSpawns;

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


        Destroy(defaultPlayer);
        SpawnPlayers();
    }

    private void SpawnPlayers()
    {
        //If no current players, spawn one
        if (InputDeviceManager.GetCurrentPlayerCount() == 0)
        {
            int playerIndex = 0;
            GameObject tempPlayer = PlayerInput.Instantiate(playerPrefab, playerIndex, "Gamepad", -1, InputDeviceManager.GetPlayerDevice(playerIndex)).gameObject;
            tempPlayer.gameObject.GetComponent<PlayerInputController>().SetPlayerIndex(playerIndex);

            Transform playerObj = tempPlayer.transform.root;
            playerObj.position = playerSpawns[0].position;
            playerObj.parent = playerContainer;
        }


        int maxPlayers = InputDeviceManager.GetMaxPlayerCount();
        for (int i = 0; i < maxPlayers; i++)
        {
            if (InputDeviceManager.GetPlayerDevice(i) != null)
            {
                int playerIndex = i;
                GameObject tempPlayer = PlayerInput.Instantiate(playerPrefab, playerIndex, "Gamepad", -1, InputDeviceManager.GetPlayerDevice(playerIndex)).gameObject;
                tempPlayer.gameObject.GetComponent<PlayerInputController>().SetPlayerIndex(playerIndex);

                Transform playerObj = tempPlayer.transform.root;
                playerObj.position = playerSpawns[i].position;
                playerObj.parent = playerContainer;
            }
        }
    }
}
