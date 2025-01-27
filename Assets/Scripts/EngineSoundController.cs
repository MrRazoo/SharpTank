using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundController : MonoBehaviour
{
    public float minVolume = 0.05f;
    public float maxVolume = 0.5f;
    public float currentVolume;
    public float increaseVolume = 0.02f;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        currentVolume = minVolume;
    }
    private void Start()
    {
        audioSource.volume = currentVolume;
    }

    public void UpdateEngineSound(float speed)
    {
        if(speed > 0)
        {
            if(currentVolume < maxVolume)
                currentVolume += increaseVolume * Time.deltaTime;
        }
        else
        {
            if(currentVolume > minVolume)
            currentVolume -= increaseVolume * Time.deltaTime;
        }
        currentVolume = Mathf.Clamp(currentVolume, minVolume, maxVolume);
        audioSource.volume = currentVolume;
    }

}
