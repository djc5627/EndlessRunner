using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public RectTransform textTrans;
    public TextMeshProUGUI textMesh;
    public float damageTextFadeTime = .5f;
    public float fadeYDistance = 10f;
    public float fadeEndScaleFactor = .5f;
  
    void Start()
    {
        textMesh.overrideColorTags = true;
        Color32 currentColor = textMesh.color;
        LeanTween.value(this.gameObject, d => textTrans.position = d, textTrans.position, textTrans.position + Vector3.up * fadeYDistance, damageTextFadeTime).setEase(LeanTweenType.easeInQuad);
        LeanTween.value(this.gameObject, a => textMesh.color = new Color32(currentColor.r, currentColor.g, currentColor.b, (byte) a), 255, 0, damageTextFadeTime).setEase(LeanTweenType.easeInQuad);
        LeanTween.value(this.gameObject, s => textTrans.localScale = s, Vector3.one, Vector3.one* fadeEndScaleFactor, damageTextFadeTime).setOnComplete(DestroyMe);
    }

    private void DestroyMe()
    {
        Destroy(this.gameObject);
    }
}
