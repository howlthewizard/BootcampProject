using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap2 : MonoBehaviour
{
    [SerializeField] private CombatDoorMng combatdoor;

    void Update()
    {
        if (combatdoor.killedEnemies == 15)
        {
            combatdoor.OpenDoor();
        }
    }
}
