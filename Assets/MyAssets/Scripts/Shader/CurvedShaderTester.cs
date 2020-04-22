using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;

[ExecuteInEditMode]
public class CurvedShaderTester : MonoBehaviour
{
    [Header("Shader Configuration")]
    [SerializeField] Shader ToonBendShader;
    [SerializeField] Shader TerrainBendShader;
    [SerializeField] private Material[] CurvedSurfaceMats;
    [Tooltip("Editor option to only show the world bend when this object or its parent is selected.")]
    [SerializeField] private bool ShowOnlyWhenSelected = true;
    [SerializeField] private float BendAmount = 1f;
    [SerializeField] private float BendFalloff = 1f;
    [SerializeField] private float BendFalloffStrength = 1f;

    [Header("Shader Conversion")]
    [SerializeField] private string DirectoryToSearch = "Assets/MyAssets";
    [SerializeField] private ShaderConversionPair[] ShadersToConvert;

    private bool showBend;
    public bool ShowBend
    {
        get { return showBend; }
        set { 
            showBend = value;
            if (showBend) SetBendEnabled(1f);
            else SetBendEnabled(0f);
        }
    }

    [System.Serializable]
    private struct ShaderConversionPair
    {
        public Shader fromShader;
        public Shader toShader;
    }

#if UNITY_EDITOR
    void OnValidate()
    {
        CheckBendVisible();
        SetShaderParams();
    }
#endif

    void Start()
    {
        SetShaderParams();
        if (!Application.isEditor)
        {
            ShowBend = true;
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Application.isEditor)
        {
            CheckBendVisible();
        }
#endif

        Shader.SetGlobalVector("_BEND_ORIGIN", transform.position);
        
    }

    private void UpdateBendOrigin()
    {
        foreach (Material m in CurvedSurfaceMats)
        {
            m.SetVector("_BendOrigin", transform.position);
        }
    }

#if UNITY_EDITOR
    private void CheckBendVisible()
    {
        if (!Application.isPlaying)
        {
            bool selected = !ShowOnlyWhenSelected || (Selection.activeGameObject == gameObject);
            ShowBend = selected;
        }
        else ShowBend = true;
    }
#endif

    private void SetBendEnabled(float enabled)
    {
        foreach (Material m in CurvedSurfaceMats)
        {
            m.SetFloat("_BendEnabled", enabled);
        }
    }
    
    private void SetShaderParams()
    {
        foreach (Material m in CurvedSurfaceMats)
        {
            m.SetFloat("_BendFalloff", BendFalloff);
            m.SetFloat("_BendFalloffStrength", BendFalloffStrength);
            m.SetVector("_BendAmount", new Vector3(0f,BendAmount,0f));
        }
    }
    
    private void ClearShaderParams()
    {
        foreach (Material m in CurvedSurfaceMats)
        {
            m.SetFloat("_BendFalloff", 0f);
            m.SetFloat("_BendFalloffStrength", 0f);
            m.SetVector("_BendAmount", Vector3.zero);
        }
    }

#if UNITY_EDITOR
    private List<Material> GetMaterialsWithShader(Shader shader)
    {
        List<Material> foundMaterials = new List<Material>();
        string shaderPath = AssetDatabase.GetAssetPath(shader);
        string[] allMaterials = AssetDatabase.FindAssets("t:Material", new[] { DirectoryToSearch });
        for (int i = 0; i < allMaterials.Length; i++)
        {
            allMaterials[i] = AssetDatabase.GUIDToAssetPath(allMaterials[i]);
            var material = AssetDatabase.LoadAssetAtPath<Material>(allMaterials[i]);
            if (material.shader == shader)
                foundMaterials.Add(material);
        }

        return foundMaterials;
    }


    #region InspectorButtonFunctions

    public void ListShadersToConvert()
    {
        int shaderCount = 0;
        foreach (ShaderConversionPair shaderPair in ShadersToConvert)
        {
            List<Material> shaderMatList = GetMaterialsWithShader(shaderPair.fromShader);

            foreach (var mat in shaderMatList)
            {
                Debug.Log("Found [" + mat.name + "] from {" + shaderPair.fromShader.name + "} to {" + shaderPair.toShader.name + "}");
                shaderCount++;
            }
        }
        Debug.Log("Found " + shaderCount + " shaders that are set for conversion!");
    }


    public void ConvertShaders()
    {
        int convertCount = 0;
        foreach(ShaderConversionPair shaderPair in ShadersToConvert)
        {
            //Stop if find null value
            if (shaderPair.fromShader == null || shaderPair.toShader == null)
            {
                Debug.LogError("One of the shader conversion pairs has null value! Stopping Conversion.");
                return;
            }

            List<Material> shaderMatList = GetMaterialsWithShader(shaderPair.fromShader);

            foreach (var mat in shaderMatList)
            {
                mat.shader = shaderPair.toShader;
                Debug.Log("Converted [" + mat.name + "] from {" + shaderPair.fromShader.name + "} to {" + shaderPair.toShader.name + "}");
                convertCount++;
            }
        }
        Debug.Log("Converted " + convertCount + " shaders!");
    }

    public void PopulateCurvedShaderMats()
    {
        SerializedObject so = new SerializedObject(this);
        SerializedProperty prop = so.FindProperty("CurvedSurfaceMats");

        List<Material> foundMats = new List<Material>();

        if (ToonBendShader != null) foundMats.AddRange(GetMaterialsWithShader(ToonBendShader));
        if (TerrainBendShader != null) foundMats.AddRange(GetMaterialsWithShader(TerrainBendShader));

        prop.arraySize = foundMats.Count;

        for (int i = 0; i < foundMats.Count; i++)
        {
            prop.GetArrayElementAtIndex(i).objectReferenceValue = foundMats[i];
        }

        so.ApplyModifiedProperties();
        Debug.Log("Populated with " + prop.arraySize + " Shaders!");
    }
    #endregion
#endif


}
