using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public InputMaster inputMaster;
    public Animator anim;
    public Transform firePoint;
    public GameObject rocket;
    public CharacterController charController;
    public LayerMask groundCheckMask;
    public float groundCheckDistance = .1f;
    public float groundCheckOriginYOffset = .05f;
    public float groundCheckJumpDelay = .1f;
    public float shootForce = 100f;
    public float shootDelay = .5f;
    public float strafeSpeed = 10f;
    public float forwardSpeed = 20f;
    public float acceleration = .01f;
    public float deacceleration = .01f;
    public float timeToJumpApex = .2f;
    public float maxJumpHeight = 10f;
    public float fallMultiplier = 2f;
    public float lowJumpTurnTime = .05f;
    public float maxFallSpeed = 10f;

    private float moveInput;
    private float gravity;
    private float jumpVelocity;
    private float lastJumpTime = Mathf.NegativeInfinity;
    private float lastShootTime = Mathf.NegativeInfinity;
    private float releaseJumpTime = Mathf.NegativeInfinity;
    private bool isGrounded;
    private bool hasRelasedJump = false;
    private bool doJump = false;

    private void OnEnable()
    {
        inputMaster.Enable();
    }

    private void OnDisable()
    {
        inputMaster.Disable();
    }

    private void Awake()
    {
        inputMaster = new InputMaster();
        inputMaster.Player.MoveInput.performed += ctx => moveInput = ctx.ReadValue<float>();
        inputMaster.Player.Shoot.performed += ctx => Shoot();
        inputMaster.Player.Jump.performed += ctx => OnJump();
        inputMaster.Player.JumpRelease.performed += ctx => OnJumpRelease();

    }

    private void Start()
    {
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    private void Update()
    {
        // forwardSpeed = MIDIInput.GetKnob(1, 0f, 100f);
        //jumpForce = MIDIInput.GetKnob(2, 0f, 30f);
        //strafeSpeed = MIDIInput.GetKnob(3, 0f, 30f);
        //Physics.gravity = new Vector3(0f, MIDIInput.GetKnob(4, 10f, -50f), 0f);
        //shootForce = MIDIInput.GetKnob(5, 0f, 30000f);
        //moveInput = MIDIInput.GetKnob(7, -1f, 1f);

        //acceleration = MIDIInput.GetKnob(1, .001f, .1f);
        //deacceleration = MIDIInput.GetKnob(2, .001f, .1f);
        //timeToJumpApex = MIDIInput.GetKnob(1, 0f, .5f);
        //maxJumpHeight = MIDIInput.GetKnob(2, 0f, 10f);
        //fallMultiplier = MIDIInput.GetKnob(3, 1f, 8f);
        //lowJumpTurnTime = MIDIInput.GetKnob(4, .1f, .5f);
        //maxFallSpeed = MIDIInput.GetKnob(5, 10f, 100f);

        //gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        //jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        CheckGrounded();
        NormalizeMoveInput();
        Move();
        SyncAnimatorVariables();
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

    private void Shoot()
    {
        if (lastShootTime + shootDelay > Time.time)
        {
            return;
        }

        GameObject tempRocket = Instantiate(rocket, firePoint.position, Quaternion.LookRotation(firePoint.forward));
        Rigidbody rocketRb = tempRocket.GetComponent<Rigidbody>();
        rocketRb.AddForce(firePoint.forward * shootForce);
        lastShootTime = Time.time;
    }

    private void OnJump()
    {
        if (!isGrounded) return;

        anim.SetTrigger("Jump");
        //playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        doJump = true;
        lastJumpTime = Time.time;
        isGrounded = false;
    }

    private void OnJumpRelease()
    {
        hasRelasedJump = true;
        releaseJumpTime = Time.time;
    }

    private void CheckGrounded()
    {
        //Delay after jump
        if (lastJumpTime + groundCheckJumpDelay > Time.time)
        {
            return;
        }

        RaycastHit hit;
        //Vector3 origin = charController.bounds.center + (Vector3.up * groundCheckOriginYOffset);
        float halfHeight = charController.height / 2f;
        Vector3 point1 = charController.bounds.center + (Vector3.up * halfHeight) + Vector3.up * groundCheckOriginYOffset;
        Vector3 point2 = charController.bounds.center - (Vector3.up * halfHeight) + Vector3.up * groundCheckOriginYOffset;
        if (Physics.CapsuleCast(point1, point2, charController.radius, Vector3.down, out hit, groundCheckDistance, groundCheckMask))
        {
            isGrounded = true;
            hasRelasedJump = false;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void SyncAnimatorVariables()
    {
        anim.SetBool("isGrounded", isGrounded);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
