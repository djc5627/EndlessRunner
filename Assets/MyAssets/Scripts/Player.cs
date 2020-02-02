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
    public float shootForce = 100f;
    public float strafeSpeed = 10f;
    public float forwardSpeed = 20f;
    public float jumpForce = 5f;

    private Rigidbody playerRb;
    private float moveInput;

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

    private void FixedUpdate()
    {
        CheckGrounded();
        Move();
    }

    private void Move()
    {
        float xSpeed = moveInput * strafeSpeed;
        playerRb.velocity = new Vector3(xSpeed, playerRb.velocity.y, forwardSpeed);
    }

    private void Shoot()
    {
        GameObject tempRocket = Instantiate(rocket, firePoint.position, Quaternion.LookRotation(firePoint.forward));
        Rigidbody rocketRb = tempRocket.GetComponent<Rigidbody>();
        rocketRb.AddForce(firePoint.forward * shootForce);
    }

    private void Jump()
    {
        anim.SetTrigger("Jump");
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void CheckGrounded()
    {
        if (Physics.BoxCast(playerCol.bounds.center, playerCol.bounds.extents, Vector3.down, transform.rotation, groundCheckDistance, groundCheckMask))
        {
            anim.SetBool("isGrounded", true);
            Debug.Log("grounded");
        }
        else
        {
            anim.SetBool("isGrounded", false);
            Debug.Log("airborn");
        }
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
