using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2: MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] GameObject prompter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Door.SetActive(true);
            if(prompter != null)
            {
                prompter.SetActive(false);

            }
        }
    }
}
