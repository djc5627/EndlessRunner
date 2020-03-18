﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerMovementBase : MonoBehaviour
{
    public abstract void Move();
    public abstract void OnMoveInput(float moveInput);
    public abstract void OnJump();
    public abstract void OnJumpReleased();
}