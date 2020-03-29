using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharControllerMovement : PlayerBehaviorBase
{
    public CharacterController charController;
    public LayerMask groundCheckMask;
    public float groundCheckDistance = .05f;
    public float groundCheckOriginYOffset = .45f;
    public float groundCheckJumpDelay = .1f;
    public float strafeSpeed = 12f;
    public float aimedStrafeSpeed = 6f;
    public float aimDownSightsTime = .1f;
    public float forwardSpeed = 20f;
    public float acceleration = .025f;
    public float deacceleration = .015f;
    public float timeToJumpApex = .5f;
    public float maxJumpHeight = 4f;
    public float fallMultiplier = 1.77f;
    public float lowJumpTurnTime = .5f;
    public float maxFallSpeed = 44f;

    private int startADSTweenId;
    private int stopADSTweenId;
    private float gravity;
    private float jumpVelocity;
    private float currentStrafeSpeed;
    private float lastJumpTime = Mathf.NegativeInfinity;
    private float releaseJumpTime = Mathf.NegativeInfinity;
    private bool isGrounded;
    private bool hasRelasedJump = false;
    private bool doJump = false;

    protected override void SubscribeToInputEvents()
    {
        playerInput.onJump_Pressed += OnJump_Pressed;
        playerInput.onJump_Released += OnJump_Released;
        playerInput.onAimDownSights_Pressed += OnAimDownSights_Pressed;
        playerInput.onAimDownSights_Released += OnAimDownSights_Released;
    }

    private void Start()
    {
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        currentStrafeSpeed = strafeSpeed;
    }

    public override void Execute()
    {
        CheckGrounded();
        Move();
    }

    private void OnJump_Pressed()
    {
        if (!isGrounded) return;

        playerAnimController.JumpTrigger();
        doJump = true;
        lastJumpTime = Time.time;
        isGrounded = false;
    }

    private void OnJump_Released()
    {
        if (hasRelasedJump) return;

        hasRelasedJump = true;
        releaseJumpTime = Time.time;
    }

    private void OnAimDownSights_Pressed()
    {
        float percentToAimSpread = Mathf.Abs(currentStrafeSpeed - strafeSpeed) / Mathf.Abs(aimedStrafeSpeed - strafeSpeed);
        float remainingTime = aimDownSightsTime * (1f - percentToAimSpread);

        //Tween spread to ADS
        LeanTween.cancel(stopADSTweenId);
        startADSTweenId = LeanTween.value(this.gameObject, v => currentStrafeSpeed = v, currentStrafeSpeed, aimedStrafeSpeed, remainingTime).id;
        LeanTween.descr(startADSTweenId).setEaseInOutQuad();
    }

    private void OnAimDownSights_Released()
    {
        float percentToHipSpread = Mathf.Abs(currentStrafeSpeed - aimedStrafeSpeed) / Mathf.Abs(aimedStrafeSpeed - strafeSpeed);
        float remainingTime = aimDownSightsTime * (1f - percentToHipSpread);

        //Tween spread to ADS
        LeanTween.cancel(startADSTweenId);
        stopADSTweenId = LeanTween.value(this.gameObject, v => currentStrafeSpeed = v, currentStrafeSpeed, strafeSpeed, remainingTime).id;
        LeanTween.descr(stopADSTweenId).setEaseInOutQuad();
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

        playerAnimController.SetIsGrounded(isGrounded);
    }

    private void Move()
    {
        float moveInput = playerInput.GetRoundedMoveInput();
        float currentXSpeed = 0f;
        Vector3 actualVelocity = charController.velocity;
        float targetXSpeed = moveInput * currentStrafeSpeed;
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
