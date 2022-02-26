using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

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
    private int sc;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        GameManager = GameObject.Find("GameManager");
        List<string> options = new List<string>();

        Settings LoadedSets = (Settings)GameManager.GetComponent<FileManager>().LoadSettings();
        sceneSettings = LoadedSets;
        qualityDropdown.value = sceneSettings.quality;
        volumeSlider.value = sceneSettings.volume;
        fullscreenToggle.isOn = IntToBool(sceneSettings.fullscreen);

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
        GameManager.GetComponent<FileManager>().SaveSettings(sceneSettings);
    }

    /// <summary>
    /// Set Volume value to param value
    /// </summary>
    /// <param name="volume"></param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        sceneSettings.volume = volume;
        GameManager.GetComponent<FileManager>().SaveSettings(sceneSettings);
    }

    /// <summary>
    /// Set Quality value to param value
    /// </summary>
    /// <param name="qualityIndex"></param>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        sceneSettings.quality = qualityIndex;
        GameManager.GetComponent<FileManager>().SaveSettings(sceneSettings);
        if (qualityIndex == 3)
        {
            sc++;
            if (sc > 2)
            {
                sc = 0;
                QualitySettings.SetQualityLevel(4); // We do a little bit of trolling
            }
        }
    }

    /// <summary>
    /// Set Fullscreen value to param value
    /// </summary>
    /// <param name="isFullscreen"></param>
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        sceneSettings.fullscreen = BoolToInt(isFullscreen);
        GameManager.GetComponent<FileManager>().SaveSettings(sceneSettings);
    }

    /// <summary>
    /// Sets all the settings again and updates UI values
    /// </summary>
    public void RefreshSettings()
    {
        resolutionDropdown.value = sceneSettings.resolution;
        qualityDropdown.value = sceneSettings.quality;
        volumeSlider.value = sceneSettings.volume;
        fullscreenToggle.isOn = IntToBool(sceneSettings.fullscreen);
        QualitySettings.SetQualityLevel(sceneSettings.quality);
        audioMixer.SetFloat("Master", Mathf.Log10(sceneSettings.volume) * 20);
        Resolution resolution = resolutions[sceneSettings.resolution];
        Screen.SetResolution(resolution.width, resolution.height, IntToBool(sceneSettings.fullscreen));
    }

    /// <summary>
    /// Converts a bool to a 0 or 1 value
    /// </summary>
    /// <param name="b"></param>
    /// <returns>0 or 1</returns>
    public int BoolToInt(bool b)
    {
        if (b)
        {
            return 1;
        }
        return 0;
    }

    /// <summary>
    /// Converts a int to a bool value
    /// </summary>
    /// <param name="b"></param>
    /// <returns>True or False</returns>
    public bool IntToBool(int b)
    {
        if (b == 1)
        {
            return true;
        }
        return false;
    }
}
