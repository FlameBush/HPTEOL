using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMPro.TMP_Dropdown qualityDropdown;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle fullscreenToggle;

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
        /// Try to update current settings with saved settings or set them to default
        /// </summary>
        try
        {
            Settings LoadedSets = (Settings)GameManager.GetComponent<FileManager>().LoadSettings("settings.json");
            sceneSettings = LoadedSets;
            qualityDropdown.value = sceneSettings.quality;
            volumeSlider.value = sceneSettings.volume;
            fullscreenToggle.isOn = IntToBool(sceneSettings.fullscreen);
        }
        catch (System.NullReferenceException)
        {
            sceneSettings.resolution = resolutions.Length;
            sceneSettings.volume = 0.5f;
            sceneSettings.quality = 0;
            sceneSettings.fullscreen = 1;
            RefreshSettings();
            GameManager.GetComponent<FileManager>().SaveSettings("settings.json", sceneSettings);
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
        GameManager.GetComponent<FileManager>().SaveSettings("settings.json", sceneSettings);
    }

    /// <summary>
    /// Set Volume value to param value
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        sceneSettings.volume = volume;
        GameManager.GetComponent<FileManager>().SaveSettings("settings.json", sceneSettings);
    }

    /// <summary>
    /// Set Quality value to param value
    /// </summary>
    /// <param name="qualityIndex"></param>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        sceneSettings.quality = qualityIndex;
        GameManager.GetComponent<FileManager>().SaveSettings("settings.json", sceneSettings);
    }

    /// <summary>
    /// Set Fullscreen value to param value
    /// </summary>
    /// <param name="isFullscreen"></param>
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        sceneSettings.fullscreen = BoolToInt(isFullscreen);
        GameManager.GetComponent<FileManager>().SaveSettings("settings.json", sceneSettings);
    }

    public void RefreshSettings()
    {
        resolutionDropdown.value = sceneSettings.resolution;
        qualityDropdown.value = sceneSettings.quality;
        volumeSlider.value = sceneSettings.volume;
        fullscreenToggle.isOn = IntToBool(sceneSettings.fullscreen);
    }

    public int BoolToInt(bool b)
    {
        if (b)
        {
            return 1;
        }
        return 0;
    }

    public bool IntToBool(int b)
    {
        if (b == 1)
        {
            return true;
        }
        return false;
    }
}
