using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MidiJack;
using UnityEditor;


public static class MIDIInput
{
    public static void ShowMappingDebug()
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

    public static float GetKnob(int knobNumber, float min, float max)
    {
        float value;
        switch (knobNumber)
        {
            case (1):
                value = MidiMaster.GetKnob(74);
                break;
            case (2):
                value = MidiMaster.GetKnob(71);
                break;
            case (3):
                value = MidiMaster.GetKnob(5);
                break;
            case (4):
                value = MidiMaster.GetKnob(84);
                break;
            case (5):
                value = MidiMaster.GetKnob(78);
                break;
            case (6):
                value = MidiMaster.GetKnob(76);
                break;
            case (7):
                value = MidiMaster.GetKnob(77);
                break;
            case (8):
                value = MidiMaster.GetKnob(10);
                break;
            default:
                value = 0f;
                break;
        }
        return Mathf.Lerp(min, max, value);
    }




}
