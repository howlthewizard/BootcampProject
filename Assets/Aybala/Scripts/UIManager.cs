using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
       
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

}
