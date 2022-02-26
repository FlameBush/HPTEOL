using UnityEngine;

public class FileManager : MonoBehaviour
{
    public void SaveSettings(Settings data)
    {
        PlayerPrefs.SetFloat("MasterVol", data.volume);
        PlayerPrefs.SetInt("Resolution", data.resolution);
        PlayerPrefs.SetInt("Quality", data.quality);
        PlayerPrefs.SetInt("Fullscreen", data.fullscreen);
    }

    public object LoadSettings()
    {
        Settings data = new Settings
        {
            fullscreen = PlayerPrefs.GetInt("Fullscreen", 1),
            resolution = PlayerPrefs.GetInt("Resolution", Screen.resolutions.Length),
            quality = PlayerPrefs.GetInt("Quality", 0),
            volume = PlayerPrefs.GetFloat("MasterVol", 50)
        };
        return data;
    }
}
