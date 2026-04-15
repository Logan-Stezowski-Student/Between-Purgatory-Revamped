using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] private string interactText = "Hello World";
    public UnityEvent OnInteract = new UnityEvent();

    void OnEnable()
    {
        
    }

    public string GetInteractText() 
    {
        return interactText;
    }
    public void Interact() 
    {
        OnInteract.Invoke();
    }
}
