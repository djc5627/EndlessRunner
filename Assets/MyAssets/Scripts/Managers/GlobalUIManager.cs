﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Singleton Class
/// </summary>
public class GlobalUIManager : MonoBehaviour
{
    public static GlobalUIManager Instance;

    public Transform canvasTrans;
    public GameObject textPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SpawnDamageText(Vector3 position, int damage, Color textColor)
    {
        GameObject textObj = Instantiate(textPrefab, canvasTrans);
        RectTransform textTrans = textObj.GetComponent<RectTransform>();
        TextMeshProUGUI textMesh = textObj.GetComponent<TextMeshProUGUI>();

        textTrans.position = position;
        textMesh.text = damage.ToString();
        textMesh.color = textColor;
    }
}
