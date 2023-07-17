using UnityEngine;

public class BarrierMng : MonoBehaviour
{
    public float activeTime = 2f; 
    public float inactiveTime = 1f; 
    public GameObject targetObject; 

    private bool isActive = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = true;
            StartCoroutine(ObjectPatternCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isActive = false;
            targetObject.SetActive(false);
        }
    }

    private System.Collections.IEnumerator ObjectPatternCoroutine()
    {
        while (isActive)
        {
            targetObject.SetActive(true);

            yield return new WaitForSeconds(activeTime);

            targetObject.SetActive(false);

            yield return new WaitForSeconds(inactiveTime);

            if (isActive)
            {
                targetObject.SetActive(true);

                yield return new WaitForSeconds(activeTime);
            }
        }
    }
}
