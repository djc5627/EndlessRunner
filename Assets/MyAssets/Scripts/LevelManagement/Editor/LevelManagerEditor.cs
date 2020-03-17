using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelManager))]
public class LevelManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelManager levelManagerScript = (LevelManager)target;
        if (GUILayout.Button("Generate Level"))
        {
            levelManagerScript.ClearLevel();
            levelManagerScript.GenerateLevelInspector();
        }
    }
}
