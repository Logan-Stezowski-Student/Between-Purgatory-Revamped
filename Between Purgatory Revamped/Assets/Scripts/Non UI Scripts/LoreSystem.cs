using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreSystem : MonoBehaviour
{
    public static LoreSystem instance;
    private const string LorePageOne = "LorePageOne";
    private const string LorePageTwo = "LorePageTwo";
    private const string LorePageThree = "LorePageThree";
    private const string LorePageFour = "LorePageFour";
    private const string LorePageFive = "LorePageFive";
    private const string LorePageSix = "LorePageSix";
    private const string LorePageSeven = "LorePageSeven";
    private const string LorePageEight = "LorePageEight";
    bool HasPage1 = true;
    bool HasPage2 = true;
    bool HasPage3 = true;
    bool HasPage4 = true;
    bool HasPage5 = true;
    bool HasPage6 = true;
    bool HasPage7 = true;
    bool HasPage8 = true;

    public void SavePage1() 
    {
        PlayerPrefs.SetInt("LorePageOne", HasPage1 ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SavePage2() 
    {
        PlayerPrefs.SetInt("LorePageTwo", HasPage2 ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SavePage3() 
    {
        PlayerPrefs.SetInt("LorePageThree", HasPage3 ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SavePage4() 
    {
        PlayerPrefs.SetInt("LorePageFour", HasPage4 ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SavePage5() 
    {
        PlayerPrefs.SetInt("LorePageFive", HasPage5 ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SavePage6() 
    {
        PlayerPrefs.SetInt("LorePageSix", HasPage6 ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SavePage7() 
    {
        PlayerPrefs.SetInt("LorePageSeven", HasPage7 ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void SavePage8() 
    {
        PlayerPrefs.SetInt("LorePageEight", HasPage8 ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void Delete() 
    {
        PlayerPrefs.DeleteAll();
    }
}
