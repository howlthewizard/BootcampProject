using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDoorMng : MonoBehaviour
{
    public int totalEnemies;
    public int killedEnemies = 0;
    private bool isDoorLocked = true;
    public GameObject door;
    private Animator doorAnimator;

    private void Awake()
    {
        doorAnimator = door.GetComponent<Animator>();
    }
    public void EnemyKilled()
    {
        killedEnemies++;
       
        if (killedEnemies >= totalEnemies)
        {
            isDoorLocked = false;
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        isDoorLocked = false;
        doorAnimator.SetTrigger("Open");
    }
    
}
