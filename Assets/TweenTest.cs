using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
    public float from = 0f;
    public float to = 10f;

    private float current;

    private void Start()
    {
        current = from;
        LeanTween.value(this.gameObject, v => current = v, from, to, 5f);
    }

    private void Update()
    {
        Debug.Log(current);
    }
}
