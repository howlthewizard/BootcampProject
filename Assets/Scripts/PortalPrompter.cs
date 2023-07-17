using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PortalPrompter : MonoBehaviour
{
    public DialogueTrigger trigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            trigger.StartDialogue();
        }
    }
}
