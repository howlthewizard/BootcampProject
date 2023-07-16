using UnityEngine;

public class BarrierMng : MonoBehaviour
{
    public float activeTime = 2f; // Aktif süre (saniye)
    public float inactiveTime = 1f; // Deaktif süre (saniye)
    public GameObject targetObject; // Hedef obje

    private bool isActive = false; // Baþlangýçta obje deaktif olsun

    private void OnTriggerEnter(Collider other)
    {
        // Collider'a giren bir nesne varsa
        if (other.CompareTag("Player"))
        {
            // Objeyi aktif hale getirin ve döngüyü baþlatýn
            isActive = true;
            StartCoroutine(ObjectPatternCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Collider'dan çýkan bir nesne varsa
        if (other.CompareTag("Player"))
        {
            // Objeyi deaktif hale getirin ve döngüyü durdurun
            isActive = false;
            targetObject.SetActive(false);
        }
    }

    private System.Collections.IEnumerator ObjectPatternCoroutine()
    {
        while (isActive)
        {
            // Hedef objeyi aktif hale getirin
            targetObject.SetActive(true);

            // Belirtilen süre boyunca bekleyin
            yield return new WaitForSeconds(activeTime);

            // Hedef objeyi deaktif hale getirin
            targetObject.SetActive(false);

            // Belirtilen süre boyunca bekleyin
            yield return new WaitForSeconds(inactiveTime);

            // Tekrar kontrol edin, eðer isActive hala doðruysa, döngüyü devam ettirin
            if (isActive)
            {
                // Hedef objeyi tekrar aktif hale getirin
                targetObject.SetActive(true);

                // Bekleme süresi boyunca bekleyin
                yield return new WaitForSeconds(activeTime);
            }
        }
    }
}
