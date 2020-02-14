using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MidiMappingWindow : EditorWindow
{
    private static float min, max;

    private static GameObject scriptObj;
    private SerializedObject serializedObject;

    [MenuItem("Window/MIDI Mappings")]
    public static void ShowWindow()
    {
        GetWindow<MidiMappingWindow>("MIDI Mapping");
    }

    private void OnGUI()
    {
        GUILayout.Label("Knob 1", EditorStyles.boldLabel);

        //serializedObject = EditorGUILayout.ObjectField
        scriptObj = (GameObject) EditorGUILayout.ObjectField("TargetObj", scriptObj, typeof(GameObject), true);

        if (scriptObj != null)
        {
            foreach (Component component in scriptObj.GetComponents<Component>())
            {
                serializedObject = new SerializedObject(component);
                SerializedProperty prop = serializedObject.FindProperty("shootDelay");
                if (prop != null) Debug.Log(prop.floatValue);
            }
            //serializedObject = new SerializedObject(scriptObj);
            //SerializedProperty prop = serializedObject.FindProperty("shootDelay");
            //Debug.Log(prop.floatValue);
        }

        min = EditorGUILayout.FloatField("Min", min);
        max = EditorGUILayout.FloatField("Max", max);
    }
}
