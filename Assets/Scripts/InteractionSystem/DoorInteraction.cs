using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        var inventory  = interactor.GetComponent<KeyInventory>();

        if (inventory == null) { return false; }

        if (inventory.hasKeyA)
        {
            Debug.Log("Opening door!");
            return true;
        }

        Debug.Log("No key found");
        return false;
       
    }
}
