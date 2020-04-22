using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MidiManagerEditor))]
public class MidiManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUI.ProgressBar(new Rect(10, 10, 50, 20), 50, "Armor");
        EditorUtility.DisplayProgressBar("title", "lots of info", .5f);
    }
}
