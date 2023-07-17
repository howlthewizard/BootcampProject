using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    [SerializeField] private CombatDoorMng combatdoor;

    // Update is called once per frame
    void Update()
    {
       if(combatdoor.killedEnemies == 4)
        {
            combatdoor.OpenDoor();
        }
    }
}
