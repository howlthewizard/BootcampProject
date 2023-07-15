using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParkourDoorMng : MonoBehaviour
{
    private bool isDoorLocked = true;
    public GameObject door;
    public GameObject invisCol;
    private Animator doorAnimator;

    private void Awake()
    {
        doorAnimator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("Close");
            invisCol.gameObject.SetActive(true);
        }
    }
   
}
