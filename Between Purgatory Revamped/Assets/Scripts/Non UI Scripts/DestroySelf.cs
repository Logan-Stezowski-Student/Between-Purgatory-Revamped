using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float wait = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, wait);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
