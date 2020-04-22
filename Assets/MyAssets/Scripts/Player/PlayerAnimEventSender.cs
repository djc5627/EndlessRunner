using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimEventSender : MonoBehaviour
{
    public PlayerAnimController animController;

    public void EnableSwordTrail()
    {
        animController.EnableSwordTrail();
    }

    public void DisableSwordTrail()
    {
        animController.DisableSwordTrail();
    }
}
