using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProp : MonoBehaviour
{
    public float turnSpeed = 1;

    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, turnSpeed * Time.deltaTime, 0f);
    }
}
