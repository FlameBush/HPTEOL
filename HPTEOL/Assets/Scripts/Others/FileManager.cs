using UnityEngine;

public class FileManager : MonoBehaviour
{
    public void SaveSettings(string filename, Settings data)
    {
        PlayerPrefs.SetFloat("MasterVol", data.volume);
        PlayerPrefs.SetInt("Resolution", data.resolution);
        PlayerPrefs.SetInt("Quality", data.quality);
        PlayerPrefs.SetInt("Fullscreen", data.fullscreen);
    }

    public object LoadSettings(string settingsfile)
    {
        Settings data = new Settings
        {
            fullscreen = PlayerPrefs.GetInt("Fullscreen"),
            resolution = PlayerPrefs.GetInt("Resolution"),
            quality = PlayerPrefs.GetInt("Quality"),
            volume = PlayerPrefs.GetFloat("MasterVol")
        };
        return data;
    }
}