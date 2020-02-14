using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MidiJack;


public class MIDIInput : MonoBehaviour
{
    public int knobNumber = 1;


    private void Update()
    {
        for (int i = 0; i < 1000; i++)
        {
            float value = MidiMaster.GetKnob(i);
            if (value != 0)
            {
                Debug.Log("Knob #" + i + " | Value: " + value);
            }
        }
    }
}
