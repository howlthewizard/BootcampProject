using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KillPlayer : MonoBehaviour
{
    public int Respawn;

    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            SceneManager.LoadScene(Respawn);
        }
    }
}
