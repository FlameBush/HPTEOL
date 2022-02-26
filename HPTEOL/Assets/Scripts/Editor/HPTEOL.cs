using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class HPTEOL : Editor
{
    [MenuItem("HPTEOL/Delete Prefs %g")]
    public static void DeletePref()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Pref Deleted");
    }
    [MenuItem("HPTEOL/Load Splash")]
    public static void LoadSplash()
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene("Assets/Scenes/Splash.unity", OpenSceneMode.Single);
        Debug.Log("Loading Splash");
    }
}
