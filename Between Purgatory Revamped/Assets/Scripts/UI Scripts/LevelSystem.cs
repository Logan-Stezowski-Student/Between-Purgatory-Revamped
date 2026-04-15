using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public static LevelSystem instance;
    public int level = 0;
    private const string levelNum = "LevelNumber";
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null) 
        {
            Destroy(this);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    public void UnlockedLevel(int level) 
    {
        int currentUnlocked = PlayerPrefs.GetInt(levelNum, 0);

        if (level > currentUnlocked) 
        {
            PlayerPrefs.SetInt(levelNum, level);
            PlayerPrefs.Save();
        }
    }
    public void Delete() 
    {
        PlayerPrefs.DeleteAll();
    }
}
