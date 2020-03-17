using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Spawner spawnerScript = (Spawner)target;
        if (GUILayout.Button("Generate Level"))
        {
            spawnerScript.ClearLevel();
            spawnerScript.InitLevel();
        }
    }
}
