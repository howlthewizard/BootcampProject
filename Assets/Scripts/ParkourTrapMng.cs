using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourTrapMng : MonoBehaviour
{
    private bool isDoorLocked = true;
    public GameObject door;
    private Animator doorAnimator;

    private void Awake()
    {
        doorAnimator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("Open");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetTrigger("Open");
        }
    }
}
