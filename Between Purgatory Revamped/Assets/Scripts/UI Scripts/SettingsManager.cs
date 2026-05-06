using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private const string MusicLevel = "MusicLevel";
    private const string SFXLevel = "SFXLevel";
    public float musicVolume;
    public float sfxVolume;
    public Slider musicSlider;
    public Slider sfxSlider;
    // Start is called before the first frame update
    private void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicLevel", 1.0f);
        musicSlider.SetValueWithoutNotify(musicVolume);
        sfxVolume = PlayerPrefs.GetFloat("SFXLevel", 1.0f);
        sfxSlider.SetValueWithoutNotify(sfxVolume);
        SetMusicVolume();
        SetSFXVolume();
    }
    public void SetMusicVolume() 
    {
        GameObject[] backgroundMusic = GameObject.FindGameObjectsWithTag("Music");

        foreach (GameObject musicas in backgroundMusic) 
        {
            AudioSource music = musicas.GetComponent<AudioSource>();
            musicVolume = musicSlider.value;
            music.volume = musicVolume;
            PlayerPrefs.SetFloat(MusicLevel, music.volume);
            PlayerPrefs.Save();
        }
    }
    public void SetSFXVolume()
    {
        GameObject[] soundEffects = GameObject.FindGameObjectsWithTag("SFX");
        foreach (GameObject soundEffect in soundEffects) 
        {
            AudioSource sfx = soundEffect.GetComponent<AudioSource>();
            sfxVolume = sfxSlider.value;
            sfx.volume = sfxVolume;
            PlayerPrefs.SetFloat(SFXLevel, sfxVolume);
            PlayerPrefs.Save();
        }
    }
    public void DeathSFXVolume() 
    {
        GameObject[] soundEffects = GameObject.FindGameObjectsWithTag("SFX");
        foreach (GameObject soundEffect in soundEffects)
        {
            AudioSource sfx = soundEffect.GetComponent<AudioSource>();
            sfx.volume = 0f;
        }
    }
}
