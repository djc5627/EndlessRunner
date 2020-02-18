using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MidiManager : MonoBehaviour
{
    [Header("Knob 1")]
    public GameObject obj_Knob1;
    public string fieldName_Knob1;
    public float min_Knob1;
    public float max_Knob1;

    private void Update()
    {
        foreach (Component component in obj_Knob1.GetComponents<Component>())
        {
            SerializedObject serializedComponent = new SerializedObject(component);
            SerializedProperty prop = serializedComponent.FindProperty(fieldName_Knob1);
            if (prop != null)
            {
                Debug.Log(prop.floatValue);
                prop.floatValue = MIDIInput.GetKnob(1, min_Knob1, max_Knob1);


            }
        }
    }
}
