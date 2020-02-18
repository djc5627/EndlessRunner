using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public Transform target;
    public float targetYOffset = 1f;

    void Update()
    {
        transform.position = new Vector3(target.position.x, targetYOffset, target.position.z);
    }
}
