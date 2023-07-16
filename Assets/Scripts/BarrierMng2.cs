using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMng2 : MonoBehaviour
{
    [SerializeField] GameObject Barrier;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Barrier.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Barrier.SetActive(false);
        }
    }
}
