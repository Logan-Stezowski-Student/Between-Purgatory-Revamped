using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntry : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        if (LevelSystem.instance != null) 
        {
            LevelSystem.instance.UnlockedLevel(level);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
