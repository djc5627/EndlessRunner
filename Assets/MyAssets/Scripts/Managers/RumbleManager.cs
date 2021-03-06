﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Haptics;

//Singleton class
public class RumbleManager : MonoBehaviour
{
    public static RumbleManager Instance;

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

    }

    private IEnumerator RumbleRoutine(IDualMotorRumble rumble, float lowFreq, float highFreq, float duration)
    {
        float rumbleStartTime = Time.time;

        while (rumbleStartTime + duration > Time.time)
        {
            rumble.SetMotorSpeeds(lowFreq, highFreq);
            yield return null;
        }

        rumble.ResetHaptics();

    }

    //If dont give device, just use current gamepad
    public void StartRumble(float lowFreq, float highFreq, float duration)
    {
        if (Gamepad.current == null || Gamepad.current.device == null)
        {
            return;
        }

        StartRumble(Gamepad.current.device, lowFreq, highFreq, duration);
    }

    public void StartRumble(InputDevice device, float lowFreq, float highFreq, float duration)
    {
        //If not a rumble device, return
        if (device is IDualMotorRumble rumble)
        {
            StartCoroutine(RumbleRoutine(rumble, lowFreq, highFreq, duration));
        }
    }

    
}
