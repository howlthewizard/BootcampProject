using AI.Controller;
using AI.Shops;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private PlayerCursorController callingController;
    private Shop shop;
   public string InteractionPrompt => _prompt;

    private void Awake()
    {
        shop = GetComponent<Shop>();
    }
    public bool Interact(Interactor interactor)
    {
        shopPanel.SetActive(true);
        callingController.GetComponent<Shopper>().SetActiveShop(shop);
        return true;
    }
}
