using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;

    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    public GameObject audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null) 
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSettings();
    }

    public void SetMasterVolume(float volume) 
    {
        masterVolume = volume;

        PlayerPrefs.SetFloat("MasterVolume", volume);
    }   

    public void LoadSettings() 
    {
        if (PlayerPrefs.HasKey("MasterVolume")) 
        {
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        }
    }
}
