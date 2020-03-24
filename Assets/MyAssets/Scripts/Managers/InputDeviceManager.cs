using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputDeviceManager
{
    private static int maxPlayers = 4;
    private static InputDevice[] inputDevices = { null, null, null, null };
    private static int currentPlayerCount = 0;

    private static bool DeviceIsPresent(InputDevice device)
    {
        foreach (var iDevice in inputDevices)
        {
            if (iDevice == device) return true;
        }
        return false;
    }

    private static bool IsMaxPlayersReached()
    {
        return (currentPlayerCount == maxPlayers) ? true : false;
    }

    //Return -1 if something goes wrong
    private static int FindNextOpenIndex()
    {
        if (currentPlayerCount == 0)
        {
            return 0;
        }
        else
        {
            foreach (var iDevice in inputDevices)
            {
                if (iDevice == null) return System.Array.IndexOf(inputDevices, iDevice);
            }
        }

        return -1;
    }

    // Returns -1 if cant find player
    public static int GetPlayerIndex(InputDevice device)
    {
        return System.Array.IndexOf(inputDevices, device);
    }

    /// <summary>
    /// Returns true on success
    /// </summary>
    /// <param name="device"></param>
    /// <returns></returns>
    public static bool AddPlayer(InputDevice device)
    {
        if (DeviceIsPresent(device) || IsMaxPlayersReached()) return false;

        int playerIndex = FindNextOpenIndex();
        inputDevices[playerIndex] = device;
        currentPlayerCount++;
        return true;
    }

    /// <summary>
    /// Returns true on success
    /// </summary>
    /// <param name="device"></param>
    /// <returns></returns>
    public static bool RemovePlayer(InputDevice device)
    {
        int playerIndex = GetPlayerIndex(device);
        if (!DeviceIsPresent(device) || playerIndex == -1) return false;
        
        inputDevices[playerIndex] = null;
        currentPlayerCount--;
        return true;
    }

    /// <summary>
    /// Returns null if not found
    /// </summary>
    /// <param name="playerNumber"></param>
    /// <returns></returns>
    public static InputDevice GetPlayerDevice(int playerNumber)
    {
        if (playerNumber < 1 || playerNumber > maxPlayers)
        {
            return null;
        }

        return inputDevices[playerNumber - 1];
    }

    /// <summary>
    /// Returns -1 if cant find player
    /// </summary>
    /// <param name="device"></param>
    /// <returns></returns>
    public static int GetPlayerNumber(InputDevice device)
    {
        return GetPlayerIndex(device) + 1;
    }
}
