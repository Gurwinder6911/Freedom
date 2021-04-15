using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;
using Cinemachine;

[DisallowMultipleComponent]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] float speed = 1.5F;
    [SerializeField] float extraSpeed = 2F;
    [SerializeField] float jumpSpeed = 2F;
    [SerializeField] float gravity = 7F;
    [SerializeField] float groundDistance = 0.5F;

    [SerializeField] GameObject camera;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] HealthBar healthBar;
    [SerializeField] Joystick joystick;

    private CharacterController character;
    private Vector3 jumpVelocity;
    private Vector3 direction;
    private Animator animator;

    private bool isOnGround;
    private bool isDead;

    private float smoothVelo;
    private float timer = 0F;

    private Sounds soundScript = new Sounds();
    [SerializeField]
    Sounds[] jumpSounds;

    [SerializeField]
    Sounds[] takeDamageSounds;
    [SerializeField]
    AudioSource walk;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerData.Health = 10F;
            PlayerData.Inv.Clear();
        }
        
        healthBar.SetHealth(PlayerData.Health);

        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isDead = false;
        //Cursor.lockState = CursorLockMode.Locked;

        soundScript.LoadSounds(jumpSounds);
        soundScript.LoadSounds(takeDamageSounds);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            CheckingOnGround();
            PlayerMovement();
            PlayerJump();
        }
    }

    private void PlayerMovement()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;
        direction = new Vector3(horizontal, 0F, vertical).normalized;
        animator.SetFloat("Running", direction.magnitude);

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

    public void RunningSound()
    {
        if (!walk.isPlaying)
        {
            walk.Play();
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

    public void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && timer <= 0F && direction.magnitude >= 1F)
        {
            jumpVelocity.y = Mathf.Sqrt(jumpSpeed * -2 * gravity);
            timer = 1.5F;
            soundScript.PlayRandomSound(jumpSounds);
        }

        animator.SetFloat("Jump", jumpVelocity.y);

        if (!isOnGround)
        {
            walk.Stop();
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime; 
        }
    }

    private void Rotation(Vector3 direction, out float directAngle)
    {
        directAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.transform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, directAngle, ref smoothVelo, 0.1F);

        transform.rotation = Quaternion.Euler(0F, angle, 0F);
    }

    public void HealthDamage(float damage)
    {
        if (!PlayerData.IsSheildOn)
        {
            PlayerData.Health -= damage;

            healthBar.SetHealth(PlayerData.Health);

            if (PlayerData.Health <= 0F)
            {
                isDead = true;
                PlayerData.Health = 0F;

                healthBar.SetHealth(PlayerData.Health);
                camera.transform.DetachChildren();
                camera.SetActive(false);

                Destroy(this.gameObject);
                SceneManager.LoadScene(3);
            }
            soundScript.PlayRandomSound(takeDamageSounds); 
        }
    }

    public void UseHealth(float healthIncrease)
    {
        PlayerData.Health += healthIncrease;
        healthBar.SetHealth(PlayerData.Health);

        if (PlayerData.Health >= 10F)
        {
            PlayerData.Health = 10F;
        }
    }
}
