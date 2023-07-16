using UnityEngine;

public class BarrierMng : MonoBehaviour
{
    public float activeTime = 2f; // Aktif s�re (saniye)
    public float inactiveTime = 1f; // Deaktif s�re (saniye)
    public GameObject targetObject; // Hedef obje

    private bool isActive = false; // Ba�lang��ta obje deaktif olsun

    private void OnTriggerEnter(Collider other)
    {
        // Collider'a giren bir nesne varsa
        if (other.CompareTag("Player"))
        {
            // Objeyi aktif hale getirin ve d�ng�y� ba�lat�n
            isActive = true;
            StartCoroutine(ObjectPatternCoroutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Collider'dan ��kan bir nesne varsa
        if (other.CompareTag("Player"))
        {
            // Objeyi deaktif hale getirin ve d�ng�y� durdurun
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

            // Belirtilen s�re boyunca bekleyin
            yield return new WaitForSeconds(activeTime);

            // Hedef objeyi deaktif hale getirin
            targetObject.SetActive(false);

            // Belirtilen s�re boyunca bekleyin
            yield return new WaitForSeconds(inactiveTime);

            // Tekrar kontrol edin, e�er isActive hala do�ruysa, d�ng�y� devam ettirin
            if (isActive)
            {
                // Hedef objeyi tekrar aktif hale getirin
                targetObject.SetActive(true);

                // Bekleme s�resi boyunca bekleyin
                yield return new WaitForSeconds(activeTime);
            }
        }
    }
}
