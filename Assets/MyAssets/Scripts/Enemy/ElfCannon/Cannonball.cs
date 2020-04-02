using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : ProjectileBase
{
    public float damage = 20f;

    protected override void HandleCollision(RaycastHit hit)
    {

        Rigidbody otherRb = hit.collider.attachedRigidbody;
        if (otherRb != null)
        {
            PlayerController playerController = otherRb.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}