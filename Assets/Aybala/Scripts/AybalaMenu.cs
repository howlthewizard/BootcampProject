using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AybalaMenu : MonoBehaviour
{
    public GameObject optionsScreen;
    
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Oyundan Ciktik!");
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);  
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }
}
