using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownMng : MonoBehaviour
{
    public float countdownTime = 6f; 
    public TextMeshProUGUI countdownText; 

    private bool countdownActive = false; 
    private bool insideScene = true; 

    private Coroutine countdownCoroutine; 

    private void Start()
    {
    }

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
        countdownText.gameObject.SetActive(true); 
        countdownCoroutine = StartCoroutine(UpdateCountdown());
    }

    public void StopCountdown()
    {
        countdownActive = false;
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
