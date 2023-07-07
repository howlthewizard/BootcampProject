using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject shopPanel;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        shopPanel.SetActive(true);
        return true;
    }
}
