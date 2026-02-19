using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Text interactionText;

    private Interaction targetInteract;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        string displayText = "";
        targetInteract = null;
        if (other.gameObject.CompareTag("Switch"))
        {
            targetInteract = other.gameObject.GetComponent<Interaction>(); 
            if(targetInteract && targetInteract.enabled) 
            {
                displayText = targetInteract.GetInteractText();
            }
            SetInteractableTextName(displayText);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        string displayText = "";
        targetInteract = null;
        SetInteractableTextName(displayText);
    }
    void SetInteractableTextName(string newText) 
    {
        if (interactionText != null) 
        {
            interactionText.text = newText;
        }
    }
    public void TryInteract() 
    {
        if (targetInteract != null && targetInteract.enabled)
        {
            targetInteract.Interact();
        }
    }
}
