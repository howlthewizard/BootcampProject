using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDoorMng : MonoBehaviour
{
    public int totalEnemies;
    public GameObject invisCol;
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
       
        if (killedEnemies == 4)
        {
            isDoorLocked = false;
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        isDoorLocked = false;
        invisCol.gameObject.SetActive(false);
        doorAnimator.SetTrigger("Open");
    }
    
}
