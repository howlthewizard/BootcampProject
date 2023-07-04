using Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private GameObject restartGamePanel = null;
    private void Start()
    {
        health = GetComponent<Health>();
       
    }
    private void Update()
    {
        if (health.IsDead())
        { //Karakter öldüyse restart paneli belirli saniye sonunda aktifleştir ve sonrasında oyun zamanını durdur.
            StartCoroutine(ResetPanel());
        }
    }

    public void ResetGame()
    {
        //Level'ı yeniden yükleyip oyun zamanını normal zamana döndersin.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public IEnumerator ResetPanel()
    {
        yield return new WaitForSeconds(1f);
        restartGamePanel.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        Time.timeScale = 0f;
    }
}