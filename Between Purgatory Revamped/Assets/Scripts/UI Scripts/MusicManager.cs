using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    //public SettingsManager settings;
    public List<AudioSource> music = new List<AudioSource>();

    // Start is called before the first frame update
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    public void PlayMusic(int index)
    {
        if (index >= 0 && index < music.Count)
        {
            music[index].Play();
        }
    }
}
