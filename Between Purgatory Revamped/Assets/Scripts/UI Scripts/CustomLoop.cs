using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLoop : MonoBehaviour
{
    AudioSource music;
    public float loopStart;
    public float loopEnd;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (music.isPlaying && music.time >= loopEnd) 
        {
            music.time = loopStart;
        }
    }
}
