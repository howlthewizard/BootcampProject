using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _promptText;
    [SerializeField] private GameObject uiPanel;
    public bool IsDisplayed = false;

    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
        uiPanel.SetActive(false);
    }
    private void LateUpdate()
    {
        var rotation = mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation* Vector3.forward
        ,rotation*Vector3.up);
    }
    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        uiPanel.SetActive(true);
        IsDisplayed = true; 
    }
    public void Close()
    {
        uiPanel.SetActive(false);
        IsDisplayed= false;
    }
}
