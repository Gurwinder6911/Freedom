using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[DisallowMultipleComponent]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float speed = 1.5F;
    [SerializeField] float extraSpeed = 2F;
    [SerializeField] float jumpSpeed = 2F;
    [SerializeField] float gravity = 7F;
    [SerializeField] float groundDistance = 0.5F;

    [SerializeField] Transform camera;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    private CharacterController character;
    private Vector3 jumpVelocity;
    private Vector3 direction;
    private Animator animator;

    private bool isOnGround;
    private bool isSprinting;
    private bool isJump;

    private float smoothVelo;
    private float timer = 0F;

    //Reusing Sound class as defined in BackgroundMusic for playing sounds
    [SerializeField]
    Sound[] jumpSounds;

    [SerializeField]
    Sound[] takeDamageSounds;

    public AudioSource footsteps;


    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isSprinting = false;
        Cursor.lockState = CursorLockMode.Locked;

        for (int i = 0; i < jumpSounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + jumpSounds[i].soundName);
            _go.transform.SetParent(this.transform);
            jumpSounds[i].SetSource(_go.AddComponent<AudioSource>());
            
        }

        for (int i = 0; i < takeDamageSounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + jumpSounds[i].soundName);
            _go.transform.SetParent(this.transform);
            takeDamageSounds[i].SetSource(_go.AddComponent<AudioSource>());

        }

    }

    // Update is called once per frame
    void FixedUpdate()
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
        direction = new Vector3(horizontal, 0F, vertical).normalized;

        if (direction.magnitude >= 0.1F)
        {
            float directAngle;
            Rotation(direction, out directAngle);

            Vector3 forwardDirection = Quaternion.Euler(0F, directAngle, 0F) * Vector3.forward;
            character.Move(forwardDirection.normalized * speed * Time.deltaTime);
        }

        jumpVelocity.y += gravity * Time.deltaTime;
        character.Move(jumpVelocity * Time.deltaTime);
    }

    private void RunningAnimation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isRunning", true);
            if (footsteps.isPlaying == false)
            {
                footsteps.Play();
            }
            
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRunning", true);
            if (footsteps.isPlaying == false)
            {
                footsteps.Play();
            }
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);
            if (footsteps.isPlaying == false)
            {
                footsteps.Play();
            }
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isRunning", true);
            if (footsteps.isPlaying == false)
            {
                footsteps.Play();
            }
            
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void CheckingOnGround()
    {
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isOnGround && jumpVelocity.y < 0)
        {
            jumpVelocity.y = -3.5F;
        }
    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && timer <= 0F && direction.magnitude >= 1F)
        {
            isJump = true;
            jumpVelocity.y = Mathf.Sqrt(jumpSpeed * -2 * gravity);
            timer = 1.5F;
            var rand = UnityEngine.Random.Range(0, jumpSounds.Length - 1);
            jumpSounds[rand].Play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJump && direction.magnitude >= 1F)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);

            isJump = false;
        }

        timer -= Time.deltaTime;
    }

    private void Rotation(Vector3 direction, out float directAngle)
    {
        directAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y; 
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, directAngle, ref smoothVelo, 0.1F);

        transform.rotation = Quaternion.Euler(0F, angle, 0F);
    }

    public void HealthDamage(float damage)
    {
        var rand = UnityEngine.Random.Range(0, takeDamageSounds.Length - 1);
        takeDamageSounds[rand].Play();
        print("HIT");
    }
}
