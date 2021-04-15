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
        var sceneDataJsonString =
        PlayerPrefs.GetString("playerData");
        JsonUtility.FromJsonOverwrite(sceneDataJsonString, sceneData);
        player = FindObjectOfType<PlayerScript>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    public void PauseGame()
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

    public void Resume()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        Time.timeScale = 1F;
        isGamePaused = false;
    }

    private void Pause()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        pauseMenu.SetActive(true);
        Time.timeScale = 0F;
        isGamePaused = true;
    }

    public void Save()
    {
        sceneData.playerPosition = player.transform.position;
        sceneData.playerRotation = player.transform.rotation;
        sceneData.playerHealth = PlayerData.Health;

        SavetoPlayerPrefs();
    }

    public void Load()
    {
        LoadFromPlayerPrefs();

        player.transform.position = sceneData.playerPosition;
        player.transform.rotation = sceneData.playerRotation;
        healthBar.SetHealth(sceneData.playerHealth);
    }

    public void SavetoPlayerPrefs()
    {
        PlayerPrefs.SetFloat("playerTransformX", sceneData.playerPosition.x);
        PlayerPrefs.SetFloat("playerTransformY", sceneData.playerPosition.y);
        PlayerPrefs.SetFloat("playerTransformZ", sceneData.playerPosition.z);

        PlayerPrefs.SetFloat("playerRotationX", sceneData.playerRotation.x);
        PlayerPrefs.SetFloat("playerRotationY", sceneData.playerRotation.y);
        PlayerPrefs.SetFloat("playerRotationZ", sceneData.playerRotation.z);
        PlayerPrefs.SetFloat("playerRotationW", sceneData.playerRotation.w);

        PlayerPrefs.SetFloat("playerHealth", sceneData.playerHealth);
    }

    public void LoadFromPlayerPrefs()
    {
        sceneData.playerPosition.x = PlayerPrefs.GetFloat("playerTransformX");
        sceneData.playerPosition.y = PlayerPrefs.GetFloat("playerTransformY");
        sceneData.playerPosition.z = PlayerPrefs.GetFloat("playerTransformZ");

        sceneData.playerRotation.x = PlayerPrefs.GetFloat("playerRotationX");
        sceneData.playerRotation.y = PlayerPrefs.GetFloat("playerRotationY");
        sceneData.playerRotation.z = PlayerPrefs.GetFloat("playerRotationZ");
        sceneData.playerRotation.w = PlayerPrefs.GetFloat("playerRotationW");

        sceneData.playerHealth = PlayerPrefs.GetFloat("playerHealth");

    }
}
