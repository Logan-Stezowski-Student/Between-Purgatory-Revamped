using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Credits : MonoBehaviour
{
    public GameObject[] credits;
    public float timeBetween;
    public UnityEvent OnEnd = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchCredits());
    }

    IEnumerator SwitchCredits() 
    {
        while (true) 
        {
            for (int i = 0; i < credits.Length; i++) 
            {
                credits[i].SetActive(true);
                yield return new WaitForSeconds(timeBetween);
                credits[i].SetActive(false);
            }
            OnEnd.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
