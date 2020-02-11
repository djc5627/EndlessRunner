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
    public BoxCollider playerCol;
    public LayerMask groundCheckMask;
    public float groundCheckDistance = .1f;
    public float groundCheckOriginYOffset = .05f;
    public float groundCheckJumpDelay = .1f;
    public float shootForce = 100f;
    public float shootDelay = .5f;
    public float strafeSpeed = 10f;
    public float forwardSpeed = 20f;
    public float jumpForce = 5f;

    private Rigidbody playerRb;
    private float moveInput;
    private float lastJumpTime = Mathf.NegativeInfinity;
    private float lastShootTime = Mathf.NegativeInfinity;
    private bool isGrounded;

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
        playerRb = GetComponent<Rigidbody>();
        inputMaster = new InputMaster();
        inputMaster.Player.MoveInput.performed += ctx => moveInput = ctx.ReadValue<float>();
        inputMaster.Player.Shoot.performed += ctx => Shoot();
        inputMaster.Player.Jump.performed += ctx => Jump();
    }

    private void Update()
    {
        SyncAnimatorVariables();
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        Move();
    }

    private void Move()
    {
        float xSpeed = moveInput * strafeSpeed;
        playerRb.velocity = new Vector3(xSpeed, playerRb.velocity.y, forwardSpeed);

        Vector3 velocity = new Vector3(xSpeed, 0f, forwardSpeed);
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

    private void Jump()
    {
        if (!isGrounded) return;

        anim.SetTrigger("Jump");
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        lastJumpTime = Time.time;
        isGrounded = false;
    }

    private void CheckGrounded()
    {
        //Delay after jump
        if (lastJumpTime + groundCheckJumpDelay > Time.time)
        {
            return;
        }

        Vector3 origin = playerCol.bounds.center + (Vector3.up * groundCheckOriginYOffset);
        if (Physics.BoxCast(origin, playerCol.bounds.extents, Vector3.down, transform.rotation, groundCheckDistance, groundCheckMask))
        {
            isGrounded = true;
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

    public void ResetForward()
    {
        playerRb.rotation = Quaternion.identity;
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
