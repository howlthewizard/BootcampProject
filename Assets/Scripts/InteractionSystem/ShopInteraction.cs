using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interaction with shop!");
        return true;
    }
}
