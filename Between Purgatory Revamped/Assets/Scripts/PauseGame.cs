using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseUI;
    public bool isPaused;
    public FirstPersonCamera firstPersonCamera;
    public InputHandler inputHandler;
    BossHealth health;
    // Start is called before the first frame update
    void Start()
    {
        if (pauseUI == null) 
        {
            pauseUI.SetActive(false);
        }
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
            {
                Unpause();
            }
            else 
            {
                Pause();
            }
        }
    }

    public void Pause() 
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        firstPersonCamera.enabled = false;
        inputHandler.enabled = false;
    }
    public void Unpause()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        firstPersonCamera.enabled = true;
        inputHandler.enabled = true;
    }
}
