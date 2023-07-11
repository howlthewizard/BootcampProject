using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownMng : MonoBehaviour
{
    public float countdownTime = 6f; 
    public TextMeshProUGUI countdownText;
    public GameObject Panel;

    private bool countdownActive = false; 
    private bool insideScene = true; 

    private Coroutine countdownCoroutine; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InvisibleWall") && !countdownActive)
        {
            insideScene = false;
            StartCountdown();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InvisibleWall") && countdownActive)
        {
            insideScene = true;
            StopCountdown();
            countdownTime = 6f;
        }
    }

    public void StartCountdown()
    {
        countdownActive = true;
        Panel.SetActive(true);
        countdownText.gameObject.SetActive(true); 
        countdownCoroutine = StartCoroutine(UpdateCountdown());
    }

    public void StopCountdown()
    {
        countdownActive = false;
        Panel.SetActive(false);
        countdownText.gameObject.SetActive(false); 

        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
    }

    IEnumerator UpdateCountdown()
    {
        while (countdownTime > 0f)
        {
            countdownText.text = countdownTime.ToString("Please return to the game in "+"0"+" seconds!");
            countdownTime -= Time.deltaTime;

            if (countdownTime <= 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            yield return null;
        }

        if (insideScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }
    }
}
