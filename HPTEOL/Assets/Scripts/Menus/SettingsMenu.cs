using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;
    private Settings sceneSettings;
    private GameObject GameManager;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        GameManager = GameObject.Find("GameManager");
        List<string> options = new List<string>();

        ///<summary>
        /// Updates current settings with saved settings
        /// </summary>
        try
        {
            Settings LoadedSets = (Settings)GameManager.GetComponent<FileManager>().LoadSettings("settings.json");
            sceneSettings = LoadedSets;
        }
        catch (System.Exception)
        {
            sceneSettings.resolution = resolutions.Length; 
            Debug.Log("Could not find settings file");
        }

        ///<summary>
        /// Add resolutions to dropdown
        /// </summary>
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = sceneSettings.resolution;
        resolutionDropdown.RefreshShownValue();
    }

    /// <summary>
    /// Set Resolution value to param value
    /// </summary>
    /// <param name="resolutionIndex"></param>
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        sceneSettings.resolution = resolutionIndex;
        GameManager.GetComponent<FileManager>().SaveData("settings.json", sceneSettings);
    }

    /// <summary>
    /// Set Volume value to param value
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume1", volume);
        sceneSettings.volume = volume;
        GameManager.GetComponent<FileManager>().SaveData("settings.json", sceneSettings);
    }

    /// <summary>
    /// Set Quality value to param value
    /// </summary>
    /// <param name="qualityIndex"></param>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        sceneSettings.quality = qualityIndex;
        GameManager.GetComponent<FileManager>().SaveData("settings.json", sceneSettings);
    }

    /// <summary>
    /// Set Fullscreen value to param value
    /// </summary>
    /// <param name="isFullscreen"></param>
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        sceneSettings.fullscreen = isFullscreen;
        GameManager.GetComponent<FileManager>().SaveData("settings.json", sceneSettings);
    }
}
