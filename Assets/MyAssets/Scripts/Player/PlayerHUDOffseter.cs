using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHUDOffseter : MonoBehaviour
{
    public PlayerInputController playerInput;
    public RectTransform healthBarTrans;
    public float offset = 200f;

    private void Start()
    {
        int playerIndex = playerInput.GetPlayerIndex();
        float offsetAmount = Screen.width * (playerIndex / 4f);

        healthBarTrans.position = healthBarTrans.position + Vector3.right * offsetAmount;
        
    }
}
