using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelScripts : MonoBehaviour
{
    public void PassLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        print(currentLevel);
        if (currentLevel >= PlayerPrefs.GetInt("LevelsUnlocked"))
        {
            PlayerPrefs.SetInt("LevelsUnlocked", currentLevel + 1);
        }
    }
}
