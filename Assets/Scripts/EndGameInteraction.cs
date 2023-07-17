using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameInteraction : MonoBehaviour
{
    public DialogueTrigger trigger;
    [SerializeField] private Canvas endGamePanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trigger.StartDialogue();
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMovingScript>().enabled = false;
            endGamePanel.gameObject.SetActive(true);
        }
    }
}
