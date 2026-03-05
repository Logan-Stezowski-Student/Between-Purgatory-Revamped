using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LorePage : MonoBehaviour
{
    public Button Lore1;
    public Button Lore2;
    public Button Lore3;
    public Button Lore4;
    public Button Lore5;
    public Button Lore6;
    public Button Lore7;
    public Button Lore8;
    GameObject loreSystem;
    // Start is called before the first frame update
    void Start()
    {
        loreSystem = GameObject.FindGameObjectWithTag("LoreSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("LorePageOne", 0) != 0)
        {
            Lore1.interactable = true;
        }
        if (PlayerPrefs.GetInt("LorePageTwo", 0) != 0)
        {
            Lore2.interactable = true;
        }
        if (PlayerPrefs.GetInt("LorePageThree", 0) != 0)
        {
            Lore3.interactable = true;
        }
        if (PlayerPrefs.GetInt("LorePageFour", 0) != 0)
        {
            Lore4.interactable = true;
        }
        if (PlayerPrefs.GetInt("LorePageFive", 0) != 0)
        {
            Lore5.interactable = true;
        }
        if (PlayerPrefs.GetInt("LorePageSix", 0) != 0)
        {
            Lore6.interactable = true;
        }
    }
}
