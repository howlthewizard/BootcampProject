using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
  public GameObject gameOverMenu;

  public void EnableGameOverMenu()
  {
     gameOverMenu.SetActive(true);
  }
}
