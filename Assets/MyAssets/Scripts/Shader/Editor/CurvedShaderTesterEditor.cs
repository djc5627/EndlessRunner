using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CurvedShaderTester))]
public class CurvedShaderTesterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CurvedShaderTester curvedShaderScript = (CurvedShaderTester)target;

        if (GUILayout.Button("List Shaders to be Converted"))
        {
            curvedShaderScript.ListShadersToConvert();
        }

        if (GUILayout.Button("Convert Shaders"))
        {
            curvedShaderScript.ConvertShaders();
        }

        if (GUILayout.Button("Populate Curved Shader Mats"))
        {
            curvedShaderScript.PopulateCurvedShaderMats();
        }
    }
}
