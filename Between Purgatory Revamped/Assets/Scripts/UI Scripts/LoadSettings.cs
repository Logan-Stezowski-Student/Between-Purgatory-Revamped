using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSettings : MonoBehaviour
{
    private float musicVolume1;
    public void LoadMusic() 
    {
        musicVolume1 = PlayerPrefs.GetFloat("MusicLevel", 1.0f);
        GameObject backgroundMusic = GameObject.FindGameObjectWithTag("Music");
        AudioSource music = backgroundMusic.GetComponent<AudioSource>();
        music.volume = musicVolume1;
    }
}
