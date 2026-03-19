using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Button[] levelButtons;
    public LevelSystem levelSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int unlockedLevel = PlayerPrefs.GetInt("LevelNumber", 0);

        for (int i = 0; i < levelButtons.Length; i++) 
        {
            levelButtons[i].interactable = (i + 1) <= unlockedLevel;
        }
    }
}
