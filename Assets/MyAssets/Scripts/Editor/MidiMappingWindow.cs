using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MidiMappingWindow : EditorWindow
{
    private static float min, max;

    private static GameObject targetObject;
    private static GameObject midiSyncObj;

    [MenuItem("Window/MIDI Mappings")]
    public static void ShowWindow()
    {
        GetWindow<MidiMappingWindow>("MIDI Mapping");
    }

    private void OnGUI()
    {
        GUILayout.Label("MidiInputSync", EditorStyles.boldLabel);
        midiSyncObj = (GameObject)EditorGUILayout.ObjectField("TargetObj", targetObject, typeof(GameObject), true);

        GUILayout.Label("Knob 1", EditorStyles.boldLabel);
        targetObject = (GameObject) EditorGUILayout.ObjectField("TargetObj", targetObject, typeof(GameObject), true);

        if (targetObject != null)
        {
            foreach (Component component in targetObject.GetComponents<Component>())
            {
                SerializedObject serializedComponent = new SerializedObject(component);
                SerializedProperty prop = serializedComponent.FindProperty("forwardSpeed");
                if (prop != null)
                {
                    //MIDIInput.LinkToKnob(prop);
                    Debug.Log(prop.floatValue);

                    //Component midiSyncScript = midiSyncObj.GetComponent<MidiInputSync>();
                    //SerializedObject serializedMidiSync = new SerializedObject(midiSyncScript);
                    //SerializedProperty knob1Prop = serializedComponent.FindProperty("knob1Prop");
                }
            }
        }

        min = EditorGUILayout.FloatField("Min", min);
        max = EditorGUILayout.FloatField("Max", max);
    }
}
