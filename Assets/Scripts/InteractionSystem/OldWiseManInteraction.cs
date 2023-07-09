using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldWiseManInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private DialogueTrigger trigger;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            trigger.StartDialogue();
        }
        return true;
    }
}
