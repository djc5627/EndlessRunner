using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public float targetYOffset = 1f;

    private Transform playerTrans;

    private void Start()
    {
        playerTrans = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        //transform.position = new Vector3(target.position.x, targetYOffset, target.position.z);
        transform.position = new Vector3(transform.position.x, targetYOffset, playerTrans.position.z);
    }
}
