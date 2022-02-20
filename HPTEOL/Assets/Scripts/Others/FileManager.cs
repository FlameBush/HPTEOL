using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class FileManager : MonoBehaviour
{
    public void SaveData(string filename, object data)
    {
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText($"{Application.persistentDataPath}\\{filename}", json);
    }

    public object LoadSettings(string settingsfile)
    {
        if(File.Exists($"{Application.persistentDataPath}\\{settingsfile}"))
        {
            string json = File.ReadAllText($"{Application.persistentDataPath}\\{settingsfile}");
            Settings data = JsonConvert.DeserializeObject<Settings>(json);
            return data;
        }
        return "I'm just going to put this here because it doesn't matter what I put here";
    }
}
