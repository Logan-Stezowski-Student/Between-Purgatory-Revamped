using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager instance;

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
    }
    public static void Quit() 
    {
        Application.Quit();
    }
}
