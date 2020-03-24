using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfFlower : MonoBehaviour
{
    public Rigidbody flowerRb;
    public float floatAwaySpeed = 10f;

    private bool isDetached = false;

    private void Awake()
    {
        flowerRb.isKinematic = true;
    }

    private void FixedUpdate()
    {
        if (isDetached)
        {
            flowerRb.velocity = Vector3.up * floatAwaySpeed;
        }
    }

    public void Detatch()
    {
        isDetached = true;
        transform.parent = null;
        flowerRb.isKinematic = false;
    }
}
