using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreSystem : MonoBehaviour
{
    public static LoreSystem instance;
    private const string LorePageOne = "LorePage1";
    private const string LorePageTwo = "LorePage2";
    private const string LorePageThree = "LorePage3";
    private const string LorePageFour = "LorePage4";
    private const string LorePageFive = "LorePage5";
    private const string LorePageSix = "LorePage6";
    private const string LorePageSeven = "LorePage7";
    private const string LorePageEight = "LorePage8";
    public bool HasPage1 = true;
    public bool HasPage2 = true;
    public bool HasPage3 = true;
    public bool HasPage4 = true;
    public bool HasPage5 = true;
    public bool HasPage6 = true;
    public bool HasPage7 = true;
    public bool HasPage8 = true;
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
    }

    public void SavePage() 
    {
        PlayerPrefs.SetInt("LorePageOne", HasPage1 ? 1 : 0);
        PlayerPrefs.SetInt("LorePageTwo", HasPage2 ? 1 : 0);
        PlayerPrefs.SetInt("LorePageThree", HasPage3 ? 1 : 0);
        PlayerPrefs.SetInt("LorePageFour", HasPage4 ? 1 : 0);
        PlayerPrefs.SetInt("LorePageFive", HasPage5 ? 1 : 0);
        PlayerPrefs.SetInt("LorePageSix", HasPage6 ? 1 : 0);
        PlayerPrefs.SetInt("LorePageSeven", HasPage7 ? 1 : 0);
        PlayerPrefs.SetInt("LorePageEight", HasPage8 ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void Delete() 
    {
        PlayerPrefs.DeleteAll();
    }
}
