using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer theMixer;
    void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            theMixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
        }
    }
}
