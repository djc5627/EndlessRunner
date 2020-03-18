using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerController playerScript = col.gameObject.GetComponent<PlayerController>();
            //if (playerScript != null) playerScript.ResetLevel();
        }
    }
}
