using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharControllerMovement : PlayerMovementBase
{
    public CharacterController charController;
    public LayerMask groundCheckMask;
    public float groundCheckDistance = .05f;
    public float groundCheckOriginYOffset = .45f;
    public float groundCheckJumpDelay = .1f;
    public float strafeSpeed = 12f;
    public float forwardSpeed = 20f;
    public float acceleration = .025f;
    public float deacceleration = .015f;
    public float timeToJumpApex = .5f;
    public float maxJumpHeight = 4f;
    public float fallMultiplier = 1.77f;
    public float lowJumpTurnTime = .5f;
    public float maxFallSpeed = 44f;

    private float moveInput;
    private float gravity;
    private float jumpVelocity;
    private float lastJumpTime = Mathf.NegativeInfinity;
    private float releaseJumpTime = Mathf.NegativeInfinity;
    private bool isGrounded;
    private bool hasRelasedJump = false;
    private bool doJump = false;

    private void Start()
    {
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    public override void Execute()
    {
        CheckGrounded();
        Move();
    }

    private void CheckGrounded()
    {
        //Delay after jump
        if (lastJumpTime + groundCheckJumpDelay > Time.time)
        {
            return;
        }

        RaycastHit hit;
        float halfHeight = charController.height / 2f;
        float distanceToPoints = halfHeight - charController.radius;
        Vector3 point1 = charController.bounds.center + (Vector3.up * distanceToPoints) + Vector3.up * groundCheckOriginYOffset;
        Vector3 point2 = charController.bounds.center - (Vector3.up * distanceToPoints) + Vector3.up * groundCheckOriginYOffset;
        if (Physics.CapsuleCast(point1, point2, charController.radius, Vector3.down, out hit, groundCheckDistance, groundCheckMask))
        {
            isGrounded = true;
            hasRelasedJump = false;
        }
        else
        {
            isGrounded = false;
        }

        PlayerAnimController.Instance.SetIsGrounded(isGrounded);
    }

    private void NormalizeMoveInput()
    {
        if (moveInput < Mathf.Epsilon && moveInput > -Mathf.Epsilon)
        {
            moveInput = 0f;
        }
        else if (moveInput > 0f)
        {
            moveInput = 1f;
        }
        else if (moveInput < 0f)
        {
            moveInput = -1f;
        }
    }

    public override void OnMoveInput(float moveInput)
    {
        NormalizeMoveInput();
        this.moveInput = moveInput;
    }

    public override void OnJump()
    {
        if (!isGrounded) return;

        PlayerAnimController.Instance.JumpTrigger();
        doJump = true;
        lastJumpTime = Time.time;
        isGrounded = false;
    }

    public override void OnJumpReleased()
    {
        hasRelasedJump = true;
        releaseJumpTime = Time.time;
    }

    private void Move()
    {
        float currentXSpeed = 0f;
        Vector3 actualVelocity = charController.velocity;
        float targetXSpeed = moveInput * strafeSpeed;
        Vector3 newVelocity = new Vector3(0f, actualVelocity.y, forwardSpeed);

        //---------Horizontal Movement-----------
        // if move input is basically zero, deaccellerate
        if (moveInput < Mathf.Epsilon && moveInput > -Mathf.Epsilon)
        {
            newVelocity.x = Mathf.SmoothDamp(actualVelocity.x, targetXSpeed, ref currentXSpeed, deacceleration);
        }
        else
        {
            newVelocity.x = Mathf.SmoothDamp(actualVelocity.x, targetXSpeed, ref currentXSpeed, acceleration);
        }

        //---------Vertical Movement-----------
        if (doJump)
        {
            newVelocity.y = jumpVelocity;
            doJump = false;
        }


        if (actualVelocity.y <= 0) //Falling
        {
            newVelocity.y += gravity * fallMultiplier * Time.deltaTime;
        }
        else if (actualVelocity.y > 0 && hasRelasedJump)    //Short jump
        {
            float percent = (Time.time - releaseJumpTime) / lowJumpTurnTime;
            newVelocity.y = Mathf.Lerp(newVelocity.y, 0f, percent);
        }
        else
        {
            newVelocity.y += gravity * Time.deltaTime;
        }
        if (newVelocity.y < -Mathf.Abs(maxFallSpeed))   //Cap Speed
        {
            newVelocity.y = -Mathf.Abs(maxFallSpeed);
        }

        charController.Move(newVelocity * Time.deltaTime);
    }
}
