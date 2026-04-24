using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public static void LoadScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
        if (sceneName == "Title") 
        {
            Time.timeScale = 1.0f;
            AudioListener.pause = false;
        }
    }

    public static void Quit() 
    {
        Application.Quit();
    }
}
