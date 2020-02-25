using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elfcopter : Enemy
{
    public Rigidbody copterRb;
    public float moveSpeed = 10f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void FixedUpdate()
    {
        copterRb.velocity = Vector3.back * moveSpeed;
    }

    protected override void OnDeath()
    {
        base.OnDeath();
    }
}
