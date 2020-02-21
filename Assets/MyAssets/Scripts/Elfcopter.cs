using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elfcopter : MonoBehaviour
{
    public Rigidbody copterRb;
    public float moveSpeed = 10f;


    private void FixedUpdate()
    {
        copterRb.velocity = Vector3.back * moveSpeed;
    }
}
