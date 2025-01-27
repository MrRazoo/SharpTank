using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class ControlSetting : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    private int currentIndex = 0;
    public TMP_Dropdown resolutionDrop;
    
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDrop.ClearOptions(); // first clear all initial Options

        List<string> Options = new List<string>();
        
        // just add all resolution to dropDown
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;  // 1920 x 1080
            Options.Add(option);
             
            // just Find the current Resolution Index to set in dropdown value
            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                {
                    currentIndex = i;
                }
        } 

        resolutionDrop.AddOptions(Options); // Add all List of resolutions

        resolutionDrop.value = currentIndex;
        resolutionDrop.RefreshShownValue();
    }
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    public void SetResolution(int ResIndex)
    {
        Resolution resolution = resolutions[ResIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
