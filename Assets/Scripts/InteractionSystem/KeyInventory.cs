using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    public bool hasKeyA=false,hasKeyB=false,hasKeyC=false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            hasKeyA = !hasKeyA;
            hasKeyB = !hasKeyB;
            hasKeyC = !hasKeyC;
        }
    }


}
