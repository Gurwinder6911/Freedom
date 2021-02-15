using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float speed = 2F;
    [SerializeField] float extraSpeed = 2F;
    [SerializeField] float jumpSpeed = 2F;
    [SerializeField] float gravity = 7F;
    [SerializeField] float groundDistance = 0.5F;

    [SerializeField] Transform camera;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    private CharacterController character;
    private Vector3 velocity;
    private Animator animator;
    private bool isOnGround;
    private bool isSprinting;
    private float smoothVelo;


    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isSprinting = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CheckingOnGround();
        PlayerMovement();
        RunningAnimation();
        PlayerJump();
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0F, vertical).normalized;

        if (direction.magnitude >= 0.1F)
        {
            float directAngle;
            Rotation(direction, out directAngle);

            Vector3 forwardDirection = Quaternion.Euler(0F, directAngle, 0F) * Vector3.forward;
            character.Move(forwardDirection.normalized * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);
    }

    private void RunningAnimation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void CheckingOnGround()
    {
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isOnGround && velocity.y < 0)
        {
            velocity.y = -2F;
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            velocity.y = Mathf.Sqrt(jumpSpeed * -2 * gravity);
        }

        if (!isOnGround)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }

    private void Rotation(Vector3 direction, out float directAngle)
    {
        directAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y; 
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, directAngle, ref smoothVelo, 0.1F);

        transform.rotation = Quaternion.Euler(0F, angle, 0F);
    }
}
