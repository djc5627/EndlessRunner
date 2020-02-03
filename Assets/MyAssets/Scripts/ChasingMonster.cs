using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingMonster : MonoBehaviour
{
    public float moveSpeed = 20f;

    private Rigidbody monsterRb;

    private void Awake()
    {
        monsterRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        monsterRb.velocity = Vector3.forward * moveSpeed;
    }
}
