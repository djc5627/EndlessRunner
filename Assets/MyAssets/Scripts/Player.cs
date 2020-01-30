using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public InputMaster inputMaster;
    public Transform firePoint;
    public GameObject rocket;
    public float shootForce = 100f;
    public float strafeSpeed = 10f;
    public float forwardSpeed = 20f;

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
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float xSpeed = moveInput * strafeSpeed;
        playerRb.velocity = new Vector3(xSpeed, playerRb.velocity.y, forwardSpeed);
    }

    private void Shoot()
    {
        GameObject tempRocket = Instantiate(rocket, firePoint.position, Quaternion.identity);
        Rigidbody rocketRb = tempRocket.GetComponent<Rigidbody>();
        rocketRb.AddForce(firePoint.forward * shootForce);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
