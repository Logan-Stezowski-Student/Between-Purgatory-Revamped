using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public SettingsManager settings;
    public AudioSource music;
    public AudioSource sfx;
    // Start is called before the first frame update
    void Start()
    {
        if (instance != null) 
        {
            Destroy(gameObject);
            return;
        }   
        instance = this;
        DontDestroyOnLoad(gameObject);
        if (music == null) 
        {
            music = gameObject.AddComponent<AudioSource>();
        }
        if (sfx == null) 
        {
            sfx = gameObject.AddComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
