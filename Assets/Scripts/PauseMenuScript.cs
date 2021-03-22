using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    bool isGamePaused;

    [Header("Player Settings")]
    public PlayerScript player;

    HealthBar healthBar;

    [Header("Scene Data")]
    public SceneDataSO sceneData;

    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1F;
        isGamePaused = false;
    }

    private void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenu.SetActive(true);
        Time.timeScale = 0F;
        isGamePaused = true;
    }

    public void Save()
    {
        sceneData.playerPosition = player.transform.position;
        sceneData.playerRotation = player.transform.rotation;
        sceneData.playerHealth = PlayerData.Health;
    }

    public void Load()
    {
        player.transform.position = sceneData.playerPosition;
        player.transform.rotation = sceneData.playerRotation;
        healthBar.SetHealth(sceneData.playerHealth);
    }
}
