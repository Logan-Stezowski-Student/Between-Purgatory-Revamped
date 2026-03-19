using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //public SettingsManager settings;
    public List<AudioSource> sfx = new List<AudioSource>();
 
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    public void PlaySFX(int index)
    {
        if (index >= 0 && index < sfx.Count)
        {
            sfx[index].Play();
        }
    }
}
